﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARD_project.Data
{
    public partial class RefreshToken
    {
        [Key]
        public int RefreshTokenId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool? Used { get; set; }
        public long UserId { get; set; }
        public virtual UsersMaster User { get; set; }
    }
}
