using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VendorPortal.Core;
using VendorPortal.Core.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace VendorPortal.Web.Controllers
{
    public class AccountController : Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;

        //public AccountController(UserManager<IdentityUser> userManager)
        //{
        //    _userManager = userManager;
        //}
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View(new LoginViewModel());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // Replace this with your actual authentication logic
        //    //bool isAuthenticated = model.Email == "test@example.com" && model.Password == "password123";
        //    bool isAuthenticated = false;
        //   var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user != null)
        //    {
        //        if (await _userManager.CheckPasswordAsync(user, model.Password))
        //        {
        //            isAuthenticated = true;
        //        }
        //    }
        //    if (isAuthenticated)
        //    {
        //        // Add user authentication logic here
        //        var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, model.Email)
        //};
        //        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //        var principal = new ClaimsPrincipal(identity);

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
        //        {
        //            IsPersistent = model.RememberMe
        //        });

        //        return RedirectToAction("Index", "Home");
        //    }

        //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult AccessDenied()
        //{
        //    return View();
        //}

    }

}
