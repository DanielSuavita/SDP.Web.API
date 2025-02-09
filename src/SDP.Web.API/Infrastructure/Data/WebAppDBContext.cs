using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;

namespace SDP.Web.API.Infrastructure.Data
{
    public class WebAppDBContext : DbContext
    {
        public WebAppDBContext(DbContextOptions options) : base(options) { }
    }
}
