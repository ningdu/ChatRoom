using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatRoom.Models;

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
            if (ModelState.IsValid)
            {
                db.Chats.Add(chat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chat);
        }

        //
        // GET: /Chat/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Chat chat = db.Chats.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        //
        // POST: /Chat/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chat chat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chat);
        }

        //
        // GET: /Chat/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Chat chat = db.Chats.Find(id);
            if (chat == null)
            {
                return HttpNotFound();
            }
            return View(chat);
        }

        //
        // POST: /Chat/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chat chat = db.Chats.Find(id);
            db.Chats.Remove(chat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}