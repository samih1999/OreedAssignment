using PersonalSami.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSami.Services
{
    public interface IRegisterService
    {
        bool CheckEmail(string email);
        bool CheckPass(byte[] Pass);
        UserInfo logcheck(string username, string password);
        Task CreateAsync(UserInfo reg);
        UserInfo GetByEmail(string regmail);
        UserInfo GetById(int id);
        string GetRole(string email);
    }
}
