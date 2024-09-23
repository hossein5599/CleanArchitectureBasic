using Microsoft.Data.SqlClient;

namespace CA.Blocks.Application.Common.Interfaces;

public interface IApplicationDBContext
{
    Task ExecuteStoredProcedureAsync(string storedProcedureName, CancellationToken cancellationToken, params SqlParameter[] parameters);
    Task<TResult?> ExecuteStoredProcedureGetAsync<TResult>(string storedProcedureName, CancellationToken cancellationToken, params SqlParameter[] parameters);
    Task<IReadOnlyList<TResult>> ExecuteStoredProcedureListAsync<TResult>(string storedProcedureName, CancellationToken cancellationToken, params SqlParameter[] parameters);
    Task<TResult?> QueryGetAsync<TResult>(string query, CancellationToken cancellationToken);
    Task<IReadOnlyList<TResult>> QueryListAsync<TResult>(string query, CancellationToken cancellationToken);
}
