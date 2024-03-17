using Application.Abstractions;
using Domain.Entities;
using Domain.Shared;

namespace Application.Features.Identities.Command;

public class LoginCommand : ICommand<string>
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public class Handler : ICommandHandler<LoginCommand, string>
    {
        private readonly IJwtProvider _jwtprovider;

        public Handler(IJwtProvider jwtprovider)
        {
            _jwtprovider = jwtprovider;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            await Task.Delay(5000);
            var token = _jwtprovider.Generate(new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = "Abdullah",
                PasswordHashed = "any@o.com"
            });

            return token;
        }
    }
}
