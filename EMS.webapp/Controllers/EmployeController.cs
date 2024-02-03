using EMS.webapp.DatabaseContext;
using EMS.webapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.webapp.Controllers
{
    public class EmployeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data=await _context.Set<Employe>().AsNoTracking().ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult>CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Employe());
            }
            else
            {
                var data=await _context.Set<Employe>().FirstOrDefaultAsync(x=>x.id==id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(int id,Employe employe)
        {
            //save
            if (id == 0)
            {
                if(ModelState.IsValid)
                {
                    await _context.Set<Employe>().AddAsync(employe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));   
                }
            }
            //update
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Set<Employe>().Update(employe);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
            }
            return View(employe);
        }
        //Delete
        public async Task<IActionResult>Delete(int id)
        {
            if(id != 0)
            {
                var data = await _context.Set<Employe>().FindAsync(id);
                if(data is not null)
                {
                    _context.Set<Employe>().Remove(data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult>Details(int id)
        {
            var data = await _context.Set<Employe>().FindAsync(id);
            return View(data);
        }


    }
}
