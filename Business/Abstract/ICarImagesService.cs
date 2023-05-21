using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Business.Abstract
{
    public interface ICarImagesService

    {
        IDataResult<List<CarImages>> GetById(int id);
        IDataResult<List<CarImages>> GetAll();

        IDataResult<List<CarImages>> GetByCarId(int carId);
        IResult Add(IFormFile file , CarImages carImage);
        IResult Delete(CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);

    }
}
