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
    public class StudentController : ControllerBase
    {
        public StudentController()
        {
            _svc = new StudentSvc();

        }

        [HttpPost("Search-Student")]
        public IActionResult SearchStudent([FromBody] SearchStudentReq req)
        {
            var res = new SingleRsp();
            var stus = _svc.SearchStudent(req.Keyword, req.Page, req.Size);
            res.Data = stus;
            return Ok(res);
        }

        [HttpPost("Create-Student")]
        public IActionResult CreateStudent([FromBody] StudentReq req)
        {
            var res = _svc.CreateStudent(req);
            return Ok(res);
        }

        [HttpPost("Update-Student")]
        public IActionResult UpdateStudent([FromBody] StudentReq req)
        {
            var res = _svc.UpdateStudent(req);
            return Ok(res);
        }

        [HttpPost("Delete-Student")]
        public IActionResult DeleteStudent([FromBody] StudentReq req)
        {
            var res = _svc.DeleteStudent(req);
            return Ok(res);
        }

        private readonly StudentSvc _svc;
    }
}
