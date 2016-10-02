using System.Drawing;
using Microsoft.Ajax.Utilities;

namespace ShipsService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using ShipsService.Models;
    using Microsoft.AspNet.Identity;
    using System.Web.WebPages;
    using Models;
    using Services;

    public class ShipController : Controller
    {
        protected ApplicationDbContext Db { get; } = new ApplicationDbContext();
        protected DocumentsService docService = new DocumentsService();

        public ActionResult Index()
        {
            IEnumerable<Ship> allReqs = null;

            allReqs = Db.Ships;                    ;

            return View(allReqs.ToList());
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }


        public string currentUserId
        {
            get { return HttpContext.User.Identity.GetUserId(); }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            if (currentUserId != null)
            {              
                return View();
            }

            return RedirectToAction("LogOff", "Account");
        }

        protected void TryCreate(ApplicationUser user, Ship savingShip)
        {
            DateTime current = DateTime.Now;

            /*
            if (file != null)
            {
                //Document doc = docService.SaveDocumentBy(user, file, current, Server.MapPath(DocumentsService.ShipsDirectory + "/" + user.Id));

                Db.Documents.Add(doc);

                savingShip.ShipsDocuments.Add(doc);
                user.ShipsDocuments.Add(doc);
            }
            */

            // указываем автора задачи
            savingShip.Author = user;
            savingShip.AuthorId = user.Id;
            
            Db.Ships.Add(savingShip);

            Db.Entry(user).State = EntityState.Modified;

            try
            {
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Ship ship)
        {

            // получаем текущего пользователя
            ApplicationUser user = Db.Users.FirstOrDefault(m => m.Id == currentUserId);

            if (currentUserId == null)
            {
                return RedirectToAction("LogOff", "Account");
            }

            if (ModelState.IsValid)
            {
                TryCreate(user, ship);
                
                return RedirectToAction("Index");
            }

            return View("Index");
        }
                
        public ActionResult Details(int id)
        {
            Ship request = Db.Ships.Find(id);

            if (request != null)
            {
                //получаем категорию
                return PartialView("_Details", request);
            }

            return View("Index");
        }

        [Authorize]
        public ActionResult Author(string id)
        {
            ApplicationUser executor = Db.Users.First(m => m.Id == id);

            if (executor != null)
            {
                return PartialView("_Executor", executor);
            }
            return View("Index");
        }
        
        // Удаление задачи
        [Authorize]
        public ActionResult Delete(int id)
        {
            Ship request = Db.Ships.Find(id);
            var curId = HttpContext.User.Identity.GetUserId();

            // получаем текущего пользователя
            ApplicationUser user = Db.Users.First(m => m.Id == curId);

            if (request != null && request.Author.Id == user.Id)
            {
                Db.Ships.Remove(request);
                Db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// Статистика
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCountOfAllShips()
        {
            string count = Db.Ships.Count().ToString();
            ViewBag.Message = count;
            return PartialView("Message");
        }

        public ActionResult GetCountOfAllUsers()
        {
            string count = Db.Users.Count().ToString();
            ViewBag.Message = count;
            return PartialView("Message");
        }
        
    }



}
