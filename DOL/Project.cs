using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOL
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime createdTime { get; set; }
    }
    [Serializable]
    public class Zone
    {
        public int ZoneId { get; set; }

        public string ZoneName { get; set; }

        
    }

    [Serializable]
    public class Batch
    {
        public int BatchId { get; set; }

        public string BatchName { get; set; }
    }

    //public class A246CMachines
    //{
    //    public int MachineId { get; set; }

    //    public string Machine { get; set; }
    //}
    //[Serializable]
    //public class ProdModule
    //{
    //    public int ModuleId { get; set; }

    //    public string Module { get; set; }
    //}
    //[Serializable]
    //public class ProductionLineLeader
    //{
    //    public int ProdId { get; set; }

    //    public string LineLeader { get; set; }

        
    //}

    public class Status
    {
        public int StatusId { get; set; }

        public string Statuss { get; set; }
    }

    //public class Location
    //{
    //    public int LocationId { get; set; }

    //    public string Locations { get; set; }
    //}

    public class InspectorCategory
    {
        public int categoryId { get; set; }

        public string category { get; set; }

    }

    public class InspectorSS
    {
        public int InspecId { get; set; }

        public string Inspector { get; set; }

    }

    public class DestructiveFrequency
    {
        public int FrequencyId { get; set; }

        public string Frequency { get; set; }

        public string CreatedBy { get; set; }

        public int ProjectId { get; set; }
    }

  public class Freqq
  {
      public int FreqId { get; set; }

      public string Freq { get; set; }
  }

public class OutInspection
{
    public int ItemId { get; set; }

    public int SpecId { get; set; }

    public int ContentId { get; set; }

    public int ShiftId { get; set; }

    public int LineId { get; set; }

    public int ApprovalId { get; set; }

    public int Result { get; set; }

    public int CreatedBy { get; set; }
}
public class PartToInspect
{
    public int InspectId { get; set; }

    public string Sno { get; set; }

    public string parts { get; set; }

    public int ProjectId { get; set; }

    public string CreatedBy { get; set; }
}

    public class Sections
    {
        public int SectionId { get; set; }

        public string Section { get; set; }
    }

    public class DestructiveWire
    {
        public int InspectionId { get; set; }

        public int WireId { get; set; }

        public int ProjectId { get; set; }

        public string Wire { get; set; }

        public string CreatedBy { get; set; }
    }

    public class DestructiveSpec
    {
        public int FrequencyId { get; set; }

        public string InspectionItem { get; set; }

        public int ProjectId { get; set; }

        public int WireId { get; set; }
        public int InspectionId { get; set; }

        public Decimal? Spec { get; set; }

        public Decimal? LSL { get; set; }

        public string CreatedBy { get; set; }

        
    }
public class InspectorDetailss
{
    public int DetailsId { get; set; }

    public int InspectId { get; set; }
    public int InspecId { get; set; }
    public string InspectorDetails { get; set; }

    public int ProjectId { get; set; }

    public string CreatedBy { get; set; }
}

    //public class Status
    //{
    //    public int StatusId { get; set; }

    //    //public string Status { get; set; }
    //}
    
}
