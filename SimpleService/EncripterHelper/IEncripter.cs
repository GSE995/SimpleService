using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleService.Models;

namespace SimpleService.EncripterHelper
{
    interface IEncripter
    {
        string EncryptUserEmail(string email);
        void EncryptEmailAllUsers(ICollection<User> users);
        void EncryptEmailUser(User user);
    }
}
