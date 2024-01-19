﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSharpning.com.WebApp.Models;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string> 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
    {

    }
}
