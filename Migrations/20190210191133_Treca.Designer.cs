﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileAvailability.Models;

namespace MobileAvailability.Migrations
{
    [DbContext(typeof(MobileAvailabilityContext))]
    [Migration("20190210191133_Treca")]
    partial class Treca
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MobileAvailability.Models.Availabilities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cijena");

                    b.Property<bool>("Dostupnost");

                    b.Property<string>("Kontakt")
                        .IsRequired();

                    b.Property<DateTime>("PredajaOglasa");

                    b.Property<int>("ProizvodjacId");

                    b.Property<string>("Tip")
                        .IsRequired();

                    b.Property<int>("TrgovinaId");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodjacId");

                    b.HasIndex("TrgovinaId");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("MobileAvailability.Models.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("MobileAvailability.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Producer");
                });

            modelBuilder.Entity("MobileAvailability.Models.Availabilities", b =>
                {
                    b.HasOne("MobileAvailability.Models.Producer", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileAvailability.Models.Market", "Trgovina")
                        .WithMany()
                        .HasForeignKey("TrgovinaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
