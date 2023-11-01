using MediatR;
namespace ScrumProject.Application.Contract.Products.Commands;

public class RegisterReleaseCommand : IRequest
{
    public string Title { get; set; }
    public int ProductId { get; set; }
}
