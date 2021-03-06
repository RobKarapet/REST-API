﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PersistenceLayer;
using System;

namespace PersistenceLayer.Migrations
{
    [DbContext(typeof(Program.TripContext))]
    partial class TripContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersistenceLayer.Program+Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("LicenseNumber");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PersistenceLayer.Program+Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeId");

                    b.Property<int>("FinalOdometer");

                    b.Property<DateTime>("FinishTime");

                    b.Property<int>("InitialOdometer");

                    b.Property<string>("ProjectFunction");

                    b.Property<string>("ProjectTitle");

                    b.Property<string>("Purpose");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("TaskOrder");

                    b.Property<string>("TripPath");

                    b.Property<int?>("VehicleId");

                    b.HasKey("TripId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("PersistenceLayer.Program+Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<DateTime>("LastService");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("ModelTrim");

                    b.Property<DateTime>("ModelYear");

                    b.Property<DateTime>("NextService");

                    b.Property<int>("Odometer");

                    b.Property<string>("PlateNumber");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("PersistenceLayer.Program+Trip", b =>
                {
                    b.HasOne("PersistenceLayer.Program+Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("PersistenceLayer.Program+Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });
#pragma warning restore 612, 618
        }
    }
}
