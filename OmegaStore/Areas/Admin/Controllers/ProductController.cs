﻿using Microsoft.AspNetCore.Mvc;

namespace OmegaStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
