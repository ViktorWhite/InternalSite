using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternalSite.WebApi.Controllers
{
    /// <summary>
    /// Базовый контроллер, дает возможность использовать медиатр в других контроллерах
    /// </summary>
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
