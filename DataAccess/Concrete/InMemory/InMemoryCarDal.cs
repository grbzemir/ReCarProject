using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal

    {
        // Classin icinde ama metotlarin disinda tanimlanan degiskenlere global degisken denir.

        List<Car> _cars;

        public InMemoryCarDal()

        {

            _cars = new List<Car>

            {


                new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2015, DailyPrice = 1500000, Description = "Mercedes Amg gt Benzin " },
                new Car { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2016, DailyPrice = 200000, Description = "TOOG T10X Elektirk" },
                new Car { Id = 3, BrandId = 3, ColorId = 3, ModelYear = 2017, DailyPrice = 2500000, Description = "Audi RS6 Dizel" },
                new Car { Id = 4, BrandId = 4, ColorId = 4, ModelYear = 2018, DailyPrice = 30000, Description = "Mitsubishi Lancer Lpg" },
                new Car { Id = 5, BrandId = 5, ColorId = 5, ModelYear = 2019, DailyPrice = 55000, Description = "Toyota Corolla Hybrid" },


            };




        }
        public void Add(Car car)

        {

            //Bu sekilde de eklemeleri yaptık
            _cars.Add(car);

        }


        public void Delete(Car car)

        {
            // Burada LINQ kullanarak silme işlemini gerçekleştirdik.
            // SingleOrDefault metodu ile listedeki elemanları tek tek dolaşır ve parametre olarak verilen şarta uyan ilk elemanı döndürür.

            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()

        {


            return _cars;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)

        {

            return _cars.Where(c => c.Id == Id).ToList();
            // Burada LINQ kullanarak GetById metodu oluşturduk.
            // Where metodu ile listedeki elemanları tek tek dolaşır ve parametre olarak verilen şarta uyan elemanları yeni bir liste haline getirir.

        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)

        {

            // Gönderdigim ürün ıdsine sahip olan listedeki ürünü bul demek.

            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;


        }

    }
}
