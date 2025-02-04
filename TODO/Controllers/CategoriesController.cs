using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TODO.Context;
using TODO.Models;
using TODO.Repositories;
using TODO.Repositories.Interfaces;

namespace TODO.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly TodoDbContext _context;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository, TodoDbContext context)
        {
            _categoriesRepository = categoriesRepository;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var data = await _categoriesRepository.GetAllCategoriesAsync();
            return View(data);
        }

        public async Task<IActionResult> TasksByCategory(Guid id, string categoryName)
        {
            ViewBag.CategoryName = categoryName;    
            var data = await _categoriesRepository.GetTaskByCategoriesId(id);
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriesId,CategoriesName")] Categories category)
        {
            if (ModelState.IsValid)
            {
                _categoriesRepository.AddCategories(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories.FindAsync(id);

            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoriesId,CategoriesName")] Categories categories)
        {
            if (id != categories.CategoriesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(categories);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Categories");
            }
            return View(categories);
        }

        
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != null)
            {
                _categoriesRepository.DeleteCategories(id);
            }
            return RedirectToAction("Index", "Categories");
        }
    }
}
