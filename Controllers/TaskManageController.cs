using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagement.Controllers
{
    public class TaskManageController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        
        public TaskManageController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm)
        {
            var data = _db.TaskManage.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchTerm)){
                data = data.Where(t => t.TaskTitle.Contains(searchTerm));
            }

            return View(data.ToList());
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreateTask()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskManage data)
        {
                var user = await _userManager.GetUserAsync(User);
                data.CreatedById = user.Id;
                data.CreatedByName = user.UserName;
            if (ModelState.IsValid)
            {
                _db.TaskManage.Add(data);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditTask(int id)
        {
            var data = await _db.TaskManage.FindAsync(id);
            return View(data);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditTask(TaskManage t)
        {
            var preData = await _db.TaskManage.FindAsync(t.Id);

            var user = await _userManager.GetUserAsync(User);
            preData.UpdatedById = user.Id;
            preData.UpdatedByName = user.UserName;
            preData.UpdatedOn = DateTime.Now;

            preData.TaskTitle = t.TaskTitle;
            preData.TaskDescription = t.TaskDescription;
            preData.TaskRemarks = t.TaskRemarks;
            preData.TaskStatus = t.TaskStatus;
            preData.TaskDueDate = t.TaskDueDate;
            

            _db.TaskManage.Update(preData);
            await _db.SaveChangesAsync();
            return RedirectToAction("TaskDetails", new { id = preData.Id });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var data = await _db.TaskManage.FindAsync(id);
            //if(data == null) { return ; }
            _db.TaskManage.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> TaskDetails(int id)
        {
            var data = await _db.TaskManage.FindAsync(id);
            return View(data);
        }
    }
}
