using MediatR;

namespace TaskManagerCQRS.Features.Tasks.Commands.CreateTask
{
    public record CreateTaskCommand(string Title) : IRequest<Guid>;
}
