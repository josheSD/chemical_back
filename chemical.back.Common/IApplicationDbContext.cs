using System.Data;

namespace chemical.back.Common
{
    public interface IApplicationDbContext
    {
        IDbConnection GetConnection { get; }
    }
}
