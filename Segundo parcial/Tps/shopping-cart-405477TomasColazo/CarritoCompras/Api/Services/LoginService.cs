using Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly ShoppingContext _shoppingContext;

        public LoginService(ShoppingContext context)
        {
            _shoppingContext = context;
        }
        public async Task<string> ValidateUserAsync(string email, string password)
        {
            var user = await _shoppingContext.users.FirstOrDefaultAsync(x => x.Email == email && x.PasswordHash == password);


            // no encontré el usuario
            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var tokenDescription = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("asdasdasdasdasdsadasdXCXCweqeqweqweewqe")
                ),
                SecurityAlgorithms.HmacSha256Signature));

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescription);

            return token;
        }
    }
}
