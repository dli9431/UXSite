using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //maybe need to override?
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, )
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}

        public ApplicationUser()
        {
            Created = DateTime.UtcNow;
        }
        
        //account info
        public virtual DateTime Created { get; set; }
        public virtual string Picture { get; set; }
        public virtual string DisplayName { get; set; }
        
        //survey/test info
        public virtual bool ApprovedTest { get; set; }
        public virtual bool ApprovedSurvey { get; set; }

        //admin info
        public virtual bool IsActive { get; set; }
                
        //nav rules

        //products
        public virtual ICollection<Product> TestProduct
        {
            get { return m_Products ?? (m_Products = new HashSet<Product>()); }
            set { m_Products = value; }
        }
        private ICollection<Product> m_Products;

        //system info
        public virtual SystemInfo SystemInfo { get; set; }
        
        //messages
        public virtual ICollection<Message> Messages
        {
            get { return m_Messages ?? (m_Messages = new HashSet<Message>()); }
            set { m_Messages = value; }
        }
        private ICollection<Message> m_Messages;

        //QA Test
        public virtual ICollection<QaTest> QaTests
        {
            get { return m_QaTests ?? (m_QaTests = new HashSet<QaTest>()); }
            set { m_QaTests = value; }
        }
        private ICollection<QaTest> m_QaTests;

    }
}
