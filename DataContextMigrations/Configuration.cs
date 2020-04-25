namespace MVCEventScheduler.DataContextMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVCEventScheduler.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCEventScheduler.DAL.EventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContextMigrations";
        }

        protected override void Seed(MVCEventScheduler.DAL.EventContext context)
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
            users.ForEach(s => context.Users.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();

            var events = new List<EventModel>
            {
                new EventModel{ Id= 1010, EventName="Jimbos Event", EventType="Barn Party", EventHost="Jimbo", Email="jimbo@jelly.com", EventDateTime=DateTime.Parse ("2020-10-20"), IsPublic= true, Location="Traverse City"},
                new EventModel{ Id= 1020, EventName="Billiards", EventType="Sporting", EventHost="Tomato", Email="Tomato@jelly.com", EventDateTime=DateTime.Parse ("2020-09-13"), IsPublic= false, Location="Detroit"},
                new EventModel{ Id= 1030, EventName="Gokart Racing", EventType="Racing", EventHost="Peanut", Email="Peanut@jelly.com", EventDateTime=DateTime.Parse ("2020-01-12"), IsPublic= true, Location="Grand Rapids"},
                new EventModel{ Id= 1040, EventName="Counter Strike tournament", EventType="Gaming", EventHost="cat", Email="cat@jelly.com", EventDateTime=DateTime.Parse ("2020-06-18"), IsPublic= false, Location="Bellaire"},
                new EventModel{ Id= 1050, EventName="Huperts Rodeo", EventType="Rodeo", EventHost="Hupert", Email="hupert@jelly.com", EventDateTime=DateTime.Parse ("2020-03-28"), IsPublic= true, Location="Manton"},
            };
            events.ForEach(s => context.Events.AddOrUpdate(p => p.EventName, s));
            context.SaveChanges();

            var attendances = new List<Attendance>
            {
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Jelly").ID,
                    EventID= events.Single (e => e.EventName == "Counter Strike tournament").Id,
                    Status=Status.Attending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Jelly").ID,
                    EventID= events.Single (e => e.EventName == "Jimbos Event").Id,
                    Status=Status.MaybeAttending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Peanut").ID,
                    EventID= events.Single (e => e.EventName == "Jimbos Event").Id,
                    Status=Status.NotAttending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Potatoe").ID,
                    EventID= events.Single (e => e.EventName == "Huperts Rodeo").Id,
                    Status=Status.NotAttending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Potatoe").ID,
                    EventID= events.Single (e => e.EventName == "Billiards").Id,
                    Status=Status.MaybeAttending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Tomato").ID,
                    EventID= events.Single (e => e.EventName == "Jimbos Event").Id,
                    Status=Status.Attending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Tomato").ID,
                    EventID= events.Single (e => e.EventName == "Gokart Racing").Id,
                    Status=Status.Attending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Butterfly").ID,
                    EventID= events.Single (e => e.EventName == "Huperts Rodeo").Id,
                    Status=Status.Attending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Butterfly").ID,
                    EventID= events.Single (e => e.EventName == "Counter Strike tournament").Id,
                    Status=Status.Attending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "cat").ID,
                    EventID= events.Single (e => e.EventName == "Counter Strike tournament").Id,
                    Status=Status.NotAttending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "cat").ID,
                    EventID= events.Single (e => e.EventName == "Billiards").Id,
                    Status=Status.Attending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Jimbo").ID,
                    EventID= events.Single (e => e.EventName == "Gokart Racing").Id,
                    Status=Status.MaybeAttending},
                new Attendance{
                    UserID= users.Single (u => u.UserName == "Huper").ID,
                    EventID= events.Single (e => e.EventName == "Jimbos Event").Id,
                    Status=Status.MaybeAttending}
            };

            foreach (Attendance e in attendances)
            {
                var attendanceInDataBase = context.Attendances.Where(
                    s =>
                         s.User.ID == e.UserID &&
                         s.Event.Id == e.EventID).SingleOrDefault();
                if (attendanceInDataBase == null)
                {
                    context.Attendances.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
