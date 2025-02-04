using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TODO.Context;
using TODO.Models;
using TODO.Repositories.Interfaces;

namespace TODO.Controllers
{
    public class TasksController : Controller
    {
        private readonly TodoDbContext _context;
        private readonly ITasksRepository _taskRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public TasksController(TodoDbContext context, ITasksRepository taskRepository, ICategoriesRepository categoriesRepository)
        {
            _context = context;
            _taskRepository = taskRepository;
            _categoriesRepository = categoriesRepository;
        }

       
        public async Task<IActionResult> Index()
        {
            var data = await _taskRepository.GetAllTasksAsync();
            return View(data);
        }
        
        public async Task<IActionResult> Create()
        {
            var allCategories = await _categoriesRepository.GetAllCategoriesAsync();

            ViewBag.Categories = allCategories;

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,Description,CategoriesId, IsCompleted")] Tasks task)
        {
           
            if (ModelState.IsValid)
            {
                _taskRepository.AddTask(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

      
        public async Task<IActionResult> Edit(Guid? id)
        {
            //Fetching all records of Categories table
            var allCategories = await _categoriesRepository.GetAllCategoriesAsync();
            ViewBag.Categories = allCategories;

            if (id == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            return View(tasks);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Tasks tasks)
        {

            if (ModelState.IsValid)
            {
                _taskRepository.UpdateTask(tasks);
                return RedirectToAction("Index", "Tasks");
            }
            return View(tasks);
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != null)
            {
                _taskRepository.DeleteTask(id);
            }
            return RedirectToAction("Index", "Tasks");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(Guid id, bool isCompleted)
        {
            await _taskRepository.UpdateStatusById(id, isCompleted);
            return RedirectToAction("Index", "Tasks");
        }
    }
}
