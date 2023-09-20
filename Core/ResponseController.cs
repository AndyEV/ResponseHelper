using Microsoft.AspNetCore.Mvc;

namespace ResponseWrapperUtil.Core
{
    public class ResponseController : ControllerBase
    {
        [NonAction]
        [ApiExplorerSettings(IgnoreApi = true)]
        public new ActionResult Response(IResponse result)
        {
            if (!result.succeeded)
                return StatusCode(result.statuscode, result);

            return base.StatusCode(result.statuscode, result);
        }
    }
}
