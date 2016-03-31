//using Neo4j.Driver.Tests;
using Neo4j.Driver;
using Neo4j.Driver.Internal.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
  public class ResultCreator
  {
    public static StatementResult CreateResult(int keySize, int recordSize = 1, Func<IResultSummary> getSummaryFunc = null)
    {
      var records = new List<Record>(recordSize);

      var keys = new List<string>(keySize);
      for (int i = 0; i < keySize; i++)
      {
        keys.Add($"str{i}");
      }

      for (int j = 0; j < recordSize; j++)
      {
        var values = new List<object>();
        for (int i = 0; i < keySize; i++)
        {
          values.Add(i);
        }
        records.Add(new Record(keys.ToArray(), values.ToArray()));
      }

      return new StatementResult(keys.ToArray(), records, getSummaryFunc);
    }
  }

  class Program
  {
    public static void ShouldConsumeRecordsSequentially()
    {
      var result = ResultCreator.CreateResult(5); // say we have [0, 1, 2, 3, 4] as records in result
      result.Take(2).ToList(); // expecting to get [0, 1] back, PeekingEnumerator.Dispose is called
      //result.Position.Should().Be(1);
    //  result.AtEnd.Should().BeFalse();

      result.Take(3).ToList(); // expecting to get [2, 3, 4], which requires the previous Dispose should do nothing otherwise this one will be affected.
    //  result.Position.Should().Be(4); // with your code we got 1 here currently
    //  result.AtEnd.Should().BeTrue();
    }

    static void Main(string[] args)
    {
      ShouldConsumeRecordsSequentially();
    }
  }
}
