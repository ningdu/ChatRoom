using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    public class ChatContext:DbContext 
    {
        public DbSet<Chat> Chats { get; set; }
    }
}