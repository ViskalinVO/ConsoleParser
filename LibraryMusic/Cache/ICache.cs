using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    interface ICache
    {
        /// <summary>
        /// Сохраняет данные успешно запроса в кэше
        /// </summary>
        /// <param name="apiPath">строка запроса к серверу</param>
        /// <param name="searchResult">результат запроса к серверу</param>
        void SaveInCache(string apiPath, string searchResult);
        /// <summary>
        /// Берем данные из Кэша
        /// </summary>
        /// <param name="apiPath">строка запроса к серверу</param>
        /// <returns></returns>
        string GetFromCache(string apiPath);
    }
}
