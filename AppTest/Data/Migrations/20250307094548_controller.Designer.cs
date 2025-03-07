﻿// <auto-generated />
using System;
using AppTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppTest.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250307094548_controller")]
    partial class controller
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppTest.Models.BaseQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<int?>("intitule")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("BaseQuestion");

                    b.HasDiscriminator().HasValue("BaseQuestion");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AppTest.Models.BaseReponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int?>("ResultatTestId")
                        .HasColumnType("int");

                    b.Property<int?>("fk_id_question")
                        .HasColumnType("int");

                    b.Property<int?>("fk_id_test")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResultatTestId");

                    b.ToTable("BaseReponse");

                    b.HasDiscriminator().HasValue("BaseReponse");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AppTest.Models.BaseResultat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BaseTestId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.HasKey("Id");

                    b.HasIndex("BaseTestId");

                    b.ToTable("BaseResultat");

                    b.HasDiscriminator().HasValue("BaseResultat");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AppTest.Models.BaseTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int?>("fk_id_entreprise")
                        .HasColumnType("int");

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BaseTest");

                    b.HasDiscriminator().HasValue("BaseTest");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AppTest.Models.Candidat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BaseTestId")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BaseTestId");

                    b.ToTable("Candidat");
                });

            modelBuilder.Entity("AppTest.Models.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entreprise");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AppTest.Models.QuestionCode", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseQuestion");

                    b.HasDiscriminator().HasValue("QuestionCode");
                });

            modelBuilder.Entity("AppTest.Models.QuestionQCM", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseQuestion");

                    b.Property<string>("reponse_correct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reponse_possible")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("QuestionQCM");
                });

            modelBuilder.Entity("AppTest.Models.QuestionRedaction", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseQuestion");

                    b.Property<string>("reponse_correct")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("BaseQuestion", t =>
                        {
                            t.Property("reponse_correct")
                                .HasColumnName("QuestionRedaction_reponse_correct");
                        });

                    b.HasDiscriminator().HasValue("QuestionRedaction");
                });

            modelBuilder.Entity("AppTest.Models.ReponseCode", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseReponse");

                    b.Property<string>("reponse_candidat")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ReponseCode");
                });

            modelBuilder.Entity("AppTest.Models.ReponseQCM", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseReponse");

                    b.Property<string>("reponse_candidat")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("BaseReponse", t =>
                        {
                            t.Property("reponse_candidat")
                                .HasColumnName("ReponseQCM_reponse_candidat");
                        });

                    b.HasDiscriminator().HasValue("ReponseQCM");
                });

            modelBuilder.Entity("AppTest.Models.ReponseRedaction", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseReponse");

                    b.Property<string>("reponse_candidat")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("BaseReponse", t =>
                        {
                            t.Property("reponse_candidat")
                                .HasColumnName("ReponseRedaction_reponse_candidat");
                        });

                    b.HasDiscriminator().HasValue("ReponseRedaction");
                });

            modelBuilder.Entity("AppTest.Models.ResultatCampagne", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseResultat");

                    b.Property<int?>("fk_id_campagne")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ResultatCampagne");
                });

            modelBuilder.Entity("AppTest.Models.ResultatTest", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseResultat");

                    b.Property<int?>("ResultatCampagneId")
                        .HasColumnType("int");

                    b.Property<int?>("fk_id_test")
                        .HasColumnType("int");

                    b.HasIndex("ResultatCampagneId");

                    b.HasDiscriminator().HasValue("ResultatTest");
                });

            modelBuilder.Entity("AppTest.Models.Campagne", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseTest");

                    b.HasDiscriminator().HasValue("Campagne");
                });

            modelBuilder.Entity("AppTest.Models.Test", b =>
                {
                    b.HasBaseType("AppTest.Models.BaseTest");

                    b.Property<int?>("CampagneId")
                        .HasColumnType("int");

                    b.HasIndex("CampagneId");

                    b.HasDiscriminator().HasValue("Test");
                });

            modelBuilder.Entity("AppTest.Models.BaseQuestion", b =>
                {
                    b.HasOne("AppTest.Models.Test", null)
                        .WithMany("liste_question")
                        .HasForeignKey("TestId");
                });

            modelBuilder.Entity("AppTest.Models.BaseReponse", b =>
                {
                    b.HasOne("AppTest.Models.ResultatTest", null)
                        .WithMany("list_reponse")
                        .HasForeignKey("ResultatTestId");
                });

            modelBuilder.Entity("AppTest.Models.BaseResultat", b =>
                {
                    b.HasOne("AppTest.Models.BaseTest", null)
                        .WithMany("liste_resultats")
                        .HasForeignKey("BaseTestId");
                });

            modelBuilder.Entity("AppTest.Models.Candidat", b =>
                {
                    b.HasOne("AppTest.Models.BaseTest", null)
                        .WithMany("liste_candidats")
                        .HasForeignKey("BaseTestId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppTest.Models.ResultatTest", b =>
                {
                    b.HasOne("AppTest.Models.ResultatCampagne", null)
                        .WithMany("liste_resultat")
                        .HasForeignKey("ResultatCampagneId");
                });

            modelBuilder.Entity("AppTest.Models.Test", b =>
                {
                    b.HasOne("AppTest.Models.Campagne", null)
                        .WithMany("liste_test")
                        .HasForeignKey("CampagneId");
                });

            modelBuilder.Entity("AppTest.Models.BaseTest", b =>
                {
                    b.Navigation("liste_candidats");

                    b.Navigation("liste_resultats");
                });

            modelBuilder.Entity("AppTest.Models.ResultatCampagne", b =>
                {
                    b.Navigation("liste_resultat");
                });

            modelBuilder.Entity("AppTest.Models.ResultatTest", b =>
                {
                    b.Navigation("list_reponse");
                });

            modelBuilder.Entity("AppTest.Models.Campagne", b =>
                {
                    b.Navigation("liste_test");
                });

            modelBuilder.Entity("AppTest.Models.Test", b =>
                {
                    b.Navigation("liste_question");
                });
#pragma warning restore 612, 618
        }
    }
}
