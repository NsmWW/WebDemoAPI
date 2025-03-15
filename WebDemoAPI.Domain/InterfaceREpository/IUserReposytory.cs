using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoAPI.Domain.InterfaceREpository
{
    public interface IUserReposytory
    {
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUSername(string username);
        Task AllrollofUserAysnc(User user, List<string> Listrole);
        Task<IEnumerable<string>> GetRoleOfUserAsync(User user);
        Task DeleteRoleAsync(User user, List<string> Roles);
    }
}
