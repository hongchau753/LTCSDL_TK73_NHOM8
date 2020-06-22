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
    public class CourseSvc : GenericSvc<CourseRep, Course>
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

        public object SearchCourse(string keyword, int page, int size)
        {
            var stu = All.Where(x => x.Description.Contains(keyword));
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

        public SingleRsp CreateCourse(CourseReq crs)
        {
            var res = new SingleRsp();
            Course course = new Course();
            course.Id = crs.Id;
            course.Lession = crs.Lession;
            course.Description = crs.Description;
            course.Term = crs.Term;
            course.LevelId = crs.LevelId;
            course.CategoryId = crs.CategoryId;
            res = _rep.CreateCourse(course);
            return res;
        }

        public SingleRsp UpdateCourse(CourseReq crs)
        {
            var res = new SingleRsp();
            Course course = new Course();
            course.Id = crs.Id;
            course.Lession = crs.Lession;
            course.Description = crs.Description;
            course.Term = crs.Term;
            course.LevelId = crs.LevelId;
            course.CategoryId = crs.CategoryId;
            res = _rep.UpdateCourse(course);
            return res;
        }

        public SingleRsp DeleteCourse(CourseReq crs)
        {
            var res = new SingleRsp();
            Course course = new Course();
            course.Id = crs.Id;
            course.Lession = crs.Lession;
            course.Description = crs.Description;
            course.Term = crs.Term;
            course.LevelId = crs.LevelId;
            course.CategoryId = crs.CategoryId;
            res = _rep.DeleteCourse(course);
            return res;
        }
    }
}
