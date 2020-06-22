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
    public class LevelSvc : GenericSvc<LevelRep, Level>
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

        public object SearchLevel(string keyword, int page, int size)
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

        public SingleRsp CreateLevel(LevelReq lv)
        {
            var res = new SingleRsp();
            Level level = new Level();
            level.Id = lv.Id;
            level.Name = lv.Name;
            res = _rep.CreateLevel(level);
            return res;
        }

        public SingleRsp UpdateLevel(LevelReq lv)
        {
            var res = new SingleRsp();
            Level level = new Level();
            level.Id = lv.Id;
            level.Name = lv.Name;
            res = _rep.UpdateLevel(level);
            return res;
        }

        public SingleRsp DeleteLevel(LevelReq lv)
        {
            var res = new SingleRsp();
            Level level = new Level();
            level.Id = lv.Id;
            level.Name = lv.Name;
            res = _rep.DeleteLevel(level);
            return res;
        }
    }
}
