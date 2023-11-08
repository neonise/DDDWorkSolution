using ScrumProject.Domain.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class InvalidProductTitleException : Exception
{
    internal InvalidProductTitleException() : base(ErrorMessageConstant.InvalidTitleException)
    {
    }
}
