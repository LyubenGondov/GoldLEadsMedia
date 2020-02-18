using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiAplication.Data;
using WebApiAplication.Models;

namespace WebApiAplication.Controllers
{
    [Route("api/[Controller]")]
    public class ContragentsController : Controller
    {
        private Context _context;
        public ContragentsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Contragents> GetContragents()
        {
            return _context.contragents.ToList();
        }

        [HttpGet("{Id}")]
        public Contragents GetContragents(int Id)
        {
            var contragent = _context.contragents.Where(a => a.ContragentsId == Id).FirstOrDefault();
            return contragent;
        }

        [HttpPost]
        public IActionResult PostContragents([FromBody] Contragents contragent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            _context.contragents.Add(contragent);
            _context.SaveChanges();
            return Ok();
        }


}
}