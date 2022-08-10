namespace Five.Core.Interfaces.Base
{
    public interface IBaseRepository
    {
        Task<IDbTransaction> BeginTransactionAsync();
        IDbTransaction BeginTransaction();
    }
}