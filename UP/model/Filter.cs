using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP.model
{
    public class Filter
    {
        public static string GenerateFullFilter(List<string> filters)
        {
            string str = "";

            for (int i =0; i < filters.Count; i++)
            {
                if (filters[i] != "")
                {
                    if (str == "")
                        str += "(" + filters[i] + ")";
                    else
                        str += " and (" + filters[i] + ")";
                }
            }

            return str;
        }
        public static string GenerateFilterString(bool[] filter, string ColumnName, string[] enumStr)
        {
            string str = "";

            if (enumStr.Length != filter.Length)
            {
                throw new ArgumentException();
            }
            for (int i =0 ; i < filter.Length; i++ )
            {
                if (str == "" && filter[i])
                {
                    str += "`" + ColumnName + "`" + " = " + "'" + enumStr[i] + "'"; 
                }
                else if(filter[i])
                {
                    str += " or " + "`" + ColumnName + "`" + " = " + "'" + enumStr[i] + "'";
                }
            }

            if (str != "") 
                str = "( " + str + " )";
            return str;
        }
    }
}
