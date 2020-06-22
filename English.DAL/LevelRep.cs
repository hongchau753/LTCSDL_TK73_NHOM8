using System;
using System.Collections.Generic;
using System.Text;
using English.Common.DAL;
using English.DAL.Models;
using System.Linq;
using English.Common.Rsp;

namespace English.DAL
{
    public class LevelRep : GenericRep<WebEnglishContext, Level>
    {
        #region --Override--
        public override Level Read(int id)
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
        public SingleRsp CreateLevel(Level lv)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Level.Add(lv);
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

        public SingleRsp UpdateLevel(Level lv)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Level.Update(lv);
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

        public SingleRsp DeleteLevel(Level lv)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Level.Remove(lv);
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
