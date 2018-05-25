using System;
using System.Linq;
using Collab.API.Models.Context;

namespace Collab.API.Models.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CollabContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User() { Nickname = "Abby" },
                new User() { Nickname = "James" },
                new User() { Nickname = "Eri" },
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

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();
        }
    }
}