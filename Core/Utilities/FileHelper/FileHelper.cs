using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public static class FileHelper
    {
        public static string Add(IFormFile file, string path)
        {
            var newGuidPath = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string newPath = path + "\\" + newGuidPath;
            if (file == null)
            {
                return "default.png";
            }

            using (var stream = System.IO.File.Create(newPath))
            {
                file.CopyTo(stream);
                stream.Flush();
            }
            return newGuidPath;
        }

        public static void Delete(string path)
        {
            System.IO.File.Delete(path);
        }

        public static string Update(IFormFile file, string path, string imagePath)
        {
            string updateImagePath = Path.Combine(path, imagePath);
            string newGuid = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string newGuidPath = path + "\\" + newGuid;
            System.IO.File.Move(updateImagePath, newGuidPath);

            return newGuid;
        }
    }
}
