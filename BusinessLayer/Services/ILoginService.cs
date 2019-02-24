using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public interface ILoginService
    {
        UserModel Login(UserModel user);
    }
}
