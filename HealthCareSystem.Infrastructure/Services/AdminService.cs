using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IRepositories;
using HealthCareSystem.Core.IServices;
using HealthCareSystem.Core.Models.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HealthCareSystem.Infrastructure.Services
{
    public class AdminService:IAdminService
        {
        private readonly IGenericRepo<Admin> _admin;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AdminService(IGenericRepo<Admin> admin, IConfiguration configuration, IMapper mapper)
        {
            _admin = admin;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> RegisterAsnyc(RegisterDTO registerDto)
        {
            // Check if the email is already registered
            var existingAdmin = await _admin.GetAllDataAsync();
            if (existingAdmin.Any(m => m.Email.Equals(registerDto.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Email is already registered.");
            }

            // Create new member
            var admin = _mapper.Map<Admin>(registerDto);
            admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            await _admin.CreateAsync(admin);

            return new AuthResponseDto
            {
                Token = GenerateJwtToken(admin)
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDTO loginDto)
        {
            var member = await _admin.GetAllDataAsync();
            var existingAdmin = member.FirstOrDefault(m => m.Email.Equals(loginDto.Email, StringComparison.OrdinalIgnoreCase));

            if (existingAdmin == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, existingAdmin.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }

            return new AuthResponseDto
            {
                Token = GenerateJwtToken(existingAdmin)
            };
        }

        private string GenerateJwtToken(Admin admin)
        {
            // Define the claims you want to include in the token
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()), // Member ID
        new Claim(ClaimTypes.Email, admin.Email), // Member Email
        new Claim(ClaimTypes.Role, "Admin") // You can add roles if needed
    };

            // Create a security key using the key from configuration
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Create the signing credentials using the key and the algorithm
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30), // Set token expiration
                signingCredentials: creds);

            // Write the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}