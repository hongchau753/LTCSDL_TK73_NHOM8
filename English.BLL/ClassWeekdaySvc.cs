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
    public class ClassWeekdaySvc : GenericSvc<ClassWeekdayRep, ClassWeekday>
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

        public object SearchClassWeekday(string keyword, int page, int size)
        {
            var stu = All.Where(x => x.Hour.Contains(keyword));
            var offset = (page - 1) * size;
            var total = stu.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = stu.OrderBy(x => x.ClassId).Skip(offset).Take(size).ToList();
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

        public SingleRsp CreateClassWeekday(ClassWeekdayReq cw)
        {
            var res = new SingleRsp();
            ClassWeekday classweekday = new ClassWeekday();
            classweekday.ClassId = cw.ClassId;
            classweekday.WeekdayId = cw.WeekdayId;
            classweekday.Hour = cw.Hour;
            res = _rep.CreateClassWeekday(classweekday);
            return res;
        }

        public SingleRsp UpdateClassWeekday(ClassWeekdayReq cw)
        {
            var res = new SingleRsp();
            ClassWeekday classweekday = new ClassWeekday();
            classweekday.ClassId = cw.ClassId;
            classweekday.WeekdayId = cw.WeekdayId;
            classweekday.Hour = cw.Hour;
            res = _rep.UpdateClassWeekday(classweekday);
            return res;
        }

        public SingleRsp DeleteClassWeekday(ClassWeekdayReq cw)
        {
            var res = new SingleRsp();
            ClassWeekday classweekday = new ClassWeekday();
            classweekday.ClassId = cw.ClassId;
            classweekday.WeekdayId = cw.WeekdayId;
            classweekday.Hour = cw.Hour;
            res = _rep.DeleteClassWeekday(classweekday);
            return res;
        }

    }
}
