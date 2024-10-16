﻿// <auto-generated />
using DigiProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigiProject.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20241011140303_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DigiProject.Models.Weather", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<double>("Elevation")
                        .HasColumnType("float");

                    b.Property<double>("Generationtime_ms")
                        .HasColumnType("float");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Timezone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Timezone_abbreviation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Utc_offset_seconds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeatherForecast");
                });

            modelBuilder.Entity("DigiProject.Models.Weather", b =>
                {
                    b.OwnsOne("DigiProject.Models.Hourly", "Hourly", b1 =>
                        {
                            b1.Property<long>("WeatherId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Temperature_2m")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Time")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WeatherId");

                            b1.ToTable("WeatherForecast");

                            b1.WithOwner()
                                .HasForeignKey("WeatherId");
                        });

                    b.OwnsOne("DigiProject.Models.HourlyUnits", "Hourly_units", b1 =>
                        {
                            b1.Property<long>("WeatherId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Temperature_2m")
                                .IsRequired()
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Time")
                                .IsRequired()
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("WeatherId");

                            b1.ToTable("WeatherForecast");

                            b1.WithOwner()
                                .HasForeignKey("WeatherId");
                        });

                    b.Navigation("Hourly")
                        .IsRequired();

                    b.Navigation("Hourly_units")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
