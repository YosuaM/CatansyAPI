using Catansy.API.Models.Responses.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catansy.API.Controllers.Base;

[Authorize]
[ApiController]
public abstract class CatansyBaseController : ControllerBase
{
    internal IActionResult ReturnResponseCode(Error errorValue) =>
        errorValue.StatusCode() switch
        {
            StatusCodes.Status400BadRequest => BadRequest(errorValue),
            StatusCodes.Status404NotFound => NotFound(errorValue),
            StatusCodes.Status500InternalServerError =>
                StatusCode(StatusCodes.Status500InternalServerError, errorValue),
            _ => StatusCode(StatusCodes.Status500InternalServerError, errorValue)
        };
}