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
    public class ClassStudentController : ControllerBase
    {
        public ClassStudentController()
        {
            _svc = new ClassStudentSvc();
        }

        [HttpPost("Search-ClassStudent")]
        public IActionResult SearchClassStudent([FromBody] SearchClassStudentReq req)
        {
            var res = new SingleRsp();
            var stus = _svc.SearchClassStudent(req.Keyword, req.Page, req.Size);
            res.Data = stus;
            return Ok(res);
        }

        [HttpPost("Create-ClassStudent")]
        public IActionResult CreateClassStudent([FromBody] ClassStudentReq req)
        {
            var res = _svc.CreateClassStudent(req);
            return Ok(res);
        }

        [HttpPost("Update-ClassStudent")]
        public IActionResult UpdateClassStudent([FromBody] ClassStudentReq req)
        {
            var res = _svc.UpdateClassStudent(req);
            return Ok(res);
        }

        [HttpPost("Delete-ClassStudent")]
        public IActionResult DeleteClassStudent([FromBody] ClassStudentReq req)
        {
            var res = _svc.DeleteClassStudent(req);
            return Ok(res);
        }
        private readonly ClassStudentSvc _svc;
    }
}
