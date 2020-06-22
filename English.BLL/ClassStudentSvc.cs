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
    public class ClassStudentSvc : GenericSvc<ClassStudentRep, ClassStudent>
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

        public object SearchClassStudent(string keyword, int page, int size)
        {
            var stu = All.Where(x => x.ClassId.Equals(page));
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

        public SingleRsp CreateClassStudent(ClassStudentReq clt)
        {
            var res = new SingleRsp();
            ClassStudent classstudent = new ClassStudent();
            classstudent.Id = clt.Id;
            classstudent.ClassId = clt.ClassId;
            classstudent.StudentId = clt.StudentId;
            res = _rep.CreateClassStudent(classstudent);
            return res;
        }

        public SingleRsp UpdateClassStudent(ClassStudentReq clt)
        {
            var res = new SingleRsp();
            ClassStudent classstudent = new ClassStudent();
            classstudent.Id = clt.Id;
            classstudent.ClassId = clt.ClassId;
            classstudent.StudentId = clt.StudentId;
            res = _rep.UpdateClassStudent(classstudent);
            return res;
        }

        public SingleRsp DeleteClassStudent(ClassStudentReq clt)
        {
            var res = new SingleRsp();
            ClassStudent classstudent = new ClassStudent();
            classstudent.Id = clt.Id;
            classstudent.ClassId = clt.ClassId;
            classstudent.StudentId = clt.StudentId;
            res = _rep.DeleteClassStudent(classstudent);
            return res;
        }
    }
}
