﻿using ScrumProject.Domain.Constants;

namespace ScrumProject.Domain.Products.Exceptions;

internal class SprintInvalidDateException : Exception
{
    internal SprintInvalidDateException() :base(ErrorMessageConstant.SprintInvalidDateException)
    {
    }
}
