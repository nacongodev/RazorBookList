using Microsoft.AspNetCore.Mvc;
using RazorBookList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorBookList.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {

        ApplicationDbContext dbContext;

       
        public BookController(ApplicationDbContext db)
        {
            dbContext = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = dbContext.Book.ToList()});
        }
    }
}
