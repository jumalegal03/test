using System;
using System.Collections.Generic;
using System.Text;
using static TST.CORE.Structs.Select2Structs;

namespace TST.CORE.Services.Interfaces
{
    public interface ISelect2Service
    {
        int GetCurrentPage();
        string GetQuery();
        string GetRequestType();
        string GetSearchTerm();
        RequestParameters GetRequestParameters();
    }
}
