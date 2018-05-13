using System;
using System.Linq;
using Collab.Models.Context;

namespace Collab.Models.Data
{
    public class DbInitializer
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
                new User() { Id = 1, Nickname = "Abby" },
                new User() { Id = 2, Nickname = "James" },
                new User() { Id = 3, Nickname = "Eri" },
                new User() { Id = 4, Nickname = "Gerald" },
                new User() { Id = 5, Nickname = "Theo" },
                new User() { Id = 6, Nickname = "Woozy" },
                new User() { Id = 7, Nickname = "Kiera" },
                new User() { Id = 8, Nickname = "Saru" },
                new User() { Id = 9, Nickname = "Kyu" },
                new User() { Id = 10, Nickname = "Mar" },
                new User() { Id = 11, Nickname = "Java" },
                new User() { Id = 12, Nickname = "Enigma" },
                new User() { Id = 13, Nickname = "Cera" },
                new User() { Id = 14, Nickname = "Mille" }
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();
        }
    }
}