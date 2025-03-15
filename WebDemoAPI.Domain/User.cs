using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoAPI.Domain.Enum;

namespace WebDemoAPI.Domain
{
    public class User : BaseEntity
    {
        public string Username { set; get; }    
        public DateTime? CreateTime {  set; get; }
        public string? Avatar {  set; get; }
        public string Email {  set; get; }
        public DateTime? UpdateTime {  set; get; }
        public string Password { set; get; }
        public string Fullname {  set; get; }
        public DateTime? DateOfBirt { set; get; }
        public ConstanEnum.EnumStatus EnumStatus { set; get; } = ConstanEnum.EnumStatus.Unactive;
    }
}
