using System;
using System.Collections.Generic;
using System.Text;
using static TST.CORE.Structs.DataTablesStructs;

namespace TST.CORE.Services.Interfaces
{
    public interface IDataTableService
    {
        int GetDrawCounter();
        string GetOrderColumn();
        string GetOrderDirection();
        int GetPagingFirstRecord();
        int GetRecordsPerDraw();
        string GetSearchValue();
        SentParameters GetSentParameters();
        object GetPaginationObject<T>(int recordsFiltered, IEnumerable<T> data);
    }
}
