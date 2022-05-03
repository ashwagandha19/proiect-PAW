namespace library.Models.ResponseModels
{
    public class AuthorPresentationLayer
    {
        public int author_id { get; set; }
        public string? author_name { get; set; }
    }

    public class AuthorEditDelete : AuthorPresentationLayer
    {
        public bool IsDeleted { get; set; }
    }
}
