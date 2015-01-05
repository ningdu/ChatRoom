using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatRoom.Models
{
    public class User
    {
        public Int32 UserID { get; set; }
        [Required()]
        public String Name { get; set; }

        public virtual Chat Chat { get; set; }
    }
}