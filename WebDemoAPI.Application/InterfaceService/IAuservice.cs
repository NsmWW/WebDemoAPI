using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoAPI.Application.Payload.BaseRespone;
using WebDemoAPI.Application.Payload.Respone;
using WebDemoAPI.Application.Payload.Resquest.UserResquest;

namespace WebDemoAPI.Application.InterfaceService
{
    public interface IAservice
    {
        Task<ResponeOject<DataUserRespone>> Register (Request_Register request_Register);
    }
}
