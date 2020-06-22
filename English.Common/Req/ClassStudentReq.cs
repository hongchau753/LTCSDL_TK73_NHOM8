using System;
using System.Collections.Generic;
using System.Text;

namespace English.Common.Req
{
    public class ClassStudentReq
    {
        public int Id { get; set; }
        public int? ClassId { get; set; }
        public int? StudentId { get; set; }
    }
}
