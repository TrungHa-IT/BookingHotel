using HotelBooking.Models;
using Microsoft.AspNetCore.Identity;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public async Task LoginGoogle(string? returnUrl = null)
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse", new { returnUrl }) // Chuyển returnUrl đến GoogleResponse
            });
        }


        public async Task<IActionResult> GoogleResponse(string? returnUrl = null)
        {
            // Get the authentication result for Google login
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            // Extract user claims
            var claims = result.Principal?.Identities.FirstOrDefault()?.Claims;
            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var googleId = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var address = claims?.FirstOrDefault(c => c.Type == ClaimTypes.StreetAddress)?.Value;

            ViewData["ReturnUrl"] = returnUrl;


            if (googleId == null || email == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if Google data is not available
            }

            // Check if the user already exists in the database
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                // Create a new user if not found
                user = new AppUser // Ensure this matches your user model
                {
                    UserName = email,
                    Email = email,
                    Address = address,
                    Name = name // Assuming your user model has a FullName field
                };

                // Save the new user in the database
                var resultCreate = await userManager.CreateAsync(user);
                if (!resultCreate.Succeeded)
                {
                    // Handle the error (e.g., log the failure, show error message)
                    foreach (var error in resultCreate.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return RedirectToAction("Error", "Home");
                }

                // Add login information to AspNetUserLogins for external login
                var loginInfo = new UserLoginInfo(GoogleDefaults.AuthenticationScheme, googleId, "Google");
                await userManager.AddLoginAsync(user, loginInfo);
            }

            // Sign in the user
            await signInManager.SignInAsync(user, isPersistent: false);
            // Nếu có ReturnUrl, chuyển hướng về đó
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            // Redirect to the home page after successful login
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVm model, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // Nếu có ReturnUrl, chuyển hướng về đó
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    // Nếu không, chuyển hướng đến trang chủ
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt");
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
                    // Gán vai trò "User" cho tài khoản mới
                    //await userManager.AddToRoleAsync(u, "Customer");

                    // Optionally sign in the user immediately after registration
                    // await signInManager.SignInAsync(u, isPersistent: false);

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
            return RedirectToAction("Index", "Home");
        }
    }
}
