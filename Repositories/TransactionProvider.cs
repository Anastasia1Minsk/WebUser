using WebUser.Data;
using WebUser.Repositories.Interfaces;

namespace WebUser.Repositories
{
    public class TransactionProvider : ITransactionProvider
    {
        private readonly DataContext _context;

        public TransactionProvider(DataContext context)
        {
            _context = context;
        }

        public async Task DoTransaction(Func<Task> action)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            await action();
            await transaction.CommitAsync();
        }
    }
}
