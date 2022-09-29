﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

   IFileHelper _fileHelper;


        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
            if (carImage.ImagePath == null)
            {
                carImage.ImagePath += "default.jpg";
            }
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();


        }
       

        public IResult Delete(CarImage carImage)
        {
           _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
       

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByCarImageId(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == carImageId));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
           carImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now,  ImagePath = PathConstants.ImagesPath+ "default.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

       
    }
}