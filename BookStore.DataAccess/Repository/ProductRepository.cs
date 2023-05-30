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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;

        }


        public void Update(Product product)
        {
            dbContext.Products.Update(product);
        }
    }
}
