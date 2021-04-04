using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBookList.Model;

namespace RazorBookList.Pages.BooList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public CreateModel(ApplicationDbContext db)
        {
            dbContext = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await dbContext.Book.AddAsync(Book);
                await dbContext.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
