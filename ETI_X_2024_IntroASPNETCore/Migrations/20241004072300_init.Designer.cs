﻿// <auto-generated />
using System;
using ETI_X_2024_IntroASPNETCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ETI_X_2024_IntroASPNETCore.Migrations
{
    [DbContext(typeof(ETI_X_2024_IntroASPNETCoreContext))]
    [Migration("20241004072300_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Kategoria", b =>
                {
                    b.Property<int>("KategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriaId"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriaId");

                    b.ToTable("Kategoria");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Kolor", b =>
                {
                    b.Property<int>("KolorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KolorId"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KolorId");

                    b.ToTable("Kolor");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Marka", b =>
                {
                    b.Property<int>("MarkaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkaId"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarkaId");

                    b.ToTable("Marka");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelId"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModelId");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Produkt", b =>
                {
                    b.Property<int>("ProduktId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduktId"));

                    b.Property<float>("Cena")
                        .HasColumnType("real");

                    b.Property<int?>("KategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProduktId");

                    b.HasIndex("KategoriaId");

                    b.ToTable("Produkt");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.RodzajSilnika", b =>
                {
                    b.Property<int>("RodzajSilnikaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RodzajSilnikaId"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RodzajSilnikaId");

                    b.ToTable("RodzajSilnika");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Samochod", b =>
                {
                    b.Property<int>("SamochodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SamochodId"));

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int?>("KolorId")
                        .HasColumnType("int");

                    b.Property<int?>("MarkaId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("Przebieg")
                        .HasColumnType("int");

                    b.Property<int?>("RodzajSilnikaId")
                        .HasColumnType("int");

                    b.Property<int>("RokProdukcji")
                        .HasColumnType("int");

                    b.HasKey("SamochodId");

                    b.HasIndex("KolorId");

                    b.HasIndex("MarkaId");

                    b.HasIndex("ModelId");

                    b.HasIndex("RodzajSilnikaId");

                    b.ToTable("Samochod");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Produkt", b =>
                {
                    b.HasOne("ETI_X_2024_IntroASPNETCore.Models.Kategoria", "Kategoria")
                        .WithMany("Produkts")
                        .HasForeignKey("KategoriaId");

                    b.Navigation("Kategoria");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Samochod", b =>
                {
                    b.HasOne("ETI_X_2024_IntroASPNETCore.Models.Kolor", "Kolor")
                        .WithMany("Samochods")
                        .HasForeignKey("KolorId");

                    b.HasOne("ETI_X_2024_IntroASPNETCore.Models.Marka", "Marka")
                        .WithMany("Samochods")
                        .HasForeignKey("MarkaId");

                    b.HasOne("ETI_X_2024_IntroASPNETCore.Models.Model", "Model")
                        .WithMany("Samochods")
                        .HasForeignKey("ModelId");

                    b.HasOne("ETI_X_2024_IntroASPNETCore.Models.RodzajSilnika", "RodzajSilnika")
                        .WithMany("Samochods")
                        .HasForeignKey("RodzajSilnikaId");

                    b.Navigation("Kolor");

                    b.Navigation("Marka");

                    b.Navigation("Model");

                    b.Navigation("RodzajSilnika");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Kategoria", b =>
                {
                    b.Navigation("Produkts");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Kolor", b =>
                {
                    b.Navigation("Samochods");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Marka", b =>
                {
                    b.Navigation("Samochods");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.Model", b =>
                {
                    b.Navigation("Samochods");
                });

            modelBuilder.Entity("ETI_X_2024_IntroASPNETCore.Models.RodzajSilnika", b =>
                {
                    b.Navigation("Samochods");
                });
#pragma warning restore 612, 618
        }
    }
}
