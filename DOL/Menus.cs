using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    #region Menu Class Defination
    public class Menus
    {
        #region Propreties
        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Menu { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsAdminMenu { get; set; }
        public int[] SelectedGroups { get; set; }
        #endregion
    }
    #endregion
}
