using System;
using System.Collections.Generic;
using System.Text;

namespace English.Common.Req
{
    public class StudentReq
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
