﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class RegionViewModels
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "İlçe Adı")]
        public string Name { get; set; }
        public Guid CityId { get; set; }
    }
}
