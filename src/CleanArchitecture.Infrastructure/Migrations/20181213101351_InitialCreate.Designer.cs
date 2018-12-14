﻿// <auto-generated />
using System;
using Hogstorp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hogstorp.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181213101351_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hogstorp.Core.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Hogstorp.Core.Entities.PlayerTraining", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("TrainingId");

                    b.Property<int>("Points");

                    b.HasKey("PlayerId", "TrainingId");

                    b.HasIndex("TrainingId");

                    b.ToTable("PlayerTrainings");
                });

            modelBuilder.Entity("Hogstorp.Core.Entities.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsDone");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("ToDoItems");
                });

            modelBuilder.Entity("Hogstorp.Core.Entities.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Indoors");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Hogstorp.Core.Entities.PlayerTraining", b =>
                {
                    b.HasOne("Hogstorp.Core.Entities.Player", "Player")
                        .WithMany("PlayerTrainings")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hogstorp.Core.Entities.Training", "Training")
                        .WithMany("PlayersTrainings")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}