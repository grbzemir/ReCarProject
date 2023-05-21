using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetById(int colorId);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color car);
        IResult Delete(Color car);
        IResult Update(Color car);
    }
}