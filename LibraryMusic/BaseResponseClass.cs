using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    class BaseResponseClass: IPrinter
    {
        public BaseResponseClass()
        {
            CollectionItems = new List<CollectionItem>();
        }
        public string CollectionName { get; set; }
        public List<CollectionItem> CollectionItems { get; set; }

        public void Print(PrinterType printerType)
        {
            switch (printerType)
            {
                case PrinterType.Console:
                    Console.WriteLine("Найдено:{0} альбомов: ", this.CollectionItems.Count);
                    foreach (var result in this.CollectionItems)
                    {
                        Console.WriteLine(result.CollectionItemName);
                    }
                    break;
                case PrinterType.File:
                    //todo
                    break;
                case PrinterType.Printer:
                    //todo
                    break;
                default:
                    break;
            }

        }

        public class CollectionItem
        {
            public string CollectionItemName { get; set; }
        }

    }
}
