using Library.Domain;

namespace ScrumProject.Domain.BackLogs.Entities;

public class BackLogComment : Entity<Guid>
{
    public Guid BackLogId { get; private set; }
    public string CommentText { get; private set; }
    public DateTime CommentDate { get; private set; }
    private BackLogComment() 
    {
        //ForEF
    }

    private BackLogComment(Guid backLogId, string commentText)
    {
        BackLogId = backLogId;
        CommentText = commentText;
        CommentDate = DateTime.Now;
    }

    public static BackLogComment CreateNew(Guid backLogId, string commentText)
    {
        return new BackLogComment(backLogId, commentText);
    }
}
