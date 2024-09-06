using Microsoft.AspNetCore.Mvc;
using reCAPTCHA.AspNetCore;

namespace DoSAttackPrevention.Controllers
{
    public class HomeController : Controller
    {

            private readonly IRecaptchaService _recaptcha;

            public HomeController(IRecaptchaService recaptcha)
            {
                _recaptcha = recaptcha;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(string username, string password)
            {
                var recaptchaResult = await _recaptcha.Validate(Request);
                if (!recaptchaResult.success)
                {
                    ModelState.AddModelError(string.Empty, "CAPTCHA validation failed.");
                    return View();
                }

                if (username == "admin" && password == "password") 
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            public IActionResult Index()
            {
                return View();
            }
        }
  }

