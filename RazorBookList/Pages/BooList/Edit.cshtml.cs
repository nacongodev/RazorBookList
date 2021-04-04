using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBookList.Model;

namespace RazorBookList.Pages.BooList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext dbContext;

        public EditModel(ApplicationDbContext db)
        {
            dbContext = db;
        }
        [BindProperty]

        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await dbContext.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var Books = await dbContext.Book.FindAsync(Book.Id);
                Books.Name = Book.Name;
                Books.Author = Book.Author;
                Books.ISBN = Book.ISBN;

                await dbContext.SaveChangesAsync();

                return RedirectToPage("index");
            }
            return RedirectToPage("index");
        }
    }
}
