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
    public class ClassController : ControllerBase
    {
        public ClassController()
        {
            _svc = new ClassSvc();
        }

        [HttpPost("Search-Class")]
        public IActionResult SearchClass([FromBody] SearchClassReq req)
        {
            var res = new SingleRsp();
            var stus = _svc.SearchClass(req.Keyword, req.Page, req.Size);
            res.Data = stus;
            return Ok(res);
        }

        [HttpPost("Create-Class")]
        public IActionResult CreateClass([FromBody] ClassReq req)
        {
            var res = _svc.CreateClass(req);
            return Ok(res);
        }

        [HttpPost("Update-Class")]
        public IActionResult UpdateClass([FromBody] ClassReq req)
        {
            var res = _svc.UpdateClass(req);
            return Ok(res);
        }

        [HttpPost("Delete-Class")]
        public IActionResult DeleteClass([FromBody] ClassReq req)
        {
            var res = _svc.DeleteClass(req);
            return Ok(res);
        }
        private readonly ClassSvc _svc;
    }
}
