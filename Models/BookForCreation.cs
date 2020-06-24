using System;

namespace maple_web_api_async.Models
{
    public class BookForCreation
    {
        public string Title { get; set; }

        public Guid AuthorId { get; set; }

        public string Description { get; set; }
    }
}