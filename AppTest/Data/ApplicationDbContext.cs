﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppTest.Models;
using Microsoft.Extensions.Logging;

namespace AppTest.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<User>("User")
            .HasValue<Admin>("Admin")
            .HasValue<Gestionnaire>("Gestionnaire");
    }
    public DbSet<Admin> admin { get; set; }
public DbSet<Gestionnaire> gestionnaires { get; set; }
public DbSet<AppTest.Models.Candidat> Candidat { get; set; } = default!;

public DbSet<AppTest.Models.BaseResultat> BaseResultat { get; set; } = default!;

public DbSet<AppTest.Models.BaseQuestion> BaseQuestion { get; set; } = default!;

public DbSet<AppTest.Models.Test> Test { get; set; } = default!;

public DbSet<AppTest.Models.ResultatTest> ResultatTest { get; set; } = default!;

public DbSet<AppTest.Models.ResultatCampagne> ResultatCampagne { get; set; } = default!;

public DbSet<AppTest.Models.ReponseRedaction> ReponseRedaction { get; set; } = default!;

public DbSet<AppTest.Models.ReponseQCM> ReponseQCM { get; set; } = default!;

public DbSet<AppTest.Models.ReponseCode> ReponseCode { get; set; } = default!;

public DbSet<AppTest.Models.Entreprise> Entreprise { get; set; } = default!;

public DbSet<AppTest.Models.Campagne> Campagne { get; set; } = default!;

public DbSet<AppTest.Models.BaseTest> BaseTest { get; set; } = default!;

public DbSet<AppTest.Models.BaseReponse> BaseReponse { get; set; } = default!;

public DbSet<AppTest.Models.QuestionCode> QuestionCode { get; set; } = default!;

public DbSet<AppTest.Models.QuestionQCM> QuestionQCM { get; set; } = default!;

public DbSet<AppTest.Models.QuestionRedaction> QuestionRedaction { get; set; } = default!;
}

