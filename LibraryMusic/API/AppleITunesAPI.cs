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
    class AppleITunesAPI : API, IAPI
    {
        private string urlPath = "https://itunes.apple.com/search?entity=album&attribute=allArtistTerm&term=";

        public override string UrlPath
        {
            get { return urlPath; }
            set { this.urlPath = value; }
        }

        public BaseResponseClass DeserializeToBaseResponseClass(string name, string jsonAnswer)
        {
            var iTunesAlbumsResponse =  JsonConvert.DeserializeObject<AppleITunesApiAlbumsResponse>(jsonAnswer);

            var result = new BaseResponseClass { CollectionName = name };
            foreach (var item in iTunesAlbumsResponse.results)
            {
                result.CollectionItems.Add(new BaseResponseClass.CollectionItem { CollectionItemName = item.collectionName });
            }
            return result;

        }
    }
}

