﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog.Model.Entities
{
    public class Category : IEquatable<Category>
    {
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(30, ErrorMessage = "Max of 30 characters allowed")]
        public string Name { get; set; }

        public int Count { get; set; }

        public bool Equals(Category other)
        {
            return other.Name == Name;
        }

        public List<Post> Posts { get; set; }

        public override int GetHashCode()
        {
            int hashFirstName = Name == null ? 0 : Name.GetHashCode();

            return hashFirstName;
        }
    }
}
