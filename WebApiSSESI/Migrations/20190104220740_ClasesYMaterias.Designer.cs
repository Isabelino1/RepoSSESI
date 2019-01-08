﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiSSESI.Models;

namespace WebApiSSESI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190104220740_ClasesYMaterias")]
    partial class ClasesYMaterias
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiSSESI.Models.CentroEducativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barrio")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("EstaBorrado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("CentrosEducativos");
                });

            modelBuilder.Entity("WebApiSSESI.Models.Clase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CentroId");

                    b.Property<string>("Grado")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Grupo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CentroId");

                    b.ToTable("Clases");
                });

            modelBuilder.Entity("WebApiSSESI.Models.ClaseTieneMateria", b =>
                {
                    b.Property<int>("ClaseId");

                    b.Property<int>("MateriaId");

                    b.HasKey("ClaseId", "MateriaId");

                    b.HasIndex("MateriaId");

                    b.ToTable("ClaseTieneMaterias");
                });

            modelBuilder.Entity("WebApiSSESI.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CargaHoraria")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("CentroId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CentroId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("WebApiSSESI.Models.TelefonoCEducativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CentroId");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CentroId");

                    b.ToTable("TelefonoCEducativo");
                });

            modelBuilder.Entity("WebApiSSESI.Models.Clase", b =>
                {
                    b.HasOne("WebApiSSESI.Models.CentroEducativo", "CentroEducativo")
                        .WithMany("Clases")
                        .HasForeignKey("CentroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiSSESI.Models.ClaseTieneMateria", b =>
                {
                    b.HasOne("WebApiSSESI.Models.Clase", "Clase")
                        .WithMany()
                        .HasForeignKey("ClaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApiSSESI.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiSSESI.Models.Materia", b =>
                {
                    b.HasOne("WebApiSSESI.Models.CentroEducativo", "CentroEducativo")
                        .WithMany("Materias")
                        .HasForeignKey("CentroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiSSESI.Models.TelefonoCEducativo", b =>
                {
                    b.HasOne("WebApiSSESI.Models.CentroEducativo", "CentroEducativo")
                        .WithMany("Telefonos")
                        .HasForeignKey("CentroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}