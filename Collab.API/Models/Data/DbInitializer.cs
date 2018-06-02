using System;
using System.Collections.Generic;
using System.Linq;
using Collab.API.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace Collab.API.Models.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CollabContext context)
        {
            context.Database.EnsureCreated();

            var users = new User[]
            {
                new User() { Nickname = "Abby", Groups = new List<GroupMember>() },
                new User() { Nickname = "James", Groups = new List<GroupMember>() },
                new User() { Nickname = "Eri", Groups = new List<GroupMember>() },
                new User() { Nickname = "Gerald" },
                new User() { Nickname = "Theo" },
                new User() { Nickname = "Woozy" },
                new User() { Nickname = "Kiera" },
                new User() { Nickname = "Saru" },
                new User() { Nickname = "Kyu" },
                new User() { Nickname = "Mar" },
                new User() { Nickname = "Java" },
                new User() { Nickname = "Enigma" },
                new User() { Nickname = "Cera" },
                new User() { Nickname = "Mille" }
            };

            var groups = new Group[]
            {
                new Group() { Name = "Preemptive", Users = new List<GroupMember>() },
                new Group() { Name = "Gaia Addicted", Users = new List<GroupMember>() },
                new Group() { Name = "BTS" }
            };

            var projects = new Project[]
            {
                new Project() { ProjectName = "Close to You", Group = groups[0] },
                new Project() { ProjectName = "Bad Overwatch Players", Group = groups[0] }
            };

            var groupMembers = new GroupMember[]
            {
                new GroupMember() { UserId = 1, User = users[0], GroupId = 1, Group = groups[0] },
                new GroupMember() { UserId = 2, User = users[1], GroupId = 1, Group = groups[0] },
                new GroupMember() { UserId = 3, User = users[2], GroupId = 1, Group = groups[0] },
                new GroupMember() { UserId = 3, User = users[2], GroupId = 2, Group = groups[1] }
            };

            users[0].Groups.Add(groupMembers[0]);
            users[1].Groups.Add(groupMembers[1]);
            users[2].Groups.Add(groupMembers[2]);
            users[2].Groups.Add(groupMembers[3]);

            groups[0].Users.Add(groupMembers[0]);
            groups[0].Users.Add(groupMembers[1]);
            groups[0].Users.Add(groupMembers[2]);
            groups[1].Users.Add(groupMembers[3]);

            if (!context.Users.Any())
            {
                foreach (User u in users)
                {
                    context.Users.Add(u);
                }

                context.SaveChanges();

                foreach (User u in users)
                {
                    context.Entry(u).State = EntityState.Detached;
                }
            }

            if (!context.Groups.Any())
            {
                foreach (Group g in groups)
                {
                    context.Groups.Add(g);
                }

                context.SaveChanges();

                foreach (Group g in groups)
                {
                    context.Entry(g).State = EntityState.Detached;
                }
            }

            if (!context.Projects.Any())
            {
                foreach(Project p in projects)
                {
                    context.Projects.Add(p);
                }
                context.SaveChanges();
                
                foreach(Project p in projects)
                {
                    context.Entry(p).State = EntityState.Detached;
                }
            }


            if (context.GroupMembers.Any())
            {
                foreach (GroupMember gm in groupMembers)
                {
                    context.GroupMembers.Add(gm);
                }

                context.SaveChanges();

                foreach (GroupMember gm in groupMembers)
                {
                    context.Entry(gm).State = EntityState.Detached;
                }
            }

            foreach (User u in users)
            {
                context.Users.Update(u);
                context.Entry(u).State = EntityState.Detached;
            }

            foreach (Group g in groups)
            {
                context.Groups.Update(g);
                context.Entry(g).State = EntityState.Detached;
            }

            context.SaveChanges();
        }
    }
}