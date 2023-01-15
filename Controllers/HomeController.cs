using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Interface;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers;

public class HomeController : Controller
{

    private readonly IUserRepo _userRepo;
    private readonly ILogger<HomeController> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;


    public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager, IUserRepo userRepo)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _userRepo = userRepo;
    }

    // [HttpPost]
    // public IActionResult Register(User user)
    // {
    //     return Ok();
    // }

    [HttpGet]
    public IActionResult EditProfile()
    {
        return View();
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> DeleteAccount()
    {
        var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
        if (user != null)
        {
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest("Failed to delete User.");
            }
        }
        else
        {
            return BadRequest("Failed to delete User.");
        }

    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> EditProfile(EditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }


        var user = await _userManager.FindByIdAsync(_userManager.GetUserId(User));

        if (user == null)
        {
            return NotFound();
        }

        if (model.Email != user.Email)
        {
            string? email = model.Email;
            if (email != null)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, email);
                var setUserName = await _userManager.SetUserNameAsync(user, email);

                if (!setEmailResult.Succeeded || !setUserName.Succeeded)
                {
                    return BadRequest("Couldn't set email");
                }
            }
        }

        var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        if (!changePasswordResult.Succeeded)
        {
            return BadRequest(changePasswordResult.Errors);
        }

        await _userManager.UpdateAsync(user);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult RegisterPage()
    {
        return View();
    }

    [HttpGet]
    // public IActionResult StudentLogIn()
    // {
    //     return View();
    // }
    public IActionResult About()
    {
        return View();
    }

    [Authorize]
    public IActionResult Feed()
    {
        return View();
    }

    [Authorize]
    public IActionResult Chat()
    {
        return View();
    }

    [AllowAnonymous]
    public IActionResult Contact()
    {
        return View();
    }

    [Authorize(Roles = "Student")]
    [HttpGet]
    public async Task<IActionResult> SearchForTutor()
    {
        var tutors = await _userRepo.GetAllTutors();
        return View(tutors);
    }

    [Authorize(Roles = "Student")]
    [HttpPost]
    public async Task<IActionResult> SearchForTutor(string keyword)
    {
        var tutors = await _userRepo.GetTutorByKeyWord(keyword);
        return View(tutors);

    }
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}