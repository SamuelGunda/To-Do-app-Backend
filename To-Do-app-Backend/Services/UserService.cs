using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using To_Do_app_Backend.Exceptions;
using To_Do_app_Backend.Models.Domains;
using To_Do_app_Backend.Models.Requests;
using To_Do_app_Backend.Repositories;
using To_Do_app_Backend.Utilities;
using Task = System.Threading.Tasks.Task;

namespace To_Do_app_Backend.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly TokenHelper _tokenHelper;
    public UserService(IUserRepository userRepository, TokenHelper tokenHelper) 
    {
        _userRepository = userRepository;
        _tokenHelper = tokenHelper;
    }
    
    public async Task<string> LoginAsync(AuthRequest authRequest)
    {
        var user = await _userRepository.GetByEmailAsync(authRequest.Email);
        
        if (user == null || user.Password != authRequest.Password)
        {
            throw new InvalidLoginException();
        }
        
        return _tokenHelper.CreateToken(user);
    }

    public Task AddAsync(AuthRequest authRequest)
    {
        return _userRepository.AddAsync(authRequest);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        
        if (user == null)
        {
            throw new EntityNotFoundException($"User with id {id} was not found");
        }
        
        return user;
    }
}