using System;
using System.Collections.Generic;
using System.Text;
using English.Common.DAL;
using English.DAL.Models;
using System.Linq;
using English.Common.Rsp;

namespace English.DAL
{
    public class ClassStudentRep : GenericRep<WebEnglishContext, ClassStudent>
    {
        #region --Override--
        public override ClassStudent Read(int id)
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
        public SingleRsp CreateClassStudent(ClassStudent clt)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.ClassStudent.Add(clt);
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

        public SingleRsp UpdateClassStudent(ClassStudent clt)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.ClassStudent.Update(clt);
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

        public SingleRsp DeleteClassStudent(ClassStudent clt)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.ClassStudent.Remove(clt);
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
