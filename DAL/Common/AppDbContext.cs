﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public class AppDbContext : DbContext
    {
        internal DbSet<Store> Store { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        { }
    }
}