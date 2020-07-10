using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMusic
{
    /// <summary>
    /// Абстрактный класс. Родительский для всех API
    /// </summary>
    abstract class API
    {
        abstract public string UrlPath { get; set; }
        public string GetQuery(string url)
        {
            string answer = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        answer = reader.ReadToEnd();
                    }
                }
                response.Close();
            }
            catch (WebException ex)
            {
                // получаем статус исключения
                WebExceptionStatus status = ex.Status;

                if (status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;
                    Console.WriteLine("Статусный код ошибки: {0} - {1}",
                            (int)httpResponse.StatusCode, httpResponse.StatusCode);
                }
                else
                {
                    Console.WriteLine($"{ex.Message} ({ex.Status})");
                }
                throw new Exception("Не удалось получить данный по API");
            }

            return answer;
        }

    }
}

