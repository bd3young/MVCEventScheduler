using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCEventScheduler.Models;

namespace MVCEventScheduler.DAL
{
    public class EventInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EventContext>
    {
        protected override void Seed(EventContext context)
        {
            var users = new List<User>
            {
                new User{UserName="Jelly", Location="Traverse City", Email="jelly@jelly.com"},
                new User{UserName="Peanut", Location="Grand Rapids", Email="peanut@jelly.com"},
                new User{UserName="Potatoe", Location="Grawn", Email="potatoe@jelly.com"},
                new User{UserName="Tomato", Location="Detroit", Email="tomatoe@jelly.com"},
                new User{UserName="Butterfly", Location="Escanaba", Email="butterfly@jelly.com"},
                new User{UserName="cat", Location="Big Rapids", Email="cat@jelly.com"},
                new User{UserName="Jimbo", Location="Petosky", Email="jimbo@jelly.com"},
                new User{UserName="Huper", Location="Battle Creek", Email="hupert@jelly.com"}
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var events = new List<EventModel>
            {
                new EventModel{ Id= 1010, EventName="Jimbos Event", EventType="Barn Party", EventHost="Jimbo", Email="jimbo@jelly.com", EventDateTime=DateTime.Parse ("2020-10-20"), IsPublic= true, Location="Traverse City"},
                new EventModel{ Id= 1020, EventName="Billiards", EventType="Sporting", EventHost="Tomato", Email="Tomato@jelly.com", EventDateTime=DateTime.Parse ("2020-09-13"), IsPublic= false, Location="Detroit"},
                new EventModel{ Id= 1030, EventName="Gokart Racing", EventType="Racing", EventHost="Peanut", Email="Peanut@jelly.com", EventDateTime=DateTime.Parse ("2020-01-12"), IsPublic= true, Location="Grand Rapids"},
                new EventModel{ Id= 1040, EventName="Counter Strike tournament", EventType="Gaming", EventHost="cat", Email="cat@jelly.com", EventDateTime=DateTime.Parse ("2020-06-18"), IsPublic= false, Location="Bellaire"},
                new EventModel{ Id= 1050, EventName="Huperts Rodeo", EventType="Rodeo", EventHost="Hupert", Email="hupert@jelly.com", EventDateTime=DateTime.Parse ("2020-03-28"), IsPublic= true, Location="Manton"},
            };

            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var attendances = new List<Attendance>
            {
                new Attendance{UserID= 1, EventID= 1050, Status=Status.Attending},
                new Attendance{UserID= 1, EventID= 1020, Status=Status.MaybeAttending},
                new Attendance{UserID= 2, EventID= 1050, Status=Status.NotAttending},
                new Attendance{UserID= 3, EventID= 1010, Status=Status.NotAttending},
                new Attendance{UserID= 3, EventID= 1050, Status=Status.MaybeAttending},
                new Attendance{UserID= 4, EventID= 1030, Status=Status.Attending},
                new Attendance{UserID= 4, EventID= 1040, Status=Status.Attending},
                new Attendance{UserID= 5, EventID= 1050, Status=Status.Attending},
                new Attendance{UserID= 5, EventID= 1020, Status=Status.Attending},
                new Attendance{UserID= 6, EventID= 1010, Status=Status.NotAttending},
                new Attendance{UserID= 6, EventID= 1040, Status=Status.Attending},
                new Attendance{UserID= 7, EventID= 1030, Status=Status.MaybeAttending},
                new Attendance{UserID= 8, EventID= 1040, Status=Status.MaybeAttending}
            };

            attendances.ForEach(at => context.Attendances.Add(at));
            context.SaveChanges();
        }
    }
}