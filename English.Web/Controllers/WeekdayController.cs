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
    public class WeekdayController : ControllerBase
    {
        public WeekdayController ()
        {
            _svc = new WeekdaySvc();
        }

        [HttpPost("Search-Weekday")]
        public IActionResult SearchWeekday([FromBody] SearchWeekdayReq req)
        {
            var res = new SingleRsp();
            var stus = _svc.SearchWeekday(req.Keyword, req.Page, req.Size);
            res.Data = stus;
            return Ok(res);
        }

        [HttpPost("Create-Weekday")]
        public IActionResult CreateWeekday([FromBody] WeekdayReq req)
        {
            var res = _svc.CreateWeekday(req);
            return Ok(res);
        }

        [HttpPost("Update-Weekday")]
        public IActionResult UpdateWeekday([FromBody] WeekdayReq req)
        {
            var res = _svc.UpdateWeekday(req);
            return Ok(res);
        }

        [HttpPost("Delete-Weekday")]
        public IActionResult DeleteWeekday([FromBody] WeekdayReq req)
        {
            var res = _svc.DeleteWeekday(req);
            return Ok(res);
        }



        private readonly WeekdaySvc _svc;
    }
}
