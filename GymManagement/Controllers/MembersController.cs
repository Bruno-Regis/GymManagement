using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GymManagement.Controllers
{
    public class MembersController :  Controller
    {
        private readonly AppDbContext _context;
        public MembersController(AppDbContext context)
        {
            _context = context;
        }
         
        public async Task<IActionResult> Index()
        {
            var data = await _context.Members.ToListAsync();
            return View(data);
        }

        public IActionResult Create() // Show Form
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member) // Recieve data via post
        {
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var data = await _context.Members.FindAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Member member)
        {
            if (id != member.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Members.Update(member);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var data = await _context.Members.FindAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var data = await _context.Members.FindAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var data = await _context.Members.FindAsync(id);

            if (data == null)
                return NotFound();

            _context.Members.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
} 
