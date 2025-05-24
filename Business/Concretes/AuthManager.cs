using Business.Abstracts;
using Business.Constants;
using Business.Rules;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IOperationClaimRepository _operationClaimRepository;

    public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository, AuthBusinessRules authBusinessRules, IOperationClaimRepository operationClaimRepository)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
        _authBusinessRules = authBusinessRules;
        _operationClaimRepository = operationClaimRepository;
    }

    public AccessToken CreateAccessToken(User user)
    {
        List<OperationClaim> claims = _userOperationClaimRepository.Query().AsNoTracking().Where(x => x.UserId == user.Id)
            .Select(x => new OperationClaim
            {
                Id = x.OperationClaimId,
                Name = x.OperationClaim.Name
            }).ToList();
        var accessToken = _tokenHelper.CreateToken(user, claims);
        return accessToken;
    }

    public AccessToken Login(UserForLoginDto userForLoginDto)
    {
        var user = _userService.GetByMail(userForLoginDto.Email);
        _authBusinessRules.UserShouldBeExists(user);
        _authBusinessRules.UserPasswordShouldBeExists(user.Id,userForLoginDto.Password);
        _authBusinessRules.UserEmailShouldBeExists(userForLoginDto.Email);
        var createAccessToken = CreateAccessToken(user);
        return createAccessToken;
    }

    public AccessToken Register(UserForRegisterDto userForRegisterDto)
    {
        _authBusinessRules.UserEmailShouldBeNotExists(userForRegisterDto.Email);
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        User createdUser =  _userService.Add(user);
        OperationClaim? defaultRole = _operationClaimRepository.Get(x => x.Name == OperationClaims.Default);
        UserOperationClaim userOperationClaim = new UserOperationClaim()
        {
            UserId = user.Id,
            OperationClaimId = defaultRole.Id
        };
        _userOperationClaimRepository.Add(userOperationClaim);
        var createAccessToken = CreateAccessToken(user);
        return createAccessToken;

    }
}
