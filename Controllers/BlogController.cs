using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace HotelBooking.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepositories _blogRepositories ;

        public BlogController(IBlogRepositories blogRepositories)
        {
            _blogRepositories = blogRepositories;
        }
        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogRepositories.GetAllBlogAsync();
            return View(blogs);
        }

        public  IActionResult CreateBlog()
        {
            return  View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBlog(Blog blogs)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // Get current user's ID
                blogs.AppUserId = userId;  
                blogs.CreateAt = DateTime.Now; 
                blogs.UpdateAt = DateTime.Now; 
                await _blogRepositories.CreateBlogAsync(blogs);
                return RedirectToAction("Index", "Blog");
            }
            return RedirectToAction("CreateBlog", "Blog"); ;
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blogRepositories.GetBlogByIdAsync(id.Value);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }
    }
}
