using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginAccessor _loginAccessor;
        private readonly IEncryption _encryption;

        public LoginService(ILoginAccessor loginAccessor, IEncryption encryption)
        {
            _loginAccessor = loginAccessor;
            _encryption = encryption;
        }

        public UserModel Login(UserModel user)
        {
            try
            {
                user.Password = _encryption.EncryptPassword(user.Password);
                var mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
                var userDb = mapper.Map<UserModel, User>(user);
                var result = _loginAccessor.Login(userDb);
                user = mapper.Map<User, UserModel>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }
    }
}
