using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagerCQRS.Data;
using TaskManagerCQRS.Domain.Entities;

namespace TaskManagerCQRS.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksHandler: IRequestHandler<GetAllTasksQuery, List<TaskItem>>
    {
        private readonly AppDbContext _context;
        public GetAllTasksHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Tasks.ToListAsync(cancellationToken);
        }
    }
}
