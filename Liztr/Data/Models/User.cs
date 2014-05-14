using Liztr.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liztr.Data.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public DateTime Modified { get; set; }

        public List<Event> OwnedEvents { get; set; }

        public string FbId { get; set; }
    }
}