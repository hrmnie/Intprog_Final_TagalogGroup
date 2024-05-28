using AdventureSeekers.Data;
using AdventureSeekers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdventureSeekers.Controllers
{
    public class SeekerController(AdventureSeekersContext context) : Controller
    {
        private readonly AdventureSeekersContext _context = context;
        public async Task<IActionResult> Index()
        {
            var query = from seeker in _context.User_Seeker
                        join post in _context.User_Post on seeker.seeker_id equals post.seeker_id
                        join comment in _context.Comments on post.post_id equals comment.post_id into postComments
                        orderby post.post_id descending
                        select new SeekerWithPost
                        {
                            seeker = seeker,
                            post = post,
                            comment = _context.Comments.Where(c => c.post_id == post.post_id).ToList()
                        };

            var resultList = query.ToList();

            return View(resultList);
        }
        public async Task<IActionResult> Hiking()
        {
            var query = from seeker in _context.User_Seeker
                        join post in _context.User_Post on seeker.seeker_id equals post.seeker_id
                        join comment in _context.Comments on post.post_id equals comment.post_id into postComments
                        where post.post_categories == "Hiking"

                        select new SeekerWithPost
                        {
                            seeker = seeker,
                            post = post,
                            comment = _context.Comments.Where(c => c.post_id == post.post_id).ToList()
                        };

            var resultList = query.ToList();
       
            return View(resultList);
        }
        public async Task<IActionResult> Family()
        {
            var query = from seeker in _context.User_Seeker
                        join post in _context.User_Post on seeker.seeker_id equals post.seeker_id
                        join comment in _context.Comments on post.post_id equals comment.post_id into postComments
                        where post.post_categories == "Family Trips"

                        select new SeekerWithPost
                        {
                            seeker = seeker,
                            post = post,
                            comment = _context.Comments.Where(c => c.post_id == post.post_id).ToList()
                        };

            var resultList = query.ToList();

            return View(resultList);
        }
        public async Task<IActionResult> Bike()
        {
            var query = from seeker in _context.User_Seeker
                        join post in _context.User_Post on seeker.seeker_id equals post.seeker_id
                        join comment in _context.Comments on post.post_id equals comment.post_id into postComments
                        where post.post_categories == "Bike Trails"

                        select new SeekerWithPost
                        {
                            seeker = seeker,
                            post = post,
                            comment = _context.Comments.Where(c => c.post_id == post.post_id).ToList()
                        };

            var resultList = query.ToList();

            return View(resultList);
        }
        public async Task<IActionResult> Extreme()
        {
            var query = from seeker in _context.User_Seeker
                        join post in _context.User_Post on seeker.seeker_id equals post.seeker_id
                        join comment in _context.Comments on post.post_id equals comment.post_id into postComments
                        where post.post_categories == "Extreme Adventure"

                        select new SeekerWithPost
                        {
                            seeker = seeker,
                            post = post,
                            comment = _context.Comments.Where(c => c.post_id == post.post_id).ToList()
                        };

            var resultList = query.ToList();

            return View(resultList);
        }
        public async Task<IActionResult> Gastro()
        {
            var query = from seeker in _context.User_Seeker
                        join post in _context.User_Post on seeker.seeker_id equals post.seeker_id
                        join comment in _context.Comments on post.post_id equals comment.post_id into postComments
                        where post.post_categories == "Gastro Delights"

                        select new SeekerWithPost
                        {
                            seeker = seeker,
                            post = post,
                            comment = _context.Comments.Where(c => c.post_id == post.post_id).ToList()
                        };

            var resultList = query.ToList();

            return View(resultList);
        }

        public async Task<IActionResult> Profile()
        {
            var seekers = _context.User_Seeker.Where(c => c.seeker_id == HttpContext.Session.GetInt32("id")).FirstOrDefault();
            ViewBag.name = seekers.seeker_name;
            ViewBag.email = seekers.seeker_email;
            ViewBag.contact = seekers.seeker_contact;
            ViewBag.address = seekers.seeker_address;

            return View(await _context.User_Seeker.Join(
                _context.User_Post,
                seekers => seekers.seeker_id,
                post => post.seeker_id, (seekers, posts) => new SeekerWithPost
                {
                    seeker = seekers,
                    post = posts
                }).Where(c => c.seeker.seeker_id == HttpContext.Session.GetInt32("id")).ToListAsync());


        }
        public IActionResult EditProfile()=> View(_context.User_Seeker.Where(c => c.seeker_id == HttpContext.Session.GetInt32("id")).FirstOrDefault());

        public async Task<IActionResult> EditButton( string name, string email, string address, string contact)
        {
            var get_seeker_id = HttpContext.Session.GetInt32("id");

            var seeker = _context.User_Seeker.Where(c => c.seeker_id == get_seeker_id).FirstOrDefault();

            seeker.seeker_name = name;
            seeker.seeker_email = email;
            seeker.seeker_address = address;
            seeker.seeker_contact = contact;


            _context.User_Seeker.Update(seeker);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Edit Profile successful.";

            return RedirectToAction("Index", "Seeker");
        }

        public async Task<IActionResult> AddComment(string commentText, int postId)
        {
            Comment comment = new Comment
            {
                post_id = postId,
                comment = commentText,
                comment_name = HttpContext.Session.GetString("name"),
                comment_date =Convert.ToString( DateTime.Now)
            };
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
