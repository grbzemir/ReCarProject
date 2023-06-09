﻿using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract
{
    public interface IUserService

    {

        IResult Add(Users users);
        IResult Delete(Users users);
        IResult Update(Users users);

        IDataResult<List<Users>> GetAll();
        IDataResult<Users> GetById(int id);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        void Add(User user);
    }
}
