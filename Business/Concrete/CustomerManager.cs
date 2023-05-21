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
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customers customers)
        {

           
            _customerDal.Add(customers);
            return new SuccessResult(true, Messages.CustomerAdded);


        }

        public IResult Delete(Customers customers)
        {
            _customerDal.Delete(customers);
            return new SuccessResult(true, Messages.CustomerDeleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<Customers> GetById(int id)
        {
            return new SuccessDataResult<Customers>(_customerDal.Get(c => c.UserId == id));
        }

        public IResult Update(Customers customers)
        {
            _customerDal.Update(customers);
            return new SuccessResult(true, Messages.CustomerUpdated);
        }
    }
}
