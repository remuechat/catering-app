using IMS.Domain.Entities.Users.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetByIdAsync(int id);
    }
}
