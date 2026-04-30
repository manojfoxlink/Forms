using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChecklistForm.Utils
{
    public class ExportTypesClass
    {
        public List<string> GetExportTypes()
        {
            List<string> Types = new List<string>();
            Types.Add("PDF");
            Types.Add("EXCEL");
            Types.Add("WORD");
            return Types;

        }
    }
}