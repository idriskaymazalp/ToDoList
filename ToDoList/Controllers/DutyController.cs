using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    public class DutyController : Controller 
    {
        private readonly IDutyRepository _repository;
        protected readonly AppDbContext _context;


        public DutyController(IDutyRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dutyList = _repository.GetList(x => x.IsCompleted == false);
            return View(dutyList);
        }

        public async Task<IActionResult> Create()
        {
            var duties = await _repository.GetList();
            ViewBag.dutyList = duties;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Duty entity)
        {
            
            if (entity == null) 
            {
                throw new Exception("Bu Alan Boş Bırakılamaz!");
            }
            else 
            {
                await _repository.AddAsync(entity);
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public async Task <IActionResult> Done(int id)
        {
            var duty = await _repository.GetByIdAsync(id);

            if (duty != null)
            {
                duty.IsCompleted = true;
                await _repository.Save();
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int id)
        {
            var duty = await _repository.GetByIdAsync(id);
            ViewBag.duty = duty;
            return View(duty);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Duty entity)
        {
            if (entity == null)
            {
                throw new Exception("Bu Alan Boş Bırakılamaz!");
            }
            else
            {
                _repository.Update(entity);
                return RedirectToAction(nameof(Index));
            }
            
        }
        public async Task<IActionResult> Remove(int id)
        {
            var entityToBeDeleted = await _repository.GetByIdAsync(id);
            await _repository.Remove(entityToBeDeleted);
            return RedirectToAction(nameof(Index));
        }
    }
}
