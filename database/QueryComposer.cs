using System;
using System.Data.Common;
using Npgsql;

namespace dblaba.Database
{
    public static class QueryComposer
    {
        public static void Init(bool flagCreateNotForced, bool flagCreateForced) {
            QueryBuilder.Init(flagCreateNotForced, flagCreateForced);
        }
    }
}

