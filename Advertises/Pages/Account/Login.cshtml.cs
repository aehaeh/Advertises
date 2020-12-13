using Advertises.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Advertises
{
    public class LoginModel : PageModel
    {

        private ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User MyUser
        {
            set;
            get;

        }
        public string Massege
        {
            set;
            get;
        }
        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPostAsync()
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == MyUser.UserName && x.Password == MyUser.Password);
            if (user != null)
            {
                Massege = "ورود موفق";
                await SignInUser(user.UserName, false);
                return RedirectToPage("/Index");
            }
            else
            {
                Massege = "چنین کاربرری یافت نشد";
            }

            return Page();
        }
        private async Task SignInUser(string username, bool isPersistent)
        {
            // Initialization.  
            // var claims = new List<Claim>();

            try
            {
                // Setting  
                /*claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdenties), new AuthenticationProperties() { IsPersistent = true }).ContinueWith(prop =>
                    {
                        RedirectToPage("/");
                    });*/
                
                // var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                
                /*
                var identity = new ClaimsIdentity("Custom");

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, username));
                identity.AddClaim(new Claim(ClaimTypes.Name, username));
                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal),authProperties);
                */

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var userIdentity = new ClaimsIdentity("Custom");
                userIdentity.AddClaims(claims);
                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);

                // await HttpContext.SignOutAsync();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });
                
                 RedirectToPage("/");

            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }

    }
}