using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    interface ICache
    {
        void SaveInCache(string apiPath, string searchText, string searchResult);
        string GetFromCache(string searchText);
    }
}
