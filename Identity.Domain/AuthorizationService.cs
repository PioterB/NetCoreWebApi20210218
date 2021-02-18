using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CreoCraft.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FleetManagement.Security
{
    internal class AuthorizationService : IAuthorizationService, ITokenService
    {
        private readonly IRepository<string, ApplicationUser> _repository;
        private readonly IConfiguration _configuration;

        public AuthorizationService(IRepository<string, ApplicationUser> repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public ApplicationUser Authorize(string identity, string secret)
        {
            var user = _repository.Get(identity);
            return user == null ? null : CheckSecret(user, secret) ? user : null;
        }

        private bool CheckSecret(ApplicationUser user, string secret)
        {
            return user.Password.Equals(secret);
        }

        public string CreateToken(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
            //Generate Token for user 
            var jwToken = new JwtSecurityToken(
                issuer: "http://localhost:45092/",
                audience: "http://localhost:5000/",
                claims: GetUserClaims(user),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                //Using HS256 Algorithm to encrypt Token  
                signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwToken);
            return token;
        }

        private IEnumerable<Claim> GetUserClaims(ApplicationUser user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name + " " + user.LastName),
                new Claim("Hired", user.Hired.ToShortDateString()),
            };

            if (user.Id == "pb")
            {
                claims.Add(new Claim(ClaimTypes.Role, "PowerUser"));
            }

            return claims;
        }
    }
}