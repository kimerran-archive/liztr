using Liztr.Data.Common;
using Liztr.Data.Models;
using Liztr.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liztr.API
{
    public class LiztrCoreApi
    {
        private IDbRepository _db;
        public LiztrCoreApi(IDbRepository db)
        {
            this._db = db;
        }

        public static string Version()
        {
            return "1.0.0.0";
        }

        public Event CreateEvent(Event e)
        {
            e.Modified = DateTime.Now;
            e.UrlShortName = Utility.ToSeoFriendly(e.Name,50);

           return _db.Create<Event>(e);
        }
        public Event ReadEvent(int id)
        {
            return _db.Retrieve<Event>(id,"Registrations");
        }
        public Event UpdateEvent(Event e)
        {

            Event updatedEvent = _db.Retrieve<Event>(e.Id);
            updatedEvent.Name = e.Name;
            updatedEvent.UrlShortName = e.UrlShortName;
            updatedEvent.Details = e.Details;
            updatedEvent.Field1 = e.Field1;
            updatedEvent.Field2 = e.Field2;
            updatedEvent.Field3 = e.Field3;
            updatedEvent.EndDate = Convert.ToDateTime(e.EndDateString);
            updatedEvent.StartDate = Convert.ToDateTime(e.StartDateString);
            updatedEvent.Modified = DateTime.Now;

            if (_db.Update<Event>(updatedEvent) > 0) 
                return e;
            return null;
        }

        public Event DeleteEvent(Event e)
        {
            if (_db.Delete<Event>(e) > 0) 
                return e;
            return null;
        }

        public Registration CreateRegistration(Registration r)
        {
            r.Modified = DateTime.Now;

            return _db.Create<Registration>(r);
        }

        public Registration ReadRegistration(int id)
        {
            return _db.Retrieve<Registration>(id);
        }

        public Registration UpdateRegistration(Registration r)
        {
            if (_db.Update<Registration>(r) > 0)
                return r;
            return null;
        }

        public Registration DeleteRegistration(Registration r)
        {
            if (_db.Delete<Registration>(r) > 0)
                return r;
            return null;
        }

        public List<Event> QueryAllEvents()
        {
            return _db.QueryAll<Event>();
        }
    }
}