using Applebrie.Application.Core;
using Applebrie.Domain;
using Applebrie.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Applebrie.Application.Users
{
    public class List
    {
        public class Query : IRequest<Result<List<User>>> { }

        public class Handler : IRequestHandler<Query, Result<List<User>>>
        {
            private readonly ApplebrieDbContext _context;

            public Handler(ApplebrieDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<User>>> Handle(Query request, CancellationToken cancellationToken) =>
                Result<List<User>>.Success(await _context.Users.ToListAsync(cancellationToken));

        }

        public class FilterByDateQuery : IRequest<Result<List<User>>>
        {
            public DateTime? ByDate { get; set; }
        }

        public class FilterByDateHandler : IRequestHandler<FilterByDateQuery, Result<List<User>>>
        {
            private readonly ApplebrieDbContext _context;

            public FilterByDateHandler(ApplebrieDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<User>>> Handle(FilterByDateQuery request, CancellationToken cancellationToken) =>
                 Result<List<User>>.Success(await _context.Users.Where(x => x.CreatedDateTime.Date == request.ByDate).ToListAsync(cancellationToken));
        }

        public class FilterByUserTypeQuery : IRequest<Result<List<User>>>
        {
            public string TypeName { get; set; }
        }

        public class FilterByUserTypeHandler : IRequestHandler<FilterByUserTypeQuery, Result<List<User>>>
        {
            private readonly ApplebrieDbContext _context;

            public FilterByUserTypeHandler(ApplebrieDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<User>>> Handle(FilterByUserTypeQuery request, CancellationToken cancellationToken) =>
                Result<List<User>>.Success(await _context.Users.Where(x => x.UserType.TypeName == request.TypeName).ToListAsync(cancellationToken));
        }
    }
}
