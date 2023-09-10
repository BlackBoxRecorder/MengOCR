using JsonFlatFileDataStore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// 设置或更新KeyValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void SetKeyVal<T>(string key, T val)
        {
            try
            {
                var exsit = store.GetKeys().ContainsKey(key);
                if (exsit)
                {
                    store.UpdateItem(key, val);
                }
                else
                {
                    store.InsertItem(key, val);
                }

            }
            catch (Exception)
            {

            }
        }

        public T GetKeyVal<T>(string key)
        {
            try
            {
                var exsit = store.GetKeys().ContainsKey(key);
                if (exsit)
                {
                    return store.GetItem<T>(key);
                }

            }
            catch (Exception)
            {

            }
            return (T)(object)null;

        }

        public bool HasKey(string key)
        {
            try
            {
                return store.GetKeys().ContainsKey(key);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 清空store
        /// </summary>
        public async Task ClearStore()
        {
            var spaces = store.GetCollection<Workspace>();
            var items = store.GetCollection<OcrDataItem>();

            await spaces.DeleteManyAsync(s => s.Id != string.Empty);
            await items.DeleteManyAsync(i => i.Id != string.Empty);
        }

        /// <summary>
        /// 根据文件目录创建config.json
        /// </summary>
        /// <returns></returns>
        public async Task SyncWorkspace(string path)
        {
            //读取目录作为工作区
            var dirs = Directory.GetDirectories(path);
            if (!dirs.Any()) { return; }
            var collection = store.GetCollection<Workspace>();
            var ocrItemCollection = store.GetCollection<OcrDataItem>();

            //读取每个目录（工作区）中的文件作为item
            foreach (var dir in dirs)
            {
                var name = new DirectoryInfo(dir).Name;
                var exist = collection.Find(w => w.Name == name);
                if (exist.Count() < 1)
                {
                    await AddWorkspaceAsync(name);
                }

                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    var img = Path.GetFileName(file);
                    var imgexist = ocrItemCollection.Find(f => f.ImgFileName == img);
                    if (imgexist.Count() > 0) continue;

                    //识别图片内容
                    await AddOCRItemAsync(new OcrDataItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        ImgFileName = img,
                        WorkspaceName = name,
                        ContentTxt = "",
                        CreateTime = new FileInfo(file).CreationTime
                    });

                }
            }

        }

        /// <summary>
        /// 初始化工作区，创建默认工作区
        /// </summary>
        /// <returns></returns>
        public async Task InitWorkspace()
        {
            var collection = store.GetCollection<Workspace>();
            const string name = "默认工作区";
            var exist = collection.Find(w => w.Name == name);

            if (exist.Count() > 0)
            {
                return;
            }

            //初始化默认工作区
            await AddWorkspaceAsync(name);
        }

        /// <summary>
        /// 初始化默认配置
        /// </summary>
        public void InitConfig()
        {
            if (HasKey(StoreKeys.SnapShowMain) == false)
            {
                SetKeyVal(StoreKeys.SnapShowMain, true);
            }

            if (HasKey(StoreKeys.CloseExit) == false)
            {
                SetKeyVal(StoreKeys.CloseExit, true);
            }
            string dir = "";
            if (HasKey(StoreKeys.SnapSaveDir) == false)
            {
                //设置默认路径
                var userPicDir = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                dir = Path.Combine(userPicDir, "MengOCR");
                SetKeyVal(StoreKeys.SnapSaveDir, dir);
            }

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (HasKey(StoreKeys.KeyBingding) == false)
            {
                var mkey = Keys.Shift;
                var key = Keys.X;
                SetKeyVal(StoreKeys.KeyBingding, $"{mkey}+{key}");
            }

        }


        public List<Workspace> GetConfig()
        {
            var collection = store.GetCollection<Workspace>();
            return collection.AsQueryable().ToList();
        }

        /// <summary>
        /// 添加工作区
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取所有工作区
        /// </summary>
        /// <returns></returns>
        public List<Workspace> GetWorkspaceAsync()
        {
            var collection = store.GetCollection<Workspace>();
            return collection.AsQueryable().ToList();
        }

        /// <summary>
        /// 删除一个工作区
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public void DeleteWorkspaceAsync(string name)
        {
            var collection = store.GetCollection<Workspace>();
            collection.DeleteOne(w => w.Name == name);

            //删除item
            var items = store.GetCollection<OcrDataItem>();
            items.DeleteMany(w => w.WorkspaceName == name);

        }

        /// <summary>
        /// 在内容中搜索关键字
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<OcrDataItem> SearchAsync(string keyword)
        {
            var collection = store.GetCollection<OcrDataItem>();

            var results = collection.AsQueryable().Where(e => e.ContentTxt.Contains(keyword)).ToList();

            return results;
        }

        /// <summary>
        /// 根据文件名获取一个指定的OcrDataItem
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public OcrDataItem GetOCRItemAsync(string filename)
        {
            var collection = store.GetCollection<OcrDataItem>();
            return collection.Find(t => t.ImgFileName == filename).First();
        }

        /// <summary>
        /// 获取一个工作区中所有的OcrDataItem
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        public List<OcrDataItem> GetOCRItemsByWorkspace(string space)
        {
            var collection = store.GetCollection<OcrDataItem>();
            return collection.Find(t => t.WorkspaceName == space).ToList();
        }

        /// <summary>
        /// 获取所有的OcrDataItem
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        public List<OcrDataItem> GetAllOCRItems()
        {
            var collection = store.GetCollection<OcrDataItem>();
            return collection.AsQueryable().ToList();
        }


        /// <summary>
        /// 添加一个OcrDataItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task AddOCRItemAsync(OcrDataItem item)
        {
            var collection = store.GetCollection<OcrDataItem>();
            await collection.InsertOneAsync(item);
        }

        /// <summary>
        /// 更新一个OcrDataItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task UpdateOCRItemAsync(OcrDataItem item)
        {
            var collection = store.GetCollection<OcrDataItem>();
            await collection.UpdateOneAsync(item.Id, item);
        }

        /// <summary>
        /// 删除一个OcrDataItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteOCRItemAsync(dynamic id)
        {
            var collection = store.GetCollection<OcrDataItem>();
            await collection.DeleteOneAsync(id);
        }

    }

    public class AppConfig
    {
        public string KeyVal { get; set; }
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


    public static class StoreKeys
    {
        public static readonly string CloseExit = "closeExit";

        public static readonly string SnapShowMain = "snapShowMain";

        public static readonly string SnapSaveDir = "snapSaveDir";

        public static readonly string KeyBingding = "keyBinding";

    }

}
