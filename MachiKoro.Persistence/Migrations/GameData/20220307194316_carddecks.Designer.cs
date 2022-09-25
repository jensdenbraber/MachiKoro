﻿// <auto-generated />
using System;
using MachiKoro.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MachiKoro.Data.Migrations.GameData
{
    [DbContext(typeof(GameDataContext))]
    [Migration("20220307194316_carddecks")]
    partial class carddecks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GamePlayer", b =>
                {
                    b.Property<Guid>("GamesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GamesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("GamePlayer", (string)null);
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

                    b.Property<int>("MaxNumberOfPlayers")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartingDecks")
                        .HasColumnType("nvarchar(max)");

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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

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

            modelBuilder.Entity("MachiKoro.Persistence.Models.Step", b =>
                {
                    b.HasOne("MachiKoro.Persistence.Models.Game", "Game")
                        .WithMany("Step")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MachiKoro.Persistence.Models.Player", "Player")
                        .WithMany("Steps")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("MachiKoro.Persistence.Models.Game", b =>
                {
                    b.Navigation("Step");
                });

            modelBuilder.Entity("MachiKoro.Persistence.Models.Player", b =>
                {
                    b.Navigation("Steps");
                });
#pragma warning restore 612, 618
        }
    }
}
