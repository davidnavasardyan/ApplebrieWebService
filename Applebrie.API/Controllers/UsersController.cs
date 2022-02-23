using Applebrie.Application.Users;
using Microsoft.AspNetCore.Mvc;

namespace Applebrie.API.Controllers
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers() =>
            HandleResult(await Mediator.Send(new List.Query()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(Guid id) =>
            HandleResult(await Mediator.Send(new Details.Query { Id = id }));

        [HttpGet("date")]
        public async Task<IActionResult> FilterUsersByDate(DateTime byDate) =>
           HandleResult(await Mediator.Send(new List.FilterByDateQuery { ByDate = byDate }));

        [HttpGet("type")]
        public async Task<IActionResult> FilterUsersByType(string byType) =>
           HandleResult(await Mediator.Send(new List.FilterByUserTypeQuery { TypeName = byType}));

        [HttpPost]
        public async Task<IActionResult> CreateUsers(UserDTO user) =>
            HandleResult(await Mediator.Send(new Create.Command { User = user }));

        [HttpPut("{id}")]
        public async Task<IActionResult> EditUsers(Guid id, UserDTO user)
        {
            user.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { User = user }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(Guid id) =>
            HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
}
