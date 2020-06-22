using System;
using System.Collections.Generic;
using System.Text;
using English.Common.Rsp;
using English.Common.BLL;

namespace English.BLL
{
    using DAL;
    using DAL.Models;
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();
            var m1 = m.Id > 0 ? _rep.Read(m.Id) : _rep.Read(m.Name);
            if(m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }
            return res;
        }
    }
}
