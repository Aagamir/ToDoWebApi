﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Entities;

namespace ToDo
{
    public class Seeder
    {
        private readonly Context _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public Seeder(Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Users.Any())
                {
                    var user = GetUser();
                    _context.Users.AddRange(user);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<User> GetUser()
        {
            var user = new List<User>()
            {
                new User()
                {
                    Name = "Admin",
                    Email = "admin@mail.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEN56MrKWxapOO6uTo1MrGF+Z+NVqkXp4+/FapvV0h9Il7zTOvEeUIx5hItADNnIOlw==",
                    Role = Enums.Role.Admin,
                    Tasks = null
                },
                new User()
                {
                    Name = "User",
                    Email = "user@mail.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEHTWepoeqz/z68vQrf2Fh1fnyHe821JUc36KRidq60eu9tnspawPVmN4dm7F8BKsSw==",
                    Role = Enums.Role.User,
                    Tasks = null
                }
            };
            return user;
        }
    }
}