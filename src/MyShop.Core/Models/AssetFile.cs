using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyShop.Core.Models
{
    public class AssetFile
    {
        [JsonProperty("files")]
        public Files Files { get; set; }
    }

    public class Files
    {
        [JsonProperty("main.js")]
        public string MainJs { get; set; }

        [JsonProperty("main.css")]
        public string MainCss { get; set; }
    }
}
