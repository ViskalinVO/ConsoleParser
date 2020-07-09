using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    class BaseResponseClass
    {
        public BaseResponseClass()
        {
            CollectionItems = new List<CollectionItem>();
        }
        public string CollectionName { get; set; }
        public List<CollectionItem> CollectionItems { get; set; }

        public class CollectionItem
        {
            public string CollectionItemName { get; set; }
        }

    }
}
