using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService

    {

        IDataResult<List<Brand>> GetById(int id);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand car);
        IResult Delete(Brand car);
        IResult Update(Brand car);



    }
}
