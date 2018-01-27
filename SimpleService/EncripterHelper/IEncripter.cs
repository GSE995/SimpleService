using System;
using System.Collections.Generic;
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
