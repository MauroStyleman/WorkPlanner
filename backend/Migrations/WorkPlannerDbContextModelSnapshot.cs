﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Workplanner.DAL;

#nullable disable

namespace Workplanner.Migrations
{
    [DbContext(typeof(WorkPlannerDbContext))]
    partial class WorkPlannerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Workplanner.Domain.PlanningPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("End")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateOnly>("Start")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("PlanningPeriods");
                });

            modelBuilder.Entity("Workplanner.Domain.PlanningShift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlanningPeriodId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShiftId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanningPeriodId");

                    b.HasIndex("ShiftId");

                    b.HasIndex("UserId");

                    b.ToTable("PlanningShifts");
                });

            modelBuilder.Entity("Workplanner.Domain.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("End")
                        .HasColumnType("time without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<TimeOnly>("Start")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Workplanner.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Workplanner.Domain.PlanningShift", b =>
                {
                    b.HasOne("Workplanner.Domain.PlanningPeriod", "PlanningPeriod")
                        .WithMany("PlanningShifts")
                        .HasForeignKey("PlanningPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workplanner.Domain.Shift", "Shift")
                        .WithMany("PlanningShifts")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workplanner.Domain.User", "User")
                        .WithMany("PlanningShifts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanningPeriod");

                    b.Navigation("Shift");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Workplanner.Domain.PlanningPeriod", b =>
                {
                    b.Navigation("PlanningShifts");
                });

            modelBuilder.Entity("Workplanner.Domain.Shift", b =>
                {
                    b.Navigation("PlanningShifts");
                });

            modelBuilder.Entity("Workplanner.Domain.User", b =>
                {
                    b.Navigation("PlanningShifts");
                });
#pragma warning restore 612, 618
        }
    }
}
