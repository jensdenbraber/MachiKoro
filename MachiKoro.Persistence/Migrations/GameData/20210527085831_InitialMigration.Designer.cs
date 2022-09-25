﻿// <auto-generated />
using System;
using MachiKoro.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MachiKoro.Data.Migrations.GameData
{
    [DbContext(typeof(GameDataContext))]
    [Migration("20210527085831_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MachiKoro.Data.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPlayed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MachiKoro.Data.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GamesLost")
                        .HasColumnType("int");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("GamesWon")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("MachiKoro.Data.Models.Player", b =>
                {
                    b.HasOne("MachiKoro.Data.Models.Game", null)
                        .WithMany("Players")
                        .HasForeignKey("GameId");
                });
#pragma warning restore 612, 618
        }
    }
}
