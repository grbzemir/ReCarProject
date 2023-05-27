using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity

    {

        public int Id { get; set; } // Id isimli bir property oluşturduk.

        public int BrandId { get; set; } // BrandId isimli bir property oluşturduk.

        public int ColorId { get; set; } // ColorId isimli bir property oluşturduk.

        public int ModelYear { get; set; } // Model Yılı

        public decimal DailyPrice { get; set; } // Kiralama fiyatı 

        public string? Description { get; set; } // Açıklama 

    }
}
