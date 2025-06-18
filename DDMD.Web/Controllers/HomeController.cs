using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DDMD.Web.Models;
using DDMD.Web.Data;

namespace DDMD.Web.Controllers;

public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;

            // ✅ Seed only if the table is empty
            if (!_db.Posts.Any())
            {
                _db.Posts.AddRange(new[]
                {
                    new Post { Content = "Mit første opslag!", Author = "Jonas", Likes = 3 },
                    new Post { Content = "Hej med dig!", Author = "Marvin", Likes = 5, ImageUrl = "/images/1c631da8.png" },
                    new Post { Content = "Test igen", Author = "Guest123" }
                });
                _db.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            var posts = _db.Posts
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedAt = DateTime.Now;
                _db.Posts.Add(post);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        
            return View(post);
        }
        

    public IActionResult Om() => View();

    public IActionResult FAQ() => View();

    public IActionResult Politik() => View();

    public IActionResult Galleri() => View();

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
