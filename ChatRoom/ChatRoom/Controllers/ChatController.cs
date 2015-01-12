using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using ChatRoom.Models;
using WebMatrix.WebData;
using System.Text;

namespace ChatRoom.Controllers
{
    public class ChatController : Controller
    {
        private ChatContext db = new ChatContext();

        //
        // GET: /Chat/Index
        [Authorize()]
        public ActionResult Index()
        {
            return View(new ChatPanel() { Chats = db.Chats.ToList(), NewChat = new Chat() });
        }
       

        // POST: /Chat/Index/
      
        //public PartialViewResult _PostForm()
        //{
        //    Chat chat = new Chat();
        //    return PartialView("_PostForm", chat);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ChatPanel panel)
        {

            if (String.IsNullOrEmpty(WebSecurity.CurrentUserName))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {

                if (String.IsNullOrEmpty(panel.NewChat.Message) == false)
                {
                    panel.NewChat.UserID = WebSecurity.CurrentUserName;
                    panel.NewChat.Time = DateTime.Now;
                    db.Chats.Add(panel.NewChat);

                    db.SaveChanges();
                    return new ContentResult()
                    {
                        Content = 

                       @"<div class=""Row""><div class=""Cell"" style=""clear:left; font-size:larger; font-weight:bold"">" + panel.NewChat.UserID + "</div>"+
                       @"<div class=""Cell"">" + panel.NewChat.Time + "</div></div>"+
                      @"<div class=""Row""><div class=""Cell  thin"" style=""width:90%; font-size:larger"">"+panel.NewChat.Message+"</div></div>"
                     //  @"<div id=""fake""></div>"
                                                };
                }
            }
            return View(new ChatPanel() { Chats = db.Chats.ToList(), NewChat = new Chat() });
        }
    }
}