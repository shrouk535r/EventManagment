namespace TaskManagement.Api.Requests.Comments
{
    public class CommentRequest
    {
        public class CreateCommentRequest
        {
            public string Content { get; set; }
            public Guid TaskId { get; set; }

        }

    }
}
