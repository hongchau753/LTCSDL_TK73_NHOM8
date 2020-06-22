using System;
using System.Collections.Generic;

namespace English.DAL.Models
{
    public partial class Course
    {
        public Course()
        {
            Class = new HashSet<Class>();
        }

        public int Id { get; set; }
        public int? Lession { get; set; }
        public string Description { get; set; }
        public string Term { get; set; }
        public int? LevelId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Class> Class { get; set; }
    }
}
