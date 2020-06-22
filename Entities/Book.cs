using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maple_web_api_async.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }
        public Guid AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author
        {
            get; set;
        }
    }
}