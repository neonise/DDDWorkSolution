using ScrumProject.Domain.Constants;

namespace ScrumProject.Domain.Products.Exceptions;
internal class ReleaseDuplicateTitleException : Exception
{
    internal ReleaseDuplicateTitleException() : base(ErrorMessageConstant.ReleaseDuplicateTitleException)
    {
    }
}
