using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using CongresoServer.Data;
using CongresoServer.Model;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CongresoServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public AccountController(
            IDataProtectionProvider dataProtectionProvider,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext applicationDbContext
        )
        {
            _dataProtectionProvider = dataProtectionProvider;
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = applicationDbContext;
        }

        [HttpGet("/Account/LoginInternal")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginInternal(string User, string Password, bool RememberMe)
        {
            var identityUser = await _userManager.FindByEmailAsync(User);
            var test = await _signInManager.PasswordSignInAsync(identityUser, Password, RememberMe, false);
            var role = await _userManager.GetRolesAsync(identityUser);
            if (!role.Contains("SysAdmin"))
            {
                return Redirect("/Agenda");
            }
            else
            {
                return Redirect("/Subscriptions");
            }
        }
        [HttpGet("/Account/LogOut")]
        [AllowAnonymous]
        public async Task<IActionResult> LogOut(string token)
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Login");
        }
    }
}
