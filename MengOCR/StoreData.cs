using JsonFlatFileDataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MengOCR
{
    internal class StoreData
    {
        static readonly DataStore store;
        static readonly StoreData instance;

        public static StoreData Instance { get { return instance; } }

        static StoreData()
        {
            instance = new StoreData();
            store = new DataStore("meng-ocr.json");
        }

        public async Task AddWorkspaceAsync(string name)
        {
            var collection = store.GetCollection<Workspace>();
            var space = new Workspace()
            {
                Name = name,
                Id = Guid.NewGuid().ToString(),
            };

            await collection.InsertOneAsync(space);
        }

        public List<OcrDataItem> SearchAsync(string keyword)
        {
            var collection = store.GetCollection<OcrDataItem>();

            var results = collection.AsQueryable().Where(e => e.ContentTxt.Contains(keyword)).ToList();

            return results;
        }

        public OcrDataItem GetOCRItemAsync(string filename)
        {
            var collection = store.GetCollection<OcrDataItem>();
            return collection.Find(t => t.ImgFileName == filename).First();
        }

        public async Task AddOCRItemAsync(OcrDataItem item)
        {
            var collection = store.GetCollection<OcrDataItem>();
            await collection.InsertOneAsync(item);
        }

        public async Task UpdateOCRItemAsync(OcrDataItem item)
        {
            var collection = store.GetCollection<OcrDataItem>();
            await collection.UpdateOneAsync(item.Id, item);
        }

        public async Task DeleteOCRItemAsync(dynamic id)
        {
            var collection = store.GetCollection<OcrDataItem>();
            await collection.DeleteOneAsync(id);
        }

    }



    public class Workspace
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }

    public class OcrDataItem
    {
        public string Id { get; set; }

        public string WorkspaceName { get; set; }

        public string ImgFileName { get; set; }

        public string ContentTxt { get; set; }

        public DateTime CreateTime { get; set; }

    }


}
