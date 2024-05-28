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
    public class User_PostController : Controller
    {
        private readonly AdventureSeekersContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public User_PostController(AdventureSeekersContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: User_Post
        public async Task<IActionResult> Index()
        {
            var adventureSeekersContext = _context.User_Post.Include(u => u.User_Seekers);
            return View(await adventureSeekersContext.ToListAsync());
        }

        // GET: User_Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Post = await _context.User_Post
                .Include(u => u.User_Seekers)
                .FirstOrDefaultAsync(m => m.post_id == id);
            if (user_Post == null)
            {
                return NotFound();
            }

            return View(user_Post);
        }

        // GET: User_Post/Create
        public IActionResult Create()
        {
            ViewData["seeker_id"] = new SelectList(_context.User_Seeker, "seeker_id", "seeker_name");
            return View();
        }

        // POST: User_Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile? post_image, string post_title, string post_caption, string post_location, string post_categories)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (post_image != null && post_image.Length > 0)
                    {

                        string uniqueFileName = post_image + "_" + post_image.FileName;


                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "upload");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await post_image.CopyToAsync(fileStream);
                        }


                        User_Post post = new User_Post
                        {
                            post_title = post_title,
                            post_caption = post_caption,
                            post_location = post_location,
                            seeker_id = (int)HttpContext.Session.GetInt32("id"),
                            post_categories = post_categories,
                            post_image = "/upload/" + uniqueFileName,

                        };


                        _context.Add(post);

                        await _context.SaveChangesAsync();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {

                        ModelState.AddModelError("image", "Please select an image file.");
                    }

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Error");

                    return View();
                }
            }
            return RedirectToAction("Index", "Seeker");
        }

        // GET: User_Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Post = await _context.User_Post.FindAsync(id);
            if (user_Post == null)
            {
                return NotFound();
            }
            ViewData["seeker_id"] = new SelectList(_context.User_Seeker, "seeker_id", "seeker_name", user_Post.seeker_id);
            return View(user_Post);
        }

        // POST: User_Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("post_id,post_title,post_caption,post_location,post_categories")] User_Post user_Post)
        {
            if (id != user_Post.post_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user_Post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User_PostExists(user_Post.post_id))
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
            ViewData["seeker_id"] = new SelectList(_context.User_Seeker, "seeker_id", "seeker_name", user_Post.seeker_id);
            return View(user_Post);
        }

        // GET: User_Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user_Post = await _context.User_Post
                .Include(u => u.User_Seekers)
                .FirstOrDefaultAsync(m => m.post_id == id);
            if (user_Post == null)
            {
                return NotFound();
            }

            return View(user_Post);
        }

        // POST: User_Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user_Post = await _context.User_Post.FindAsync(id);
            if (user_Post != null)
            {
                _context.User_Post.Remove(user_Post);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User_PostExists(int id)
        {
            return _context.User_Post.Any(e => e.post_id == id);
        }
    }
}
