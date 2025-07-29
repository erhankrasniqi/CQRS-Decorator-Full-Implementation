using CQRS_Decorator.Application.Abstractions;
using CQRS_Decorator.Application.Commands.CreateUser;
using CQRS_Decorator.Application.Dispatchers;
using CQRS_Decorator.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Decorator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public UsersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var command = CreateUserCommand.Create(request.FirstName, request.LastName, request.Email);
            var result = await _commandDispatcher.SendAsync(command);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _queryDispatcher.SendAsync(new GetUserByIdQuery(id));
            return user is null ? NotFound() : Ok(user);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var user = await _queryDispatcher.SendAsync(new GetAllUserQuery());
            return user is null ? NotFound() : Ok(user);
        }

    }

    public record CreateUserRequest(string FirstName, string LastName, string Email);

}
