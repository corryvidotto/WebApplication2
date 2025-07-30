using MediatR;

namespace WebApplication2.Application.Commands
{
    public class CreateResourceBookCommand
    {
        public record CreateBookCommand(Guid ResourceId, string Title, string Author, int TotalPages) : IRequest<Guid>;
    }
}
