using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoAPI.Application.Payload.Respone
{
    public class DataUserRespone
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public DateTime? dateTime { get; set; }
        public string UserStatus { get; set; }
    }
}
