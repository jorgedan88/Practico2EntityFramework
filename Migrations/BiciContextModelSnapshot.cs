﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practico2HDP.Data;

#nullable disable

namespace Practico2HDP.Migrations
{
    [DbContext(typeof(BiciContext))]
    partial class BiciContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Practico2HDP.Models.Moto", b =>
                {
                    b.Property<int>("MotoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Anio")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("EsElectrica")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ConcesionarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MotoID");

                    b.HasIndex("ConcesionarioID");

                    b.ToTable("Moto");
                });

            modelBuilder.Entity("Practico2HDP.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ConsumidorFinal")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CUIT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteID");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Practico2HDP.Models.Concesionario", b =>
                {
                    b.Property<int>("ConcesionarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Web")
                        .HasColumnType("TEXT");

                    b.HasKey("ConcesionarioID");

                    b.ToTable("Concesionario");
                });

            modelBuilder.Entity("Practico2HDP.Models.Moto", b =>
                {
                    b.HasOne("Practico2HDP.Models.Concesionario", null)
                        .WithMany("Motos")
                        .HasForeignKey("ConcesionarioID");
                });

            modelBuilder.Entity("Practico2HDP.Models.Concesionario", b =>
                {
                    b.Navigation("Motos");
                });
#pragma warning restore 612, 618
        }
    }
}
