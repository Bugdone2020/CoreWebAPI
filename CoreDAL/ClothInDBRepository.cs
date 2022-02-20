using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class ClothInDBRepository : IClothRepository
    {
        private readonly EfCoreContext _dbContext;

        public ClothInDBRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Add(ClothDto cloth)
        {
            cloth.Id = Guid.NewGuid();

            _dbContext.Add(cloth);
            _dbContext.SaveChanges();

            return cloth.Id;
        }

        public IEnumerable<ClothDto> GetAll()
        {
            return _dbContext.Clothes.ToList();
        }

        public ClothDto GetByID(Guid id)
        {
            return _dbContext.Clothes.Where(x => x.Id == id).FirstOrDefault();
        }

        public ClothDto RemoveByID(Guid id)
        {
            var cloth = GetByID(id);
            _dbContext.Clothes.Remove(cloth);
            _dbContext.SaveChanges(true);

            return cloth;
        }

        public bool UpdateByID(ClothDto cloth)
        {
            _dbContext.Clothes.Update(cloth);
            var result = _dbContext.SaveChanges();
            
            return result != 0;
        }
    }
}
