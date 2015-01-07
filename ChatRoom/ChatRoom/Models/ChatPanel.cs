using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    public class ChatPanel
    {
        public IList<Chat> Chats {get; set;}
        public Chat NewChat {get; set;}
    }
}