using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerUtils
{
    public static class Numerics
    {
        #region IntRange

        private struct IntRange_Result
        {
            public int Value;
        }

        private static void IntRange_FillValues(object obj, out SqlInt32 intValue)
        {
            IntRange_Result result = (IntRange_Result)obj;
            intValue = result.Value;
        }

        [SqlFunction(IsDeterministic = true, IsPrecise = true, 
            FillRowMethodName = "IntRange_FillValues", TableDefinition = "intValue INT")]
        public static IEnumerable IntRange(SqlInt32 minValue, SqlInt32 maxValue)
        {
            // Check args
            if (minValue.IsNull || maxValue.IsNull)
            {
                yield break; 
            }

            // Compute min & max
            int min = Math.Min(minValue.Value, maxValue.Value);
            int max = Math.Max(minValue.Value, maxValue.Value);

            // Generate the set
            IntRange_Result result = new IntRange_Result();
            for (int i = min; i <= max; i++)
            {
                result.Value = i;
                yield return result;
            }
        }

        #endregion IntRange
    }
}
