using HRSS.ManageMyNotes.Model;
using HRSS.ManageMyNotes.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageMyNotes.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Note, ManageMyNotesDbContext> repo;
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            return View(new Note());
        }
        public JsonResult AddNote(Note note)
        {
            using (repo = new NoteRepository())
            {
                note.ID = Guid.NewGuid();
                note.CreatedDate = DateTime.Now;
                note.LastUpdatedDate = DateTime.Now;
                return Json(repo.Add(note));
            }
            
        }

        [HttpGet]
        public JsonResult Search(string columnName, string criteria )
        {
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}