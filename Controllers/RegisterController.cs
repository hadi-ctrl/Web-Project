using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.ViewModels;


namespace Project.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterStudent(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    UserName = model.Email, 
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Major = model.Major,
                    Gender = model.Gender,
                    UserType = "Student"
                };
                
                var result = await _userManager.CreateAsync(newUser, model.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Student");
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);

        }
        
        [HttpGet]
        public IActionResult RegisterTutor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTutor(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser
                {
                    UserName = model.Email, 
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Major = model.Major,
                    Gender = model.Gender,
                    UserType = "Tutor"
                };
                
                var result = await _userManager.CreateAsync(newUser, model.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Tutor");
                    await _signInManager.SignInAsync(newUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);

        }
    }
}