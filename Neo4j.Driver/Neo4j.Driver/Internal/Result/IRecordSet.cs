﻿using System.Collections.Generic;

namespace Neo4j.Driver.Internal.Result
{
    // TODO: Document me
    // TODO: Should this be IDisposable??
    public interface IRecordSet
    {
        bool AtEnd { get; }
        int Position { get; }
        Record Peek { get; }
        IEnumerable<Record> Records { get; }
    }
}