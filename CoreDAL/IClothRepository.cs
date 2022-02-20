using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL
{
    public interface IClothRepository
    {
        Guid Add(ClothDto cloth);
        IEnumerable<ClothDto> GetAll();
        ClothDto GetByID(Guid id);
        ClothDto RemoveByID(Guid id);
        bool UpdateByID(ClothDto cloth);
    }
}
