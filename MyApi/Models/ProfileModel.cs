using MyApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApi.Models
{
    public class ProfileModel
    {
        public ProfileModel(Personal_Inf profile)
        {
            Id = profile.id;
            Name = profile.name;
            Job = profile.job;
            Email = profile.email;
            Image = profile.image;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}