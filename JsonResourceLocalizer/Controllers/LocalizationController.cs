using JsonResourceLocalizer.ViewModels;
using JsonResourceLocalizerLibrary.Localizers;
using JsonResourceLocalizerLibrary.Messages;
using Microsoft.AspNetCore.Mvc;

namespace JsonResourceLocalizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly IStringLocalizerService Localizer;
        public LocalizationController(IStringLocalizerService localizer)
        {
            Localizer = localizer;
        }

        [HttpGet("{type}/{key}")]
        public ActionResult<string> Get(string type, string key)
        {
            if (type.ToLower().StartsWith("i"))
            {
                return Localizer.GetLocalizedString(typeof(Info), key);
            }
            if (type.ToLower().StartsWith("w"))
            {
                return Localizer.GetLocalizedString(typeof(Warn), key);
            }
            if (type.ToLower().StartsWith("v"))
            {
                return Localizer.GetLocalizedString(typeof(Validation), key);
            }
            return "invalid resource type specified, supported are Info, Warn with en and es cultures";
        }

        [HttpPost]
        public IActionResult Post(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Request is just fine");
        }
    }
}
