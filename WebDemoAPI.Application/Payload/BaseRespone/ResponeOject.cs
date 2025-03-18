using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemoAPI.Application.Payload.BaseRespone
{
    public class ResponeOject<T>
    {
        public int Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public ResponeOject() { }
        public ResponeOject(int status, string message, T? data)
        {
            Status = status; 
            Message = message; 
            Data = data;
        }
    }
}
