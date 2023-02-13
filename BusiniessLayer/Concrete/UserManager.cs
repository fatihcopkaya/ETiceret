using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusiniessLayer.Abstract;
using BusiniessLayer.Contacts;
using CoreLayer.Utilities.Result;
using CoreLayer.Utilities.Security.Hashing;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;


namespace BusiniessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userdal;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManager(IUserDal userdal, IHttpContextAccessor httpContextAccessor)
        {
            _userdal = userdal;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult<User>> AddAsync(User user)
        {
            await _userdal.AddAsync(user);
            return new SuccessDataResult<User>(user, Messages.AddMessage);
        }

        public async Task<IResult> DeleteAsync(User user)
        {
            user.IsActived = false;
            await _userdal.UpdateAsync(user);
            return new SuccessDataResult<User>(user, Messages.DeleteMessage);
        }

        public async Task<IDataResult<User>> GetByIdAsync(int userId)
        {
            var row = await _userdal.GetFirstOrDefaultAsync(x=>x.Id == userId);
            if(row != null)
            {
                return new SuccessDataResult<User>(row);
            }
            return new ErrorDataResult<User>(new User(), Messages.RecordMessage);
        }

        public async Task<IDataResult<User>> GetByMailAsync(string userEmail)
        {
            var row = await _userdal.GetFirstOrDefaultAsync(x => x.Email == userEmail);
            if (row != null)
            {
                return new SuccessDataResult<User>(row);
            }
            return new ErrorDataResult<User>(new User(), Messages.RecordMessage);
        }

        public Task<IDataResult<User>> GetByUserTokenAsync(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<User>>> GetListListAsync()
        {
           return new SuccessDataResult<List<User>>((await _userdal.GetListAsync(x=>x.IsActived == true)).ToList());
        }

        public async Task<IDataResult<User>> SignInAsync(User user)
        {
            var row = await _userdal.GetFirstOrDefaultAsync(x => x.Email == user.Email.Trim() && x.Password == user.Password.Trim());
            if (row != null)
            {
                var identity = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, row.FirstName),
                    new Claim(ClaimTypes.Email, row.Email),
                    new Claim(ClaimTypes.Role ,row.Role)

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                bool isAuthenticated = true;
                var principal = new ClaimsPrincipal(identity);
                if (isAuthenticated)
                {
                    await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                     principal, new AuthenticationProperties
                     {
                         ExpiresUtc = DateTime.UtcNow.AddDays(1),
                         IsPersistent = true,
                         AllowRefresh = false
                     });
                    return new SuccessDataResult<User>(row, Messages.SuccesfulLogin);
                }
            }
            return new ErrorDataResult<User>(new User(), Messages.UserNotFound);
        }

        public async Task<IResult> UpdateAsync(User user)
        {
            await _userdal.UpdateAsync(user);
            return new SuccessResult(Messages.UpdateMessage);
        }
    }
}