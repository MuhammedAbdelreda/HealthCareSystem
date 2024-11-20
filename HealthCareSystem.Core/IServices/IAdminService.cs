using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCareSystem.Core.Models.Identity;

namespace HealthCareSystem.Core.IServices
{
    public interface IAdminService
    {
        Task<AuthResponseDto> RegisterAsnyc(RegisterDTO registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDTO loginDto);
    }
}