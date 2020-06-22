using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace English.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public CourseController()
        {
            _svc = new CourseSvc();
        }

        [HttpPost("Search-Course")]
        public IActionResult SearchCourse([FromBody] SearchCourseReq req)
        {
            var res = new SingleRsp();
            var stus = _svc.SearchCourse(req.Keyword, req.Page, req.Size);
            res.Data = stus;
            return Ok(res);
        }

        [HttpPost("Create-Course")]
        public IActionResult CreateCourse([FromBody] CourseReq req)
        {
            var res = _svc.CreateCourse(req);
            return Ok(res);
        }

        [HttpPost("Update-Course")]
        public IActionResult UpdateCourse([FromBody] CourseReq req)
        {
            var res = _svc.UpdateCourse(req);
            return Ok(res);
        }

        [HttpPost("Delete-Course")]
        public IActionResult DeleteCourse([FromBody] CourseReq req)
        {
            var res = _svc.DeleteCourse(req);
            return Ok(res);
        }
        private readonly CourseSvc _svc;
    }
}
