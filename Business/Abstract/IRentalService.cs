using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService

    {
        IResult Add(Rentals rental);

        IResult Delete(Rentals rental);

        IResult Update(Rentals rental);



        IDataResult<List<Rentals>> GetAll();

        IDataResult<Rentals> GetById(int id);

    }
}
