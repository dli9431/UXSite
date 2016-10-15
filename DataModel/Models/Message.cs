using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class Message
    {
        public Message()
        {
            Created = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int MessageID { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual string Title { get; set; }

        public virtual string FromID { get; set; }

        public virtual string ToID { get; set; }

        public virtual string Body { get; set; }

        //nav rules
        public virtual ICollection<ApplicationUser> ApplicationUsers
        {
            get { return m_ApplicationUsers ?? (m_ApplicationUsers = new HashSet<ApplicationUser>()); }
            set { m_ApplicationUsers = value; }
        }
        private ICollection<ApplicationUser> m_ApplicationUsers;
    }
}
