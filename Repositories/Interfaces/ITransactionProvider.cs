namespace WebUser.Repositories.Interfaces
{
    public interface ITransactionProvider
    {
        Task DoTransaction(Func<Task> action);
    }
}
