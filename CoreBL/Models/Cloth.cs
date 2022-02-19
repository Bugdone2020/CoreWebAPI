using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CoreWebAPI.Models
{
    public class Cloth
    {
        [System.ComponentModel.DataAnnotations.Required]
        public Guid Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public Materials Material { get; set; } // string

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(2)]
        [System.ComponentModel.DataAnnotations.MaxLength(30)]
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
