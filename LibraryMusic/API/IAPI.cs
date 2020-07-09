using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    interface IAPI
    {
        string UrlPath { get; set; }
        string GetQuery(string url);
        /// <summary>
        /// Десириализуем ответ от API и приводим к универсальному классу ответа
        /// </summary>
        /// <param name="searchText">текст поиска, он же имя коллекции</param>
        /// <param name="jsonAnswer">Ответ</param>
        /// <returns></returns>
        BaseResponseClass DeserializeToBaseResponseClass(string searchText, string jsonAnswer);
    }
}
