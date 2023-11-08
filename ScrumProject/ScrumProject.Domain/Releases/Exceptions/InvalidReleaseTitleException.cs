using ScrumProject.Domain.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class InvalidReleaseTitleException : Exception
{
    internal InvalidReleaseTitleException() : base(ErrorMessageConstant.InvalidTitleException)
    {
    }
}
