﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp1JuliePro_DataAccess.Data;

namespace Tp1JuliePro_DataAccess.Migrations
{
    [DbContext(typeof(JulieProDbContext))]
    [Migration("20220615165814_updateSpecialityTrainer")]
    partial class updateSpecialityTrainer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tp1JuliePro_Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Speciality");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Perte de poids"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Course"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Althérophilie"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Réhabilitation"
                        });
                });

            modelBuilder.Entity("Tp1JuliePro_Models.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Photo")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Speciality_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Speciality_Id");

                    b.ToTable("Trainer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Email = "Chrystal.lapierre@juliepro.ca",
                            FirstName = "Chrysal",
                            LastName = "Lappierre",
                            Photo = "8624af64-2685-459a-a1cc-816c0695d760.png",
                            Speciality_Id = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Email = "Felix.trudeau@juliePro.ca",
                            FirstName = "Félix",
                            LastName = "Trudeau",
                            Photo = "a202bae3-e6bb-40f0-84cf-e4b11627ba1c.png",
                            Speciality_Id = 2
                        },
                        new
                        {
                            Id = 3,
                            Active = false,
                            Email = "Frank.StJohn@juliepro.ca",
                            FirstName = "François",
                            LastName = "Saint-John",
                            Photo = "aedd9532-1395-42a2-8ae6-56f0e2ab49b5.png",
                            Speciality_Id = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            Email = "JC.Bastien@juliepro.ca",
                            FirstName = "Jean-Claude",
                            LastName = "Bastien",
                            Photo = "d7bcc6d9-0599-42aa-8305-3c1ae5a4505c.png",
                            Speciality_Id = 4
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            Email = "JinLee.godette@juliepro.ca",
                            FirstName = "Jin Lee",
                            LastName = "Godette",
                            Photo = "E3Rcc6d9-0599-42aa-8305-3c1ae5a4512v.png",
                            Speciality_Id = 3
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            Email = "Karine.Lachance@juliepro.ca",
                            FirstName = "Karine",
                            LastName = "Lachance",
                            Photo = "b333bae3-e6bb-40f0-84cf-e4b11627ba1c.png",
                            Speciality_Id = 2
                        },
                        new
                        {
                            Id = 7,
                            Active = false,
                            Email = "Ramone.Esteban@juliepro.ca",
                            FirstName = "Ramone",
                            LastName = "Esteban",
                            Photo = "waqd9532-1395-42a2-8ae6-56f0e2ab49e9.png",
                            Speciality_Id = 3
                        });
                });

            modelBuilder.Entity("Tp1JuliePro_Models.Trainer", b =>
                {
                    b.HasOne("Tp1JuliePro_Models.Speciality", "Speciality")
                        .WithMany()
                        .HasForeignKey("Speciality_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });
#pragma warning restore 612, 618
        }
    }
}