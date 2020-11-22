using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLogSystem.Data.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int UserId { get; set; }

        public virtual Users User { get; set; }
    }
}