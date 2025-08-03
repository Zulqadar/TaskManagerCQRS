using MediatR;
using TaskManagerCQRS.Domain.Entities;

namespace TaskManagerCQRS.Features.Tasks.Queries.GetAllTasks
{
    public record GetAllTasksQuery() : IRequest<List<TaskItem>>;
}
