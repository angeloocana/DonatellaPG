using System.Collections.Generic;
using Donatella.Models.Enums;

namespace Donatella.Models.Login
{
    public class UsuarioLogadoViewModel
    {
        public int UserId { get; set; }
        public int LogId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
    }
}