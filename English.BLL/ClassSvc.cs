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
    public class ClassSvc : GenericSvc<ClassRep, Class>
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

        public object SearchClass(string keyword, int page, int size)
        {
            var stu = All.Where(x => x.Name.Contains(keyword));
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

        public SingleRsp CreateClass(ClassReq cls)
        {
            var res = new SingleRsp();
            Class cll = new Class();
            cll.Id = cls.Id;
            cll.Name = cls.Name;
            cll.StartDate = cls.StartDate;
            cll.Price = cls.Price;
            cll.TeacherId = cls.TeacherId;
            cll.CourseId = cls.CourseId;
            res = _rep.CreateClass(cll);
            return res;
        }

        public SingleRsp UpdateClass(ClassReq cls)
        {
            var res = new SingleRsp();
            Class cll = new Class();
            cll.Id = cls.Id;
            cll.Name = cls.Name;
            cll.StartDate = cls.StartDate;
            cll.Price = cls.Price;
            cll.TeacherId = cls.TeacherId;
            cll.CourseId = cls.CourseId;
            res = _rep.UpdateClass(cll);
            return res;
        }

        public SingleRsp DeleteClass(ClassReq cls)
        {
            var res = new SingleRsp();
            Class cll = new Class();
            cll.Id = cls.Id;
            cll.Name = cls.Name;
            cll.StartDate = cls.StartDate;
            cll.Price = cls.Price;
            cll.TeacherId = cls.TeacherId;
            cll.CourseId = cls.CourseId;
            res = _rep.DeleteClass(cll);
            return res;
        }

    }
}
