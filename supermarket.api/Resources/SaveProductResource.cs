﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace supermarket.api.Resources
{
    public class SaveProductResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [Range(0,1000)]
        public short QuantityInPackage { get; set; }
        [Required]
        [Range(1,5)]
        public int UnitOfMeasurement { get; set; }
        [Required]
        public int CategoryId { get; set; }
    
    }
}
