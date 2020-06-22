using System;
using System.Collections.Generic;
using System.Text;

namespace English.Common.Req
{
    public class ClassReq
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public decimal? Price { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }

    }
}
