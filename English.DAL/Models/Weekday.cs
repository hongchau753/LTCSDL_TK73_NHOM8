using System;
using System.Collections.Generic;

namespace English.DAL.Models
{
    public partial class Weekday
    {
        public Weekday()
        {
            ClassWeekday = new HashSet<ClassWeekday>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ClassWeekday> ClassWeekday { get; set; }
    }
}
