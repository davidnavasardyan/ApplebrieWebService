using Applebrie.Application.Core;
using Applebrie.Domain;
using Applebrie.Persistence;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Applebrie.Application.Users
{
    public class Create
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

            public Handler()
            {
            }

            public Handler(ApplebrieDbContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var newUser = _mapper.Map(request.User, new User());
                _dataContext.Users.Add(newUser);
                var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;

                if (!result)
                    return Result<Unit>.Failur("Failed to create new user");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
