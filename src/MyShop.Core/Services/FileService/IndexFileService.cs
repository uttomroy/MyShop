using Microsoft.AspNetCore.Hosting;
using MyShop.Core.Models;
using Newtonsoft.Json;

namespace MyShop.Core.Services.FileService
{
    public interface IIndexFileService
    {
        public AssetFile GetIndexFileDetails();
    }

    public class IndexFileService : IIndexFileService
    {
        private readonly IHostingEnvironment _environment;
        private static AssetFile? _assetFile;

        public IndexFileService(IHostingEnvironment environment)
        {
            _environment = environment;
            _assetFile = null;
        }

        public AssetFile GetIndexFileDetails()
        {
            if(_assetFile == null)
            {
                var filePath = Path.Combine(_environment.WebRootPath, "asset-manifest.json");
                var assetFile = JsonConvert.DeserializeObject<AssetFile>(File.ReadAllText(filePath));
                _assetFile = assetFile;
            }
            return _assetFile;
        }
    }
}
