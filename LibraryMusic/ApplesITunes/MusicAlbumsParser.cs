using Newtonsoft.Json;
using System;
using System.Linq;

namespace LibraryMusic
{
    class MusicAlbumsParser : IParser
    {
        public ICache Cache { get; set; }
        public IAPI Api { get; set; }

        public MusicAlbumsParser(ICache cache, IAPI api)
        {
            this.Cache = cache;
            this.Api = api;
        }

        public void Run()
        {
            Console.WriteLine("Введите название группы: ");
            string searchText = Console.ReadLine();

            if (!String.IsNullOrEmpty(searchText) && !string.IsNullOrWhiteSpace(searchText))
            {             
                string apiPath = this.Api.UrlPath + searchText;
                string jsonAnswer = string.Empty;
                //
                try
                {
                    //запрашиваем данные с сервера
                    jsonAnswer = this.Api.GetQuery(apiPath);
                    //Сохраняем результат запроса в кэш
                    this.Cache.SaveInCache(apiPath, searchText, jsonAnswer); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    //при ошибке запроса на сервер, проверяем данные в кэше
                    jsonAnswer = this.Cache.GetFromCache(apiPath);
                }
                if (!string.IsNullOrEmpty(jsonAnswer))
                {
                    var responseData = this.Api.DeserializeToBaseResponseClass(searchText, jsonAnswer);

                    if (responseData != null && responseData.CollectionItems.Count > 0)
                    {
                        Console.WriteLine("Найдено:{0} альбомов: ", responseData.CollectionItems.Count);
                        foreach (var result in responseData.CollectionItems)
                        {
                            Console.WriteLine(result.CollectionItemName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Альбомы не найдены");
                    }
                }
            }
            else
            {
                Console.WriteLine("Введена пустая строка");
            }

        }
    }
}
