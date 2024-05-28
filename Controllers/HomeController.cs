using AdventureSeekers.Data;
using AdventureSeekers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdventureSeekers.Controllers
{
    public class HomeController(ILogger<HomeController> logger, AdventureSeekersContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login() => View();
        public IActionResult Register() => View();
        public async Task<IActionResult> LoginButton(string email, string password)
        {
            if (email.CompareTo("admin123@gmail.com") == 0 && password.CompareTo("admin") == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                var seekers = _context.User_Seeker.Where(c => c.seeker_email == email && c.seeker_password == password).FirstOrDefault();

                if (seekers != null)
                {
                    HttpContext.Session.SetString("name", seekers.seeker_name);
                    HttpContext.Session.SetInt32("id", (int)seekers.seeker_id);
                    return RedirectToAction("Index", "Seeker");
                }
                else
                {
                    TempData["invalidLogin"] = "Incorrect email and password.";

                    return RedirectToAction("Login", "Home");
                }
            }

        }
        public async Task<IActionResult> RegisterButton(string name, string email, string contact, string address, string password)
        {
            User_Seeker seeker = new User_Seeker { seeker_name = name, seeker_email = email, seeker_contact = contact, seeker_address = address, seeker_password = password };
            _context.User_Seeker.Add(seeker);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Registration successful. You can now login with your credentials.";

            return RedirectToAction("Login", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}