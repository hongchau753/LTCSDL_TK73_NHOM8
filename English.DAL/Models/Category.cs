using System;
using System.Collections.Generic;

namespace English.DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
