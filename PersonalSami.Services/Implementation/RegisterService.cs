using PersonalSami.Data;
using PersonalSami.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSami.Services.Implementation
{
    public class RegisterService : IRegisterService
    {

        private readonly ApplicationDbContext _context;

        public RegisterService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task CreateAsync(UserInfo reg)
        {
           await _context.userInfos.AddAsync(reg);
            await _context.SaveChangesAsync();

        }

        public UserInfo GetByEmail(string regmail) => _context.userInfos.Where(e => e.Email == regmail).FirstOrDefault();

        public UserInfo GetById(int id)=> _context.userInfos.Where(e => e.Id == id).FirstOrDefault();


        public string GetRole(string email)
        {
            var user = GetByEmail(email);
            if (user != null)
                return user.Role;
            return "usernotfound";
        }

        public UserInfo logcheck(string username, string password)
        {
            var user = GetByEmail(username);
            if (user == null) return null;

            var hmac = new HMACSHA512(user.PasswordSalt);


            //var e = _context.logins.Where(x => x.Password == Pass).FirstOrDefault();
            var e = _context.userInfos.Where(x => x.Email == username && x.PasswordHash == hmac.ComputeHash(Encoding.UTF8.GetBytes(password))).FirstOrDefault();

            if (e != null)
                return e;
            return e;
        }

        public bool CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool CheckPass(byte[] Pass)
        {
            var e = _context.userInfos.Where(x => x.PasswordHash == Pass).FirstOrDefault();
            if (e == null)
                return false;
            return true;
        }
    }
}
