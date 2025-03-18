using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoAPI.Application.Payload.Respone;
using WebDemoAPI.Domain;

namespace WebDemoAPI.Application.Payload.Mapper
{
    public class UserDataConverter
    {
        public DataUserRespone Entity(User user)
        {
            return new DataUserRespone()
            {
                UserStatus = user.EnumStatus.ToString(),
                dateTime = user.DateOfBirt,
                Email = user.Email,
                Fullname = user.Fullname,
            };
        }
    }
}
