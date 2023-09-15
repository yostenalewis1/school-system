using System;
using System.Data;

namespace school_system
{
    internal class Sqlcommand
    {
        internal object connection;

        public CommandType CommandType { get; internal set; }
        public Action CommandText { get; internal set; }

        internal IDataReader ExecuteReader() => throw new NotImplementedException();
    }
}