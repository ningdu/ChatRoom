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
            return View(new ChatPanel() { Chats = db.Chats.ToList(), NewChat = new Chat() });
        }
        //
        // GET: /Chat/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Chat chat = db.Chats.Find(id);
        //    if (chat == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(chat);
        //}

        //
        // GET: /Chat/Create

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //
        // POST: /Chat/Index/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ChatPanel panel)
        {

            if (String.IsNullOrEmpty(WebSecurity.CurrentUserName))
            {
                return RedirectToAction("Login","Account");
            }
            else
            {
                
                if (String.IsNullOrEmpty(panel.NewChat.Message)==false)
                {
                    panel.NewChat.UserID = WebSecurity.CurrentUserName;
                    panel.NewChat.Time = DateTime.Now;
                    db.Chats.Add(panel.NewChat);
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    
                }

            }
            //return View(chat);
            return View(new ChatPanel() { Chats = db.Chats.ToList(), NewChat = new Chat() });
        }

       
    }
}