using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiAplication.Models
{
    public class Contragents
    {
        public int ContragentsId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string DDS { get; set; }
    }
}
