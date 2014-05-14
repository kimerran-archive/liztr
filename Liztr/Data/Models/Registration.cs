using Liztr.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Liztr.Data.Models
{
    public class Registration : IEntity
    {
        public int Id { get; set; }

        [ScriptIgnore]
        public Event Event { get; set; }

       [ScriptIgnore]
        public User RegisteredBy { get; set; }
        public string RegistrantName { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public DateTime Modified { get; set; }
    }
}