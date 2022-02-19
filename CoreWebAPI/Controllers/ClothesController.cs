using CoreBL;
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
        private readonly ClothService _clothService;
        private readonly ILogger<ClothesController> _logger;

        public ClothesController(ILogger<ClothesController> logger, ClothService clothService)
        {
            _logger = logger;
            _clothService = clothService;
        }

        [HttpPost("add")] //[HttpPost]
        public IActionResult AddClothes(Cloth cloth)
        {
            if(cloth != null)
            {
                var createdGuid = _clothService.AddCloth(cloth);

                return Created(createdGuid.ToString(), cloth);
            }

            return BadRequest();
        }

        [HttpGet("all")]//[HttpGet]
        public IActionResult GetAllClothes()
        {
            return Ok(_clothService.GetAllClothes());
        }

        [HttpGet("{id}")]
        public IActionResult GetClothesById(Guid id)
        {
            var cloth = _clothService.GetClothById(id);
            if (cloth != null)
            {
                return Ok(cloth);
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateCloth(Cloth cloth)
        {
            var successed = _clothService.UpdateCloth(cloth);

            return StatusCode(successed ? 200 : 404);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCloth(Guid id)
        {
            var cloth = _clothService.RemoveCloth(id);

            return StatusCode(cloth != null ? 200 : 400, cloth);
        }

    }
}
