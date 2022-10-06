using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FloorForce2.Models;

    public class MvcFloorContext : DbContext
    {
        public MvcFloorContext (DbContextOptions<MvcFloorContext> options)
            : base(options)
        {
        }

        public DbSet<FloorForce2.Models.Floor> Floor { get; set; } = default!;
    }
