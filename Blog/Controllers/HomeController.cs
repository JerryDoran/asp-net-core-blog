using Blog.Data;
using Blog.Data.Repository;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Post());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            _repo.Add(post);
            if(await _repo.SaveChangesAsync() == 1)
            {
                return RedirectToAction("Index");
            } else
            {
                return View(post);
            }
           
        }

        [HttpGet]
        public IActionResult EditUser()
        {
            return View(new User());
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            _repo.Users.Add(user);
            if (await _repo.SaveChangesAsync() == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(user);
            }
        }
    }
}