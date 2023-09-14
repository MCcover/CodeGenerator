using CodeGenerator.DatabaseConnectors.Connectors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.MethodsOfExtensions
{

    public static class DbCommandExtension
    {

        public static void AddParameter(this DbCommand cmd, string nameParameter, object value, DbType dbType)
        {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = nameParameter;
            parameter.Value = value;
            parameter.DbType = dbType;

            cmd.Parameters.Add(parameter);
        }
    }
}