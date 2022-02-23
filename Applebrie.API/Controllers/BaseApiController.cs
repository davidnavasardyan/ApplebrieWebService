﻿using Applebrie.Application.Core;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Applebrie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess && result.Value != null)
                return Ok(result.Value);

            if (result.IsSuccess && result.Value == null)
                return NotFound();

            if (result == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}
