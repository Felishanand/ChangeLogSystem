using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLogSystem.Data.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Login Login { get; set; }
    }
}