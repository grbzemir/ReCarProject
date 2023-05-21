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
    public class RentalManager : IRentalService

    {
        IRentalDal _rentalDal;

        public RentalManager (IRentalDal rental)

        {
            _rentalDal = rental;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rentals rental)
        {
            
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rentals rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalDal.Get(r => r.CarId == id));
        }

        public IResult Update(Rentals rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();

        }
    }
}
