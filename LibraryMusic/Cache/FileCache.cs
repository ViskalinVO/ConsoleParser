using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    //todo как вариант расширения
    class FileCache : ICache
    {
        public string GetFromCache(string apiPath)
        {
            throw new NotImplementedException();
        }

        public void SaveInCache(string apiPath, string searchResult)
        {
            throw new NotImplementedException();
        }
    }
}
