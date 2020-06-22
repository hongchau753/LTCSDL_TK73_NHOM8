using System;
using System.Collections.Generic;
using System.Text;
using English.Common.DAL;
using English.DAL.Models;
using System.Linq;
using English.Common.Rsp;

namespace English.DAL
{
    public class WeekdayRep : GenericRep<WebEnglishContext, Weekday>
    {

        #region --Override--
        public override Weekday Read(int id)
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

        #region --Method--
        public SingleRsp CreateWeekday(Weekday wd)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Weekday.Add(wd);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateWeekday(Weekday wd)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Weekday.Update(wd);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteWeekday(Weekday wd)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Weekday.Remove(wd);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        #endregion
    }
}
