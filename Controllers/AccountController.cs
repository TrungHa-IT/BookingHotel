using HotelBooking.Models;
using Microsoft.AspNetCore.Identity;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace HotelBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public IActionResult Login()
        {
            return View();
        }

        public async Task LoginGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse")
                });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Check if the authentication result is successful and has a principal
            if (result.Succeeded && result.Principal != null)
            {
                var claims = result.Principal.Identities.FirstOrDefault()?.Claims.ToList();

                // Extract email claim
                var emailClaim = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                if (emailClaim != null)
                {
                    var email = emailClaim.Value;

                    // Check if user already exists
                    var user = await userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        // User exists, sign them in
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // User does not exist, create a new user
                        var newUser = new AppUser
                        {
                            Email = email,
                            UserName = claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value,
                            PhoneNumber = claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value
                        };

                        var resultCreate = await userManager.CreateAsync(newUser);
                        if (resultCreate.Succeeded)
                        {
                            await signInManager.SignInAsync(newUser, isPersistent: false);
                            return RedirectToAction("Index", "Home");
                        }
                        foreach (var error in resultCreate.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }

            // Handle the case when authentication fails
            ModelState.AddModelError("", "Google authentication failed.");
            return View("Login"); // or any appropriate view
        }




        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVm model)
        {
            if (ModelState.IsValid)
            {
                //Login
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attempt");
                return View(model);
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser u = new()
                {
                   Name = model.LastName,
                   UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address
                };

                var result = await userManager.CreateAsync(u, model.Password!);
                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(u, false);
                    return RedirectToAction("Login", "Account"); 
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
