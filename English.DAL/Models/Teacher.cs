using System;
using System.Collections.Generic;

namespace English.DAL.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Class = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
