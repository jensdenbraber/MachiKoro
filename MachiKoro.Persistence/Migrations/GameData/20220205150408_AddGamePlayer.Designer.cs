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
    [Migration("20220205150408_AddGamePlayer")]
    partial class AddGamePlayer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("GamePlayer");
                });

            modelBuilder.Entity("MachiKoro.Persistence.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpensionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("MachiKoro.Persistence.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("MachiKoro.Persistence.Models.Step", b =>
                {
                    b.Property<int?>("ActionType")
                        .HasColumnType("int");

                    b.Property<int?>("ChoiceType")
                        .HasColumnType("int");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StepIndex")
                        .HasColumnType("int");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.HasOne("MachiKoro.Persistence.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachiKoro.Persistence.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
