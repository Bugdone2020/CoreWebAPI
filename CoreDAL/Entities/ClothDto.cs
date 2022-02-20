using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDAL.Entities
{
    public class ClothDto
    {
        public Guid Id { get; set; }
        public Materials Material { get; set; }
        public string FriendlyName { get; set; }
    }
    public enum Materials
    {
        Leather,
        Silk,
        Jean,
        Coton
    }
}
