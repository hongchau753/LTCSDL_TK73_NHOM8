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
    public class TeacherSvc : GenericSvc<TeacherRep, Teacher>
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

        public object SearchTeacher(string keyword, int page, int size)
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

        public SingleRsp CreateTeacher(TeacherReq tea)
        {
            var res = new SingleRsp();
            Teacher teacher = new Teacher();
            teacher.Id = tea.Id;
            teacher.Fullname = tea.Fullname;
            teacher.Email = tea.Email;
            teacher.Phone = tea.Phone;
            teacher.Description = tea.Description;
            res = _rep.CreateTeacher(teacher);
            return res;
        }

        public SingleRsp UpdateTeacher(TeacherReq tea)
        {
            var res = new SingleRsp();
            Teacher teacher = new Teacher();
            teacher.Id = tea.Id;
            teacher.Fullname = tea.Fullname;
            teacher.Email = tea.Email;
            teacher.Phone = tea.Phone;
            teacher.Description = tea.Description;
            res = _rep.UpdateTeacher(teacher);
            return res;
        }

        public SingleRsp DeleteTeacher(TeacherReq tea)
        {
            var res = new SingleRsp();
            Teacher teacher = new Teacher();
            teacher.Id = tea.Id;
            teacher.Fullname = tea.Fullname;
            teacher.Email = tea.Email;
            teacher.Phone = tea.Phone;
            teacher.Description = tea.Description;
            res = _rep.DeleteTeacher(teacher);
            return res;
        }
    }
}
