﻿// <auto-generated />
using EmergencyNavigation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmergencyNavigation.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250311001545_create-database")]
    partial class createdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Building", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfFloor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Edge", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<double>("Meters")
                        .HasColumnType("float");

                    b.Property<long>("SourceId")
                        .HasColumnType("bigint");

                    b.Property<long>("VertexId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SourceId");

                    b.HasIndex("VertexId");

                    b.ToTable("Edeges");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Floor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BuildingId")
                        .HasColumnType("bigint");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Floor");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsParamedic")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsualLocalId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsualLocalId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Vertex", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("FloorId")
                        .HasColumnType("bigint");

                    b.Property<long>("MainCharacterizationId")
                        .HasColumnType("bigint");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<long>("SecondaryCharacterizationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("MainCharacterizationId");

                    b.HasIndex("SecondaryCharacterizationId");

                    b.ToTable("Vertices");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.VertexCharacterization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VertexCharacterizations");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Edge", b =>
                {
                    b.HasOne("EmergencyNavigation.Core.Model.Vertex", "Source")
                        .WithMany("Edges")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EmergencyNavigation.Core.Model.Vertex", "Vertex")
                        .WithMany()
                        .HasForeignKey("VertexId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Source");

                    b.Navigation("Vertex");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Floor", b =>
                {
                    b.HasOne("EmergencyNavigation.Core.Model.Building", "Building")
                        .WithMany("Floors")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.User", b =>
                {
                    b.HasOne("EmergencyNavigation.Core.Model.Vertex", "UsualLocal")
                        .WithMany("Users")
                        .HasForeignKey("UsualLocalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsualLocal");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Vertex", b =>
                {
                    b.HasOne("EmergencyNavigation.Core.Model.Floor", "Floor")
                        .WithMany("Vertices")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyNavigation.Core.Model.VertexCharacterization", "MainCharacterization")
                        .WithMany()
                        .HasForeignKey("MainCharacterizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmergencyNavigation.Core.Model.VertexCharacterization", "SecondaryCharacterization")
                        .WithMany()
                        .HasForeignKey("SecondaryCharacterizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");

                    b.Navigation("MainCharacterization");

                    b.Navigation("SecondaryCharacterization");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Building", b =>
                {
                    b.Navigation("Floors");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Floor", b =>
                {
                    b.Navigation("Vertices");
                });

            modelBuilder.Entity("EmergencyNavigation.Core.Model.Vertex", b =>
                {
                    b.Navigation("Edges");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
