using System;
using System.Collections.Generic;
using System.Text;
using English.Common.DAL;
using English.DAL.Models;
using System.Linq;
using English.Common.Rsp;

namespace English.DAL
{
    public class TeacherRep : GenericRep<WebEnglishContext, Teacher>
    {
        #region --Override--
        public override Teacher Read(int id)
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

        public SingleRsp CreateTeacher(Teacher tea)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Teacher.Add(tea);
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

        public SingleRsp UpdateTeacher(Teacher tea)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Teacher.Update(tea);
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

        public SingleRsp DeleteTeacher(Teacher tea)
        {
            var res = new SingleRsp();
            using (var context = new WebEnglishContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Teacher.Remove(tea);
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
