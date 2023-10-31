using ScrumProject.Domain.Products.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class SprintInvalidDateException : Exception
{
    internal SprintInvalidDateException() :base(ErrorMessageConstant.SprintInvalidDateException)
    {
    }
}
