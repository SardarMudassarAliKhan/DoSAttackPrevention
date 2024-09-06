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

        public IActionResult Login()
        {
            ViewBag.Request = Request;
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
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
