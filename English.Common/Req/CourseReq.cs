using System;
using System.Collections.Generic;
using System.Text;

namespace English.Common.Req
{
    public class CourseReq
    {
        public int Id { get; set; }
        public int? Lession { get; set; }
        public string Description { get; set; }
        public string Term { get; set; }
        public int? LevelId { get; set; }
        public int? CategoryId { get; set; }
    }
}
