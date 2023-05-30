
using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IActionResult Index()
        {
            var prodList = unitOfWork.Product.GetAll();
            
            return View(prodList);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = unitOfWork.Category.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.CategoryId.ToString() });

            ViewBag.CategoryList = CategoryList;
            ProductViewModel productViewModel = new()
            {
                CategryList = CategoryList,
                Product = new Product()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel prod)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Add(prod.Product);
                unitOfWork.Save();
                TempData["success"] = "Product created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product category = unitOfWork.Product.Get(x => x.ProductId == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Product category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Product.Update(category);
                unitOfWork.Save();
                TempData["success"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product category = unitOfWork.Product.Get(x => x.ProductId == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product category = unitOfWork.Product.Get(x => x.ProductId == id);

            if (category == null)
            {
                return NotFound();
            }

            unitOfWork.Product.Remove(category);
            unitOfWork.Save();
            TempData["success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
