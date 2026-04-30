using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ChecklistForm.Utils
{
    public class Converters
    {
        public string ConvertToJson(DataTable inputDT)
        {
            string jsonString = string.Empty;
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in inputDT.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in inputDT.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            jsonString = serializer.Serialize(rows);

            return jsonString;
        }
    }
}