﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCMWebApp.Shared.Models
{
    public partial class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public int? PositionId { get; set; }
        public int? ProgrammeId { get; set; }

        public virtual Position Position { get; set; }
        public virtual Programme Programme { get; set; }
    }
}