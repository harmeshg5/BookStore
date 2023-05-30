using BookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext _dbContext) 
        {
            dbContext = _dbContext;
            Category = new CategoryRepository(dbContext);
            Product = new ProductRepository(dbContext);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
