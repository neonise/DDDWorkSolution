using ScrumProject.Domain.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class InvalidIntervalDateException : Exception
{
    internal InvalidIntervalDateException() : base(ErrorMessageConstant.InvalidIntervalDateException)
    {
    }
}
