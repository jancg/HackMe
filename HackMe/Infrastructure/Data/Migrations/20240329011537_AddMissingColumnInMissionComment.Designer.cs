﻿// <auto-generated />
using System;
using HackMe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HackMe.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240329011537_AddMissingColumnInMissionComment")]
    partial class AddMissingColumnInMissionComment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HackMe.Application.Models.Agent", b =>
                {
                    b.Property<string>("CodeName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ActiveMission")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDecommissioned")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PersonalData")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Ranking")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("TotalSuccessfulMissions")
                        .HasColumnType("int");

                    b.HasKey("CodeName");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("HackMe.Application.Models.ChallengeResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgentCodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ChallangeTaskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CompletedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgentCodeName");

                    b.HasIndex("ChallangeTaskId");

                    b.ToTable("ChallengeResult");
                });

            modelBuilder.Entity("HackMe.Application.Models.ChallengeTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<string>("ExpectedResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChallengeTask");
                });

            modelBuilder.Entity("HackMe.Application.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsClassified")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UrlKey")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Mission");
                });

            modelBuilder.Entity("HackMe.Application.Models.MissionComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgentCodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MissionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgentCodeName");

                    b.HasIndex("MissionId");

                    b.ToTable("MissionComment");
                });

            modelBuilder.Entity("HackMe.Application.Models.ChallengeResult", b =>
                {
                    b.HasOne("HackMe.Application.Models.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentCodeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackMe.Application.Models.ChallengeTask", "ChallengeTask")
                        .WithMany("Results")
                        .HasForeignKey("ChallangeTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("ChallengeTask");
                });

            modelBuilder.Entity("HackMe.Application.Models.MissionComment", b =>
                {
                    b.HasOne("HackMe.Application.Models.Agent", "Agent")
                        .WithMany("Comments")
                        .HasForeignKey("AgentCodeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HackMe.Application.Models.Mission", "Mission")
                        .WithMany()
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Mission");
                });

            modelBuilder.Entity("HackMe.Application.Models.Agent", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("HackMe.Application.Models.ChallengeTask", b =>
                {
                    b.Navigation("Results");
                });
#pragma warning restore 612, 618
        }
    }
}
