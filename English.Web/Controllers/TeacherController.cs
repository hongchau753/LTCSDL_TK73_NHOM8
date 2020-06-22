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
    public class TeacherController : ControllerBase
    {
        public TeacherController()
        {
            _svc = new TeacherSvc();
        }

        [HttpPost("Search-Student")]
        public IActionResult SearchTeacher([FromBody] SearchTeacherReq req)
        {
            var res = new SingleRsp();
            var stus = _svc.SearchTeacher(req.Keyword, req.Page, req.Size);
            res.Data = stus;
            return Ok(res);
        }

        [HttpPost("Create-Teacher")]
        public IActionResult CreateTeacher([FromBody] TeacherReq req)
        {
            var res = _svc.CreateTeacher(req);
            return Ok(res);
        }

        [HttpPost("Update-Teacher")]
        public IActionResult UpdateTeacher([FromBody] TeacherReq req)
        {
            var res = _svc.UpdateTeacher(req);
            return Ok(res);
        }

        [HttpPost("Delete-Teacher")]
        public IActionResult DeleteStudent([FromBody] TeacherReq req)
        {
            var res = _svc.DeleteTeacher(req);
            return Ok(res);
        }
        private readonly TeacherSvc _svc;
    }
}
