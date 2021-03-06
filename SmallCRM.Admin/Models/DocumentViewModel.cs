﻿using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmallCRM.Admin.Models
{
    public class DocumentViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Dosya Adı")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Dosya")]
        [MaxLength(200)]
        
        public string File { get; set; }
        [Display(Name = "Açıklama")]
        [MaxLength(400)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Tipi")]
        [Required]
        public FileType FileType { get; set; }
        [Display(Name = "Uzantısı")]
        
        public string Extension { get; set; }
        [Display(Name = "Boyutu")]
        [Required]
        public int Size { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}