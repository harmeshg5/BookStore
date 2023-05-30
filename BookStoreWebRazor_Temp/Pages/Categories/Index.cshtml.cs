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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public List<Category> CategoryList { get; set; }
        
        public IndexModel(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public void OnGet()
        {
            CategoryList = dbContext.Categories.ToList();
        }
    }
}
