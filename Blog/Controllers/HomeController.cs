﻿using Blog.Data;
using Blog.Data.Repository;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            // We are getting all the posts here
            var posts = _repo.GetAllPosts();
            return View(posts);
        }

        public IActionResult Post(int id)
        {
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return View(new Post());
            }
            else
            {
                var post = _repo.GetPost((int)id);
                return View(post);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            if(post.Id > 0)
            {
                _repo.UpdatePost(post);
            }
            else
            {
                _repo.AddPost(post);
            }
           
            if(await _repo.SaveChangesAsync())
            {
                return RedirectToAction("Index");
            } 
            else
            {
                return View(post);
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}