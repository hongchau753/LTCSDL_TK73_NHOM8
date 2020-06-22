using System;
using System.Collections.Generic;
using System.Text;
using English.Common.DAL;
using English.DAL.Models;
using System.Linq;
using English.Common.Rsp;

namespace English.DAL
{
    public class ClassWeekdayRep : GenericRep<WebEnglishContext, ClassWeekday>
    {
        #region --Override--
        public override ClassWeekday Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ClassId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.ClassId == id);
            m = base.Delete(m);
            return m.ClassId;
        }
        #endregion

        #region --Method--
        public SingleRsp CreateClassWeekday(ClassWeekday cw)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.ClassWeekday.Add(cw);
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

        public SingleRsp UpdateClassWeekday(ClassWeekday cw)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.ClassWeekday.Update(cw);
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

        public SingleRsp DeleteClassWeekday(ClassWeekday cw)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.ClassWeekday.Remove(cw);
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
