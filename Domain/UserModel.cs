﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class UserModel
    {
        UserDao userdao = new UserDao();

        public bool LoginUser(string user, string pass)
        {
            return userdao.Login(user, pass);
        }
    }
}