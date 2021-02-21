using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Geek_Inside.Models
{
    public class HomeModel
    {
        // nombre,telefono,email,descripcion
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }


    }
}