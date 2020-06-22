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
    public class LevelController : ControllerBase
    {
        public LevelController()
        {
            _svc = new LevelSvc();
        }

        [HttpPost("Search-Level")]
        public IActionResult SearchLevel([FromBody] SearchLevelReq req)
        {
            var res = new SingleRsp();
            var stus = _svc.SearchLevel(req.Keyword, req.Page, req.Size);
            res.Data = stus;
            return Ok(res);
        }


        [HttpPost("Create-Level")]
        public IActionResult CreateLevel([FromBody] LevelReq req)
        {
            var res = _svc.CreateLevel(req);
            return Ok(res);
        }


        [HttpPost("Update-Level")]
        public IActionResult UpdateLevel([FromBody] LevelReq req)
        {
            var res = _svc.UpdateLevel(req);
            return Ok(res);
        }

        [HttpPost("Delete-Level")]
        public IActionResult DeleteLevel([FromBody] LevelReq req)
        {
            var res = _svc.DeleteLevel(req);
            return Ok(res);
        }

        private readonly LevelSvc _svc;
    }
}
