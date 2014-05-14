using Liztr.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Liztr.Data.Models
{
    public class Event : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Details { get; set; }
        public User OwnedBy { get; set; }
        public string UrlShortName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Modified { get; set; }

        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }

        public List<Registration> Registrations { get; set; }


        [NotMapped]
        public string StartDateString { get ; set;}

        [NotMapped]        
        public string EndDateString { get; set; }

    }
}