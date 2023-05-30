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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public Category category { get; set; }

        public DeleteModel(ApplicationDbContext _dbContext)
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
            Category? categoryObj = dbContext.Categories.Find(category.Id);
            if (categoryObj!= null)
            {
                dbContext.Categories.Remove(categoryObj);
                dbContext.SaveChanges();
                TempData["success"] = "Category deleted successfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
