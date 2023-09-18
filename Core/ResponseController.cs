using Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Response.Core
{
    public class ResponseController : ControllerBase
    {
        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Ok(IResponse result)
        {
            if (!result.succeeded)
                return BadRequest(result);

            return base.Ok(result);
        }
    }
}
