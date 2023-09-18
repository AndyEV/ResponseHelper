using Microsoft.AspNetCore.Mvc;

namespace Response.Core
{
    public class ResponseController : ControllerBase
    {
        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public new ActionResult Response(IResponse result)
        {
            if (!result.succeeded)
                return BadRequest(result);

            return base.Ok(result);
        }
    }
}
