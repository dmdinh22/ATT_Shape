﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT_Shape.domain.Models.Request
{
    public class VideoUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Title length must be greater than or equal to 2 characters.")]
        [MaxLength(50, ErrorMessage = "Title length cannot be greater than 50 characters.")]
        public string Title { get; set; }

        [MaxLength(250, ErrorMessage = "Description length cannot be greater than 250 characters.")]
        public string Description { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Url length cannot be greater than 250 characters.")]
        public string Url { get; set; }
    }
}
