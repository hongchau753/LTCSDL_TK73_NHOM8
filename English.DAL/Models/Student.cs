using System;
using System.Collections.Generic;

namespace English.DAL.Models
{
    public partial class Student
    {
        public Student()
        {
            ClassStudent = new HashSet<ClassStudent>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<ClassStudent> ClassStudent { get; set; }
    }
}
