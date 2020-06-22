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
    public class ClassWeekdayController : ControllerBase
    {
        public ClassWeekdayController()
        {
            _svc = new ClassWeekdaySvc();
        }

        [HttpPost("Search-ClassWeekday")]
        public IActionResult SearchClassWeekday([FromBody] SearchClassWeekdayReq req)
        {
            var res = new SingleRsp();
            var stus = _svc.SearchClassWeekday(req.Keyword, req.Page, req.Size);
            res.Data = stus;
            return Ok(res);
        }

        [HttpPost("Create-ClassWeekday")]
        public IActionResult CreateClassWeekday([FromBody] ClassWeekdayReq req)
        {
            var res = _svc.CreateClassWeekday(req);
            return Ok(res);
        }

        [HttpPost("Update-ClassWeekday")]
        public IActionResult UpdateClassWeekday([FromBody] ClassWeekdayReq req)
        {
            var res = _svc.UpdateClassWeekday(req);
            return Ok(res);
        }


        [HttpPost("Delete-ClassWeekday")]
        public IActionResult DeleteClassWeekday([FromBody] ClassWeekdayReq req)
        {
            var res = _svc.DeleteClassWeekday(req);
            return Ok(res);
        }

        private readonly ClassWeekdaySvc _svc;
    }
}
