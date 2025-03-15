using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoAPI.Domain;
using WebDemoAPI.Domain.InterfaceREpository;
using WebDemoAPI.Infastructure.DataContext;

namespace WebDemoAPI.Infastructure.ImplementRepository
{
    public class UserRepository : IUserReposytory
    {
        private readonly ApplicationDBcontext _context;
        public UserRepository(ApplicationDBcontext context)
        {
            _context = context;
        }
        public UserRepository() { }

        private Task<bool> CompareString(string s1, string s2)
        {
            return Task.FromResult(string.Equals(s1.ToLowerInvariant(), s2.ToLowerInvariant()));
        }
        private async Task<bool> IstringinListstring(string s1, List<string> Liststring)
        {
            if(s1 == null)
            {
                throw new ArgumentNullException("Chuoi nhap dau vao khong co gi");
            }
            if(Liststring == null)
            {
                throw new ArgumentNullException("list role nhap vao null");
            }
            foreach (string s in Liststring)
            {
                if (await CompareString(s, s1))
                {
                    return true;
                }
            }
            return false;
        }
        public async Task AllrollofUserAysnc(User user, List<string> Listrole)
        {
            if(user == null)
            {
                throw new ArgumentNullException("user is null");
            }
            if (Listrole == null)
            {
                throw new ArgumentNullException("List role is null");
            }
            foreach(var role in Listrole.Distinct())
            {
                
            }
        }

        public Task DeleteRoleAsync(User user, List<string> Roles)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetRoleOfUserAsync(User user)
        {
            throw new ArgumentException("");
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUSername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
