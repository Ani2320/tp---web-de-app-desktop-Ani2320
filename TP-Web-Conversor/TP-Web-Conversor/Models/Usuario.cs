using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace TP_Web_Conversor.Models
{
    public class Usuario
    {
        public string user { get; set; }
        public string password { get; set; }

        public Usuario(string user, string pass)
        {
            this.user = user;
            this.password = pass;
        }
    }
}
