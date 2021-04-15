using System;
using System.Collections.Generic;
using System.Text;
using static TST.CORE.Structs.PaginationStructs;

namespace TST.CORE.Services.Interfaces
{
    public interface IPaginationService
    {
        int GetRecordsPerDraw();
        int GetPage();
        string GetSearchValue();
        SentParameters GetSentParameters();
    }
}
