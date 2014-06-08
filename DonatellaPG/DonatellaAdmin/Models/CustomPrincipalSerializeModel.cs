using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonatellaAdmin.Models
{
    public class CustomPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
    }
}