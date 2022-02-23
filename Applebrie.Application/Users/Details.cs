using Applebrie.Application.Core;
using Applebrie.Domain;
using Applebrie.Persistence;
using MediatR;

namespace Applebrie.Application.Users
{
    public class Details
    {
        public class Query : IRequest<Result<User>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<User>>
        {
            private readonly ApplebrieDbContext _dataContext;

            public Handler(ApplebrieDbContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Result<User>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _dataContext.Users.FindAsync(request.Id);
                return Result<User>.Success(activity);
            }
        }
    }
}
