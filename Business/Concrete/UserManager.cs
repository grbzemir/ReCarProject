using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService

    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(Users users)
        {
           

            _userDal.Add(users);
            return new SuccessResult();
        }

        public IResult Delete(Users users)
        {
            _userDal.Delete(users);
            return new SuccessResult();
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_userDal.Get(u => u.Id == id));
        }

        public IResult Update(Users users)
        {
            _userDal.Update(users);
            return new SuccessResult();
        }
    }
}
