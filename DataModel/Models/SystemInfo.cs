using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class SystemInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int SystemInfoID { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual string Processor { get; set; }

        public virtual string RAM { get; set; }

        public virtual string OS { get; set; }

        public virtual string GfxCard { get; set; }

        public virtual string SoundCard { get; set; }

        //nav rules
        public virtual ICollection<ApplicationUser> ApplicationUsers
        {
            get { return m_ApplicationUsers ?? (m_ApplicationUsers = new HashSet<ApplicationUser>()); }
            set { m_ApplicationUsers = value; }
        }
        private ICollection<ApplicationUser> m_ApplicationUsers;
    }
}
