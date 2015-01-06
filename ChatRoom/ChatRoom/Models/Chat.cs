using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    public class Chat
    {
        public Int32 ChatID { get; set; }

        public String UserID { get; set; }

        public DateTime Time { get; set; }
       
        [Required()]
        [DataType(DataType.MultilineText)]
        public String Message { get; set; }
    }
}