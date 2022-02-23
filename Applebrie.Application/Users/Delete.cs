using Applebrie.Application.Core;
using Applebrie.Persistence;
using MediatR;

namespace Applebrie.Application.Users
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ApplebrieDbContext _dataContext;

            public Handler(ApplebrieDbContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Users.FindAsync(request.Id);
                if (activity == null)
                    return null;

                _dataContext.Users.Remove(activity);
                var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;
                if (!result)
                    return Result<Unit>.Failur("Failur to remove/delete");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
