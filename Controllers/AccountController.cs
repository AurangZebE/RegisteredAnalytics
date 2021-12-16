using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisteredAnalytics.Models;


namespace RegisteredAnalytics.Controllers
{
    public class AccountController : Controller
    {
        private object httpContext;

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return LocalRedirect("/Dashboard/Index");
            }
            else {
                return View();
            }
            
        }
        public async Task<ActionResult> LogOut() {
            if (User.Identity.IsAuthenticated)
            {
                await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);
                return LocalRedirect("/Account/Login");
            }
            else
            {
                return View();
            }
        }
        public async Task<bool> VerifyUser(string username, string password)
        {
            AppUser objUser = new AppUser();
            objUser.initUserData();
            bool hasUser = objUser.VerifyUser(username, password, out string id);
            var claim = new Claim(username,id);
            var claims = new List<Claim> { new Claim(username, id) };
            var identity = new ClaimsIdentity(claims,"form");
            ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
            await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(HttpContext,userPrincipal);
            return hasUser;
        }

        [HttpPost]
        public ActionResult Edit(AppUser objUser)
        {
            AppUser oUser = new AppUser();
            oUser.initUserData();
            oUser.UpdateUser(objUser);
            return View();
        }

        

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
