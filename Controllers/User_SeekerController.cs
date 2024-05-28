using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdventureSeekers.Data;
using AdventureSeekers.Models;

namespace AdventureSeekers.Controllers
{
    public class User_SeekerController : Controller
    {
        private readonly AdventureSeekersContext _context;

        public User_SeekerController(AdventureSeekersContext context)
        {
            _context = context;
        }

        // GET: User_Seeker
        public async Task<IActionResult> Index()
        {
            return View(await _context.User_Seeker.ToListAsync());
        }

        // GET: User_Seeker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Seeker = await _context.User_Seeker
                .FirstOrDefaultAsync(m => m.seeker_id == id);
            if (user_Seeker == null)
            {
                return NotFound();
            }

            return View(user_Seeker);
        }

        // GET: User_Seeker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User_Seeker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("seeker_id,seeker_name,seeker_email,seeker_contact,seeker_address")] User_Seeker user_Seeker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user_Seeker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user_Seeker);
        }

        // GET: User_Seeker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Seeker = await _context.User_Seeker.FindAsync(id);
            if (user_Seeker == null)
            {
                return NotFound();
            }
            return View(user_Seeker);
        }

        // POST: User_Seeker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("seeker_id,seeker_name,seeker_email,seeker_contact,seeker_address")] User_Seeker user_Seeker)
        {
            if (id != user_Seeker.seeker_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Seeker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_SeekerExists(user_Seeker.seeker_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user_Seeker);
        }

        // GET: User_Seeker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Seeker = await _context.User_Seeker
                .FirstOrDefaultAsync(m => m.seeker_id == id);
            if (user_Seeker == null)
            {
                return NotFound();
            }

            return View(user_Seeker);
        }

        // POST: User_Seeker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var user_Seeker = await _context.User_Seeker.FindAsync(id);
            if (user_Seeker != null)
            {
                _context.User_Seeker.Remove(user_Seeker);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_SeekerExists(int? id)
        {
            return _context.User_Seeker.Any(e => e.seeker_id == id);
        }
    }
}
