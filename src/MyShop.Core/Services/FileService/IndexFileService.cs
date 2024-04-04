using Microsoft.AspNetCore.Hosting;
using MyShop.Core.Models;
using Newtonsoft.Json;
using System.ComponentModel;

namespace MyShop.Core.Services.FileService
{
    public interface IIndexFileService
    {
        public AssetFile GetIndexFileDetails();
        public void AddStudent(Student newstudent);
        public List<Student> GetStudents();
    }

    public class IndexFileService : IIndexFileService
    {
        private readonly IHostingEnvironment _environment;
        private static AssetFile? _assetFile;
        private static List<Student> _students;
        public IndexFileService(IHostingEnvironment environment)
        {
            _environment = environment;
            _assetFile = null;
            _students = new List<Student>();    
        }
        public  void AddStudent(Student newstudent)
        {
            _students.Add(newstudent) ;
        }
        public  List<Student> GetStudents()
        {
            return _students;
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
