using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDAL
{
    public class ClothInListRepository : IClothRepository
    {
        private static List<ClothDto> _clothes;

        static ClothInListRepository()
        {
            _clothes = new List<ClothDto>();
        }

        public Guid Add(ClothDto cloth)
        {
            cloth.Id = Guid.NewGuid();
            _clothes.Add(cloth);

            return cloth.Id;
        }

        public IEnumerable<ClothDto> GetAll()
        {
            return _clothes;
        }

        public ClothDto GetByID(Guid id)
        {
            return _clothes.FirstOrDefault(x => x.Id == id);
        }

        public ClothDto RemoveByID(Guid id)
        {
            var entity = GetByID(id);
            _clothes.Remove(entity);

            return entity;
        }

        public bool UpdateByID(ClothDto cloth)
        {
            var dbCloth = GetByID(cloth.Id);

            if(dbCloth != null)
            {
                var index = _clothes.IndexOf(dbCloth);
                _clothes[index] = cloth;
            }

            return dbCloth != null;
        }
    }
}
