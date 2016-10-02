using ShipsService.Models;
using ShipsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShipsService.Services
{
    public class DocumentsService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static string ShipsDirectory = "~/Files/ShipsFiles";
        public static string AvatarsDirectory = "~/Files/UserAvatarFiles";

        public Document SaveDocumentBy(ApplicationUser user, HttpPostedFileBase file, DateTime current, string directory)
        {

            string fileName = current.ToString(user.Id.GetHashCode() + "dd/MM/yyyy H:mm:ss").Replace(":", "_").Replace("/", ".").Replace(" ", "_");
            
            // Получаем расширение
            var ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            var path = directory + "/" + fileName + "." + ext;

            // сохраняем файл по определенному пути на сервере
            file.SaveAs(path);

            Document doc = new Document();

            if (file != null)
            {
                doc.Size = file.ContentLength;
                doc.Type = ext;
                doc.Url = path;
            }

            return doc;
        }



        public FileResult GetFileBy(int id)
        {
            var reqDoc = db.Documents.Find(id);//.Document;

            byte[] fileBytes = System.IO.File.ReadAllBytes(reqDoc.Url);
            string fileName = reqDoc.Id + "." + reqDoc.Type;

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}