using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MengOCR
{
    internal class StoreData
    {


        public class Workspace
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

        }

        public class OcrDataItem
        {
            public string WorkspaceName { get; set; }

            public string ImgFileName { get; set; }

            public string ContentTxt { get; set; }

            public DateTime CreateTime { get; set; }

            public string Tag { get; set; }



        }



    }
}
