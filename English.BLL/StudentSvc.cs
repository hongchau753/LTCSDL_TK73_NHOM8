using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using English.Common.BLL;
using English.Common.Req;
using English.Common.Rsp;
using English.DAL;
using English.DAL.Models;
namespace English.BLL
{
    public class StudentSvc : GenericSvc<StudentRep, Student>
    {
        #region --Override--
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        #endregion

        public object SearchStudent (string keyword, int page, int size)
        {
            var stu = All.Where(x => x.Fullname.Contains(keyword));
            var offset = (page - 1) * size;
            var total = stu.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = stu.OrderBy(x => x.Id).Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                Page = page,
                Size = size

            };
            return res;
        }

        public SingleRsp CreateStudent(StudentReq stu)
        {
            var res = new SingleRsp();
            Student student = new Student();
            student.Id = stu.Id;
            student.Fullname = stu.Fullname;
            student.DateBirth = stu.DateBirth;
            student.Address = stu.Address;
            student.Email = stu.Email;
            student.Phone = stu.Phone;
            res = _rep.CreateStudent(student);
            return res;
        }

        public SingleRsp UpdateStudent(StudentReq stu)
        {
            var res = new SingleRsp();
            Student student = new Student();
            student.Id = stu.Id;
            student.Fullname = stu.Fullname;
            student.DateBirth = stu.DateBirth;
            student.Address = stu.Address;
            student.Email = stu.Email;
            student.Phone = stu.Phone;
            res = _rep.UpdateStudent(student);
            return res;
        }

        public SingleRsp DeleteStudent(StudentReq stu)
        {
            var res = new SingleRsp();
            Student student = new Student();
            student.Id = stu.Id;
            student.Fullname = stu.Fullname;
            student.DateBirth = stu.DateBirth;
            student.Address = stu.Address;
            student.Email = stu.Email;
            student.Phone = stu.Phone;
            res = _rep.DeleteStudent(student);
            return res;
        }

    }
}
