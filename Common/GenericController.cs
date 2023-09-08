using Microsoft.AspNetCore.Mvc;

namespace TranslateHistory.Common
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class GenericController : ControllerBase { }
}