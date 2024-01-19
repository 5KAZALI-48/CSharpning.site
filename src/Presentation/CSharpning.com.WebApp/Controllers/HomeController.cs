using CSharpning.com.WebApp.Extentions;
using CSharpning.com.WebApp.Models;
using CSharpning.com.WebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace CSharpning.com.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Member");
        }
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    public IActionResult SignIn(string ReturnUrl)
    {
        TempData["ReturnUrl"] = ReturnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl = null)
    {
        returnUrl ??= Url.Action("Index", "Home");
        var hasUser = await _userManager.FindByEmailAsync(model.Email);

        if (hasUser == null)
        {
            ModelState.AddModelError(String.Empty, "Email or Password is wrong");
            return View();
        }

        var signInResult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);

        if (signInResult.Succeeded)
        {
            return Redirect(returnUrl);
        }

        if (signInResult.IsLockedOut)
        {
            ModelState.AddModelErrorList([$"Your Account is locked, please try 3 minutes later."]);
            return View();

        }
        ModelState.AddModelErrorList(
        [
                "Email or password is wrong"
        ]);
        ModelState.AddModelErrorList([
                $"Email or password is wrong",$"Failed= {await _userManager.GetAccessFailedCountAsync(hasUser)}" ]);
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
   

