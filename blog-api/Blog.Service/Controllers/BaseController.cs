using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Service.Controllers
{
    public class BaseController:ControllerBase
    {
        //protected new IActionResult Ok()
        //{
        //    return base.Ok(Envelope.Ok());
        //}

        //protected IActionResult Ok<T>(T result)
        //{
        //    return base.Ok(Envelope.Ok(result));
        //}

        //protected IActionResult Error(string errorMessage)
        //{
        //    return BadRequest(Envelope.Error(errorMessage));
        //}
    }
}
