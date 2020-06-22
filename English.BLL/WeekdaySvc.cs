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
    public class WeekdaySvc : GenericSvc<WeekdayRep, Weekday>
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

        public object SearchWeekday(string keyword, int page, int size)
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

        public SingleRsp CreateWeekday(WeekdayReq wd)
        {
            var res = new SingleRsp();
            Weekday weekday = new Weekday();
            weekday.Id = wd.Id;
            weekday.Name = wd.Name;
            res = _rep.CreateWeekday(weekday);
            return res;
        }


        public SingleRsp UpdateWeekday(WeekdayReq wd)
        {
            var res = new SingleRsp();
            Weekday weekday = new Weekday();
            weekday.Id = wd.Id;
            weekday.Name = wd.Name;
            res = _rep.UpdateWeekday(weekday);
            return res;
        }

        public SingleRsp DeleteWeekday(WeekdayReq wd)
        {
            var res = new SingleRsp();
            Weekday weekday = new Weekday();
            weekday.Id = wd.Id;
            weekday.Name = wd.Name;
            res = _rep.DeleteWeekday(weekday);
            return res;
        }

    }
}
