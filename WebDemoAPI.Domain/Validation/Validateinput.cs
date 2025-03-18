using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebDemoAPI.Domain.Validation
{
    public class Validateinput
    {
        public static bool IsValiEmail(string email)
        {
            var EmailAtribute = new EmailAddressAttribute();
            return EmailAtribute.IsValid(email);
        }
        public static bool IsValiPhone(string phone)
        {
            string test = @"^(0|+84)(9\d|8[1-9]|7[06-9]|5[68]|3\d)\d{7}$";
            return Regex.IsMatch(phone, test);
        }

    }
}
