using ScrumProject.Domain.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class InvalidSprintTitleException : Exception
{
    internal InvalidSprintTitleException() : base(ErrorMessageConstant.InvalidTitleException)
    {
    }
}
