using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebRazor_Temp.Data;
using BookStoreWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category category { get; set; }

        public EditModel(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                category = dbContext.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(category);
                dbContext.SaveChanges();
                TempData["success"] = "Category updated successfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
