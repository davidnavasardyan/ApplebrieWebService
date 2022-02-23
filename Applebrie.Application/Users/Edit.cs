using Applebrie.Application.Core;
using Applebrie.Persistence;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Applebrie.Application.Users
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UserDTO User { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.User).SetValidator(new UserValidatorDTO());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ApplebrieDbContext _dataContext;
            private readonly IMapper _mapper;

            public Handler(ApplebrieDbContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var dbEntry = await _dataContext.Users.FindAsync(request.User.Id);
                if (dbEntry == null)
                    return Result<Unit>.Failur("Cannot find user to edit it");

                request.User.UpdatedDateTime = DateTime.Now;
                _mapper.Map(request.User, dbEntry);
                var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;
                if (!result)
                    return Result<Unit>.Failur("failur to edit the user");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
