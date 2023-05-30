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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        
        
        public Category category { get; set; }

        public CreateModel(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            TempData["success"] = "Category created successfully.";
            return RedirectToPage("Index");
        }
    }
}
