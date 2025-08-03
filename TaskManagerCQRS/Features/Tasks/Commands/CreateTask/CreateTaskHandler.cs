using MediatR;
using TaskManagerCQRS.Data;
using TaskManagerCQRS.Domain.Entities;

namespace TaskManagerCQRS.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly AppDbContext _context;
        public CreateTaskHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                IsCompleted = false
            };
            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync(cancellationToken);
            return taskItem.Id;
        }
    }
}
