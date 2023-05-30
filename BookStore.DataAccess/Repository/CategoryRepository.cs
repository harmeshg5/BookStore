using BookStore.DataAccess.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;

        }


        public void Update(Category category)
        {
            dbContext.Categories.Update(category);
        }
    }
}
