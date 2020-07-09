using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Net;

namespace LibraryMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            //ToDo: выбор хранения Кэша
            var cache = new SqlLiteCache();
            //ToDo: выбор источника запрашиваемых данных (API)
            var api = new AppleITunesAPI();
            //Создаем парсер с конкретным API и способом хранения кэша
            var parser = new MusicAlbumsParser(cache, api);

            bool done;
            do
            {
                parser.Run();
                Console.WriteLine("Желаете повторить поиск? Нажмите \"Y\"");
                done = Console.ReadLine().ToUpper() != "Y";
            }
            while (!done);

        }
    }
}
