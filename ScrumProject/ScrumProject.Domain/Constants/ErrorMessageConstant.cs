namespace ScrumProject.Domain.Constants;
internal static class ErrorMessageConstant
{
    internal const string InvalidIntervalDateException = "DeadLineDate should greater than CreateDate";
    internal const string InvalidTitleException = "title should not be empty";
    internal const string ReleaseDuplicateTitleException = "an release is exist by title";
    internal const string SprintInvalidDateException = "sprint invalid interval date";
    internal const string BackLogDuplicateException = "an backLog is exist by title";
}
