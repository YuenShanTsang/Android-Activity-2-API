using System;
using System.Collections.Generic;

namespace Android_Activity_2_API.Model
{
    public class CanadaHoliday
    {

        public int ID { get; set; }

        public string Date { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public bool IsFederal { get; set; }

        public string ObservedDate { get; set; }

        public List<CanadaProvince> Provinces { get; set; }
    }

    public class CanadaProvince
    {

        public string ID { get; set; }

        public string NameEn { get; set; }

        public string NameFr { get; set; }

        public string SourceLink { get; set; }

        public string SourceEn { get; set; }
    }

    public class Holiday
    {
        public List<CanadaHoliday> holidays { get; set; }
    }

}
