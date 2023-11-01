using MediatR;

namespace ScrumProject.Application.Contract.Products.Commands;
public class RegisterSprintCommand : IRequest
{
    public string Title { get; set; }
    public DateTime ToDate { get; set; }
    public DateTime FromDate { get; set; }
    public int ReleaseId { get; set; }
}
