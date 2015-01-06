using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using ChatRoom.Models;
using WebMatrix.WebData;

namespace ChatRoom.Controllers
{
    public class ChatController : Controller
    {
        private ChatContext db = new ChatContext();

        //
        // GET: /Chat/

        public ActionResult Index()
        {
            return View(db.Chats.ToList());
        }

        //
        // GET: /Chat/Details/5

        public ActionResult Details(int id = 0)
        {
            Chat chat = db.Chats.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        //
        // GET: /Chat/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Chat/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chat chat)
        {

            if (String.IsNullOrEmpty(WebSecurity.CurrentUserName))
            {
                return RedirectToAction("Login","Account");
            }
            else
            {
                
                if (String.IsNullOrEmpty(chat.Message)==false)
                {
                    chat.UserID = WebSecurity.CurrentUserName;
                    chat.Time = DateTime.Now;
                    db.Chats.Add(chat);
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    
                }

            }
            return View(chat);
        }

       
    }
}