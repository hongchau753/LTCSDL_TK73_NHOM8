﻿using System;
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
    public class CategoryController : ControllerBase
    {
        public CategoryController()
        {
            _svc = new CategorySvc();

        }

        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }


        [HttpPost("get-all")]
        public IActionResult getAllCategory()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }
        private readonly CategorySvc _svc;
    }
}
