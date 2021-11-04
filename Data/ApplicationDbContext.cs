using Controle_Escolas_e_Alunos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Escolas_e_Alunos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Escolas> Escolas { get; set; }
        public DbSet<Alunos> Alunos { get; set; }

    }
}
