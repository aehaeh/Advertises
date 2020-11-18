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
            var claims = new List<Claim>();

            try
            {
                // Setting  
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdenties), new AuthenticationProperties() { IsPersistent = true }).ContinueWith(prop =>
                    {
                        RedirectToPage("/");
                    });
                // Sign In.  
                //await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = false });

            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }

    }
}