using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    interface IAPI
    {
        /// <summary>
        /// Шаблон строки запроса. У каждого API свой
        /// </summary>
        string UrlPath { get; set; }
        /// <summary>
        /// запрос к серверу
        /// </summary>
        /// <param name="url">строка запроса</param>
        /// <returns></returns>
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
