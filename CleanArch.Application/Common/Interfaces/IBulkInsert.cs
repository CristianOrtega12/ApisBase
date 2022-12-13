using System;
using System.Data;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IBulkInsert
    {
        Task TruncateTable(string table);
        Task TruncateTable(string table, Guid UserId);
        Task<DataTable> Bulk(DataTable dt);
        void setTemporalTable(string table);
        Task<DataTable> ExecuteStore(string store);
    }
}
