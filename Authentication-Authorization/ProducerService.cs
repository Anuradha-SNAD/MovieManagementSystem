using Microsoft.IdentityModel.Tokens;
using MovieManagementSystem.DTOs;
using MovieManagementSystem.Exceptions;
using MovieManagementSystem.Model;
using MovieManagementSystem.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieManagementSystem.Service
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository repository;
        private readonly IConfiguration configuration;

        public ProducerService(IProducerRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }
        public async Task<string> LoginAsync(LoginRequestDTO dto)
        {
            var producer = await repository.GetByEmail(dto.Email);

            if (producer == null)
            {
                throw new InvalidCredentialsException("Invalid Email or Password");
            }

            if (producer.Password != dto.Password)
            {
                throw new InvalidCredentialsException("Invalid Email or Password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, producer.Name),
                new Claim(ClaimTypes.Email, producer.Email),
                new Claim(ClaimTypes.Role, producer.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(
                    Convert.ToDouble(configuration["Jwt:DurationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task Register(RegisterRequestDTO dto)
        {
            var producer = await repository.GetByEmail(dto.Email);

            if (producer != null)
            {
                throw new Exception("Email already exists.");
            }

            Producer p = new Producer
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password, // We'll hash it later
                Role = "Producer"
            };

            await repository.Add(p);
        }
    }
}
