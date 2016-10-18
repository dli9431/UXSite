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
    public class QaTest
    {
        public QaTest()
        {
            Created = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int QaTestID { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual DateTime End { get; set; }

        public virtual string CreatedBy { get; set; }

        public virtual string Priority { get; set; }

        public virtual Status? Status { get; set; }

        public virtual string Title { get; set; }

        public virtual string Instructions { get; set; }

        public virtual int Reward { get; set; }

        public virtual string Steps { get; set; }

        public virtual string Feedback { get; set; }

        public virtual bool Locked { get; set; }

        public virtual bool Skipped { get; set; }

        public virtual bool Passed { get; set; }

        //nav rules
        //user
        public virtual ICollection<ApplicationUser> ApplicationUsers
        {
            get { return m_ApplicationUsers ?? (m_ApplicationUsers = new HashSet<ApplicationUser>()); }
            set { m_ApplicationUsers = value; }
        }
        private ICollection<ApplicationUser> m_ApplicationUsers;

        //attachment
        public virtual ICollection<UserAttachment> UserAttachments
        {
            get { return m_UserAttachments ?? (m_UserAttachments = new HashSet<UserAttachment>()); }
            set { m_UserAttachments = value; }
        }
        private ICollection<UserAttachment> m_UserAttachments;

        //product
        public virtual ICollection<Product> TestProduct
        {
            get { return m_Products ?? (m_Products = new HashSet<Product>()); }
            set { m_Products = value; }
        }
        private ICollection<Product> m_Products;
    }
}
