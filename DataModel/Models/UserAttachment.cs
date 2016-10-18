using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Enums;

namespace DataModel.Models
{
    public class UserAttachment
    {
        public UserAttachment()
        {
            Created = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int UserAttachmentID { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual string Location { get; set; }

        public virtual AttachmentType? AttachmentType { get; set; }
        
        //nav rules
        //user
        public virtual ICollection<ApplicationUser> ApplicationUsers
        {
            get { return m_ApplicationUsers ?? (m_ApplicationUsers = new HashSet<ApplicationUser>()); }
            set { m_ApplicationUsers = value; }
        }
        private ICollection<ApplicationUser> m_ApplicationUsers;

        //QA Test
        public virtual ICollection<QaTest> QaTests
        {
            get { return m_QaTests ?? (m_QaTests = new HashSet<QaTest>()); }
            set { m_QaTests = value; }
        }
        private ICollection<QaTest> m_QaTests;

        //product
        public virtual ICollection<Product> TestProduct
        {
            get { return m_Products ?? (m_Products = new HashSet<Product>()); }
            set { m_Products = value; }
        }
        private ICollection<Product> m_Products;
    }
}
