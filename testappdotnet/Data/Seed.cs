using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using testappdotnet.Models;

namespace testappdotnet.Data
{
    public class Seed
    {
        public static object CreatePasswordHash { get; private set; }

        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any<User>())
            {
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    createPasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    context.Users.Add(user);

                }

                context.SaveChanges();
            }
        }

        private static void createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //using(blabla){disposable} ensures to call the dispose method of HMAC to dispose "disposable" 
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
