using CoreWebAPI.Models;
using CoreDAL;
using System;
using System.Collections.Generic;
using AutoMapper;
using CoreDAL.Entities;

namespace CoreBL
{
    public class ClothService
    {
        private IClothRepository _clothRepository;
        private IMapper _mapper;

        public ClothService(IMapper mapper, IClothRepository clothRepository)
        {
            _mapper = mapper;

            _clothRepository = clothRepository;
        }

        public Guid AddCloth(Cloth cloth)
        {
            if(! char.IsUpper(cloth.FriendlyName[0]))
            {
                throw new ArgumentException("Name sould start with upper - case!");
            }

            var dbcloth = _mapper.Map<ClothDto>(cloth);

            return _clothRepository.Add(dbcloth);
        }

        public IEnumerable<Cloth> GetAllClothes()
        {
            var dbItems = _clothRepository.GetAll();

            return _mapper.Map<IEnumerable<Cloth>>(dbItems);
        }

        public Cloth GetClothById(Guid id)
        {
            var dbCloth = _clothRepository.GetByID(id);

            return _mapper.Map<Cloth>(dbCloth);
        }

        public Cloth RemoveCloth(Guid id)
        {
            var dbCloth = _clothRepository.RemoveByID(id);

            return _mapper.Map<Cloth>(dbCloth);
        }

        public bool UpdateCloth(Cloth cloth)
        {
            return _clothRepository.UpdateByID(_mapper.Map<ClothDto>(cloth));
        }
    }
}
