using System;
using System.Collections.Generic;
using System.Text;
using English.Common.DAL;
using System.Linq;

namespace English.DAL
{
    using English.DAL.Models;
    public class CategoryRep : GenericRep<WebEnglishContext, Category>
    {
        #region --Override--
        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(p => p.Id == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.Id == id);
            m = base.Delete(m);
            return m.Id;
        }
        #endregion
    }
}
