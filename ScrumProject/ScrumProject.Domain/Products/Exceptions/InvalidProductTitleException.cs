using ScrumProject.Domain.Products.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class InvalidProductTitleException : Exception
{
    internal InvalidProductTitleException() : base(ErrorMessageConstant.InvalidProductTitleException)
    {
    }
}
