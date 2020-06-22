using System;
using System.Collections.Generic;

namespace English.DAL.Models
{
    public partial class ClassWeekday
    {
        public int ClassId { get; set; }
        public int WeekdayId { get; set; }
        public string Hour { get; set; }

        public virtual Class Class { get; set; }
        public virtual Weekday Weekday { get; set; }
    }
}
