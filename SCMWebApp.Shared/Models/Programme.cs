﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCMWebApp.Shared.Models
{
    public partial class Programme
    {
        public Programme()
        {
            Banner = new HashSet<Banner>();
            Staff = new HashSet<Staff>();
            StudentApplication = new HashSet<StudentApplication>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Banner> Banner { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<StudentApplication> StudentApplication { get; set; }
    }
}