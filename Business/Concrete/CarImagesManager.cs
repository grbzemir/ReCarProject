using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImagesService
    {
        ICarImagesDal _carImageDal;
        IFileHelperService _fileHelperService;

        public CarImageManager(ICarImagesDal carImageDal, IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }
        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckForCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelperService.Upload(file, PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImages carImage)
        {
            _fileHelperService.Delete(PathConstants.CarImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckImageExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(id).Data);
            }

            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c => c.CarId == id), Messages.ImagesListedByCarId);
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            carImage.ImagePath = _fileHelperService.Update(file, PathConstants.CarImagesPath + carImage.ImagePath, PathConstants.CarImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckForCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImageLimitReached);
            }
            
            return new SuccessResult();

        }

        private IResult CheckImageExists(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;

            if (result > 0)
            {
                return new ErrorResult(Messages.CarImageAlreadyHave);
            }
            return new SuccessResult();

        }

        IDataResult<List<CarImages>> ICarImagesService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {

            List<CarImages> carImages = new List<CarImages>();

            carImages.Add(new CarImages { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });

            return new SuccessDataResult<List<CarImages>>(carImages);
        }
    }
}