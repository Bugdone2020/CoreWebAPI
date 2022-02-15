using CoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothesController : ControllerBase
    {
        private static List<Cloth> _clothes;
        private readonly ILogger<ClothesController> _logger;

        static ClothesController()
        {
            _clothes = new List<Cloth>();
        }

        public ClothesController(ILogger<ClothesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddClothes(Cloth cloth)
        {
            cloth.Id = Guid.NewGuid();
            _clothes.Add(cloth);

            return Created(cloth.Id.ToString(), cloth);
        }

        [HttpGet]
        public IActionResult GetAllClothes()
        {
            return Ok(_clothes);
        }

        [HttpGet("{id}")]
        public IActionResult GetClothesById(Guid id)
        {
            Cloth cloth = _clothes.FirstOrDefault(x => x.Id == id);
            if (cloth != null)
            {
                return Ok(cloth);
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateCloth(Cloth cloth)
        {
            var dbCloth = _clothes.FirstOrDefault(x => x.Id == cloth.Id);
            if (dbCloth != null)
            {
                var index = _clothes.IndexOf(dbCloth);
                _clothes[index] = cloth;

                return Ok(cloth); ;
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCloth(Guid id)
        {
            var dbCloth = _clothes.FirstOrDefault(x => x.Id == id);

            if(dbCloth != null)
            {
                _clothes.Remove(dbCloth);
                return Ok(dbCloth);
            }

            return NotFound();
        }


    }
}
