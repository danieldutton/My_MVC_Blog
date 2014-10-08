using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DansBlog.Model.Entities
{
    public class Post
    {
        public int Id { get; set; }

        [DisplayName("Date Posted")]
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        [Required(ErrorMessage = "Post Date is required")]
        public DateTime PublishDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Content is required")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        public virtual List<Comment> Comments { get; set; }

        [NotMapped]
        public int ModeratedCommentCount
        {
            get { if (Comments != null) return Comments.Count(c => c.HasBeenModerated);
                return 0;
            }
        }

        public virtual List<Category> Categories { get; set; }
    }
}

