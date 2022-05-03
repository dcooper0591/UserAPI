﻿using FSPUserApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FSPUserApi.EntityFramework
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
