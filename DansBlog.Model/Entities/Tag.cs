using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DansBlog.Model.Entities
{
    public class Tag : IEquatable<Tag>
    {
        public int TagId { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public List<Post> Posts { get; set; }

        public bool Equals(Tag other)
        {
            if(Name == other.Name)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hashFirstName = Name == null ? 0 : Name.GetHashCode();

            return hashFirstName;
        }
    }
}
