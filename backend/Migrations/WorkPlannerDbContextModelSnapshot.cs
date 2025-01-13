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

            modelBuilder.Entity("Workplanner.Domain.Day", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("PlanningPeriodId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanningPeriodId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("Workplanner.Domain.DayShift", b =>
                {
                    b.Property<Guid>("DayId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShiftId")
                        .HasColumnType("uuid");

                    b.HasKey("DayId", "ShiftId");

                    b.HasIndex("ShiftId");

                    b.ToTable("DayShifts");
                });

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

            modelBuilder.Entity("Workplanner.Domain.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DayId")
                        .HasColumnType("uuid");

                    b.Property<TimeOnly>("End")
                        .HasColumnType("time without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<TimeOnly>("Start")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Workplanner.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Workplanner.Domain.Day", b =>
                {
                    b.HasOne("Workplanner.Domain.PlanningPeriod", "PlanningPeriod")
                        .WithMany("Days")
                        .HasForeignKey("PlanningPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanningPeriod");
                });

            modelBuilder.Entity("Workplanner.Domain.DayShift", b =>
                {
                    b.HasOne("Workplanner.Domain.Day", "Day")
                        .WithMany("DayShifts")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workplanner.Domain.Shift", "Shift")
                        .WithMany("DayShifts")
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Workplanner.Domain.Shift", b =>
                {
                    b.HasOne("Workplanner.Domain.Day", "Day")
                        .WithMany()
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");
                });

            modelBuilder.Entity("Workplanner.Domain.Day", b =>
                {
                    b.Navigation("DayShifts");
                });

            modelBuilder.Entity("Workplanner.Domain.PlanningPeriod", b =>
                {
                    b.Navigation("Days");
                });

            modelBuilder.Entity("Workplanner.Domain.Shift", b =>
                {
                    b.Navigation("DayShifts");
                });
#pragma warning restore 612, 618
        }
    }
}
