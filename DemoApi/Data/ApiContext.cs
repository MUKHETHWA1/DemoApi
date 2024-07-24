﻿using Microsoft.EntityFrameworkCore;
using DemoApi.Models;

namespace DemoApi.Data
{
    public class ApiContext: DbContext
    {
        public DbSet<HotelBooking> Bookings { get; set; }
        public ApiContext(DbContextOptions<ApiContext>options)
            :base(options)
        {
        
        }

    }
}
