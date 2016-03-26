using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Neo4j.Driver.Internal
{
    public abstract class StatementRunner 
    {
        protected StatementRunner() 
        {
        }

        public abstract IStatementResult Run(string statement, IDictionary<string, object> parameters = null);

        public IStatementResult Run(Statement statement)
        {
            return Run(statement.Template, statement.Parameters);
        }

        public IStatementResult Run(string statement, object parameters)
        {
            var paramDictionary = parameters.GetType().GetRuntimeProperties()
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(parameters, null));
            return Run(statement, paramDictionary);
        }
    }
}