using ScrumProject.Domain.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class InvalidBackLogTitleException : Exception
{
    internal InvalidBackLogTitleException() : base(ErrorMessageConstant.InvalidTitleException)
    {
    }
}
