using System;
using System.Collections.Generic;

namespace English.DAL.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassStudent = new HashSet<ClassStudent>();
            ClassWeekday = new HashSet<ClassWeekday>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? Price { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<ClassStudent> ClassStudent { get; set; }
        public virtual ICollection<ClassWeekday> ClassWeekday { get; set; }
    }
}
