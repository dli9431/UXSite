using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
//using UX.Models;
using DataModel;
using DataModel.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace UX
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(Entities.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});

            using (var oc = new Entities())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(oc));
                if (!roleManager.RoleExists("Admin"))
                {
                    var result = roleManager.Create(new IdentityRole("Admin"));
                }
                if (!roleManager.RoleExists("Tester"))
                {
                    var result = roleManager.Create(new IdentityRole("Tester"));
                }

                string adminRoleId = roleManager.FindByName("Admin").Id;

                var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(oc));
                int adminCount = userManager.Users.Count(x => x.Roles.Select(y => y.RoleId).Contains(adminRoleId));
                if (adminCount < 1)
                {
                    var defaultAdmin = new ApplicationUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "admin@UX.com",
                        EmailConfirmed = true,
                        UserName = "admin@UX.com",
                        Created = DateTime.UtcNow,
                        ApprovedSurvey = true,
                        ApprovedTest = true,
                        IsActive = true,
                        DisplayName = "admin"
                    };

                    userManager.Create(defaultAdmin, "123123");
                    userManager.AddToRole(defaultAdmin.Id, "Admin");
                    userManager.AddToRole(defaultAdmin.Id, "Tester");
                }
            }

        }
    }
}