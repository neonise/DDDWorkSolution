using ScrumProject.Domain.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class BackLogDuplicateException : Exception
{
    internal BackLogDuplicateException():base(ErrorMessageConstant.BackLogDuplicateException)
    {
    }
}
