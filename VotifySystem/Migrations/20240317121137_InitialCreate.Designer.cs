﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotifyDataAccess.Database;

#nullable disable

namespace VotifySystem.Migrations
{
    [DbContext(typeof(VotifyDatabaseContext))]
    [Migration("20240317121137_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("VotifySystem.Common.Classes.Administrator", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Administrator", (string)null);
                });

            modelBuilder.Entity("VotifySystem.Common.Classes.Candidate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConstituencyId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Party")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Candidate", (string)null);
                });

            modelBuilder.Entity("VotifySystem.Common.Classes.Constituency", b =>
                {
                    b.Property<string>("ConstituencyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConstituencyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ElectionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ConstituencyId");

                    b.ToTable("Constituency", (string)null);
                });

            modelBuilder.Entity("VotifySystem.Common.Classes.ElectionCandidate", b =>
                {
                    b.Property<string>("CandidateId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ElectionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VotesReceived")
                        .HasColumnType("INTEGER");

                    b.ToTable("ElectionCandidate", (string)null);
                });

            modelBuilder.Entity("VotifySystem.Common.Classes.Voter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConstituencyId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Voter", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}