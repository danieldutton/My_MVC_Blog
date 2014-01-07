using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DansBlog.Model.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]                
        [DisplayName("Posted:")]
        [Required]
        public DateTime CreationTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "A comment is required")]
        [StringLength(500, ErrorMessage = "Max of 500 characters allowed")]
        [DisplayName("Comment:")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Author name is required")]
        [DisplayName("Author:")]
        [StringLength(70, ErrorMessage = "Max of 70 characters allowed")]
        public string Author { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail address is required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(70, ErrorMessage = "E-mail address Too Long")]
        public string Email { get; set; }

        [DisplayName("Moderated:")]
        public bool HasBeenModerated { get; set; }

        public int PostId { get; set; }


        public Comment()
        {
            HasBeenModerated = false;
        }
    }
}
