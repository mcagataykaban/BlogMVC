﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMVC.ViewModels
{
    public class CommentViewModel
    {
        
        public int ArticleId { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Yorum en fazla 500 karakterden oluşabilir.")]
        [Display(Name = "Comment")]
        public string CommentText { get; set; }
    }
}