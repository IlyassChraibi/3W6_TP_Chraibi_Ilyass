﻿// <auto-generated />
using System;
using JuliePro_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JuliePro_DataAccess.Migrations
{
    [DbContext(typeof(JulieProDbContext))]
    [Migration("20220628145440_AddMaxSessionCustomer")]
    partial class AddMaxSessionCustomer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JuliePro_Models.CalendarEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("CalendarEvent");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category_Id = 2,
                            Date = new DateTime(2022, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Niveau Bronze"
                        },
                        new
                        {
                            Id = 2,
                            Category_Id = 1,
                            Date = new DateTime(2022, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Cross Fit  Bahamas"
                        },
                        new
                        {
                            Id = 3,
                            Category_Id = 3,
                            Date = new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Zumba-Thon"
                        },
                        new
                        {
                            Id = 4,
                            Category_Id = 1,
                            Date = new DateTime(2022, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Trialthon"
                        },
                        new
                        {
                            Id = 5,
                            Category_Id = 2,
                            Date = new DateTime(2022, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Niveau Argent"
                        });
                });

            modelBuilder.Entity("JuliePro_Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Compétition"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Certification"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Levée de fonds"
                        });
                });

            modelBuilder.Entity("JuliePro_Models.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CertificationCenter")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.HasKey("Id");

                    b.ToTable("Certification");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Niveau Bronze"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Niveau Argent"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Niveau Or"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Niveau Élite"
                        });
                });

            modelBuilder.Entity("JuliePro_Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

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

                    b.Property<int>("MaxScheduledSession")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<double?>("StartWeight")
                        .HasColumnType("float");

                    b.Property<int>("Trainer_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Trainer_Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "arthurLaroche@gmail.com",
                            FirstName = "Arthur",
                            LastName = "Laroche",
                            MaxScheduledSession = 0,
                            Photo = "",
                            Trainer_Id = 3
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "DelimaCaillou@gmail.com",
                            FirstName = "Délima",
                            LastName = "Caillou",
                            MaxScheduledSession = 0,
                            Photo = "",
                            Trainer_Id = 2
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "fredcaillou@gmail.com",
                            FirstName = "Fred",
                            LastName = "Caillou",
                            MaxScheduledSession = 0,
                            Photo = "",
                            Trainer_Id = 3
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1965, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "berthaLaroche@gmail.com",
                            FirstName = "Bertha",
                            LastName = "Laroche",
                            MaxScheduledSession = 0,
                            Photo = "",
                            Trainer_Id = 1
                        });
                });

            modelBuilder.Entity("JuliePro_Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Equipment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vélo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ensemble dumbels"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tapis"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Step"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ensemble barre altère"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bloc yoga"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Elastiques"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Ballon d'exercice"
                        });
                });

            modelBuilder.Entity("JuliePro_Models.Objective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AchievedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<double?>("DistanceKm")
                        .HasColumnType("float");

                    b.Property<double?>("LostWeight")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Objective");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AchievedDate = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Customer_Id = 1,
                            DistanceKm = 0.0,
                            LostWeight = 5.0,
                            Name = ""
                        },
                        new
                        {
                            Id = 2,
                            AchievedDate = new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Customer_Id = 1,
                            DistanceKm = 0.0,
                            LostWeight = 5.0,
                            Name = ""
                        },
                        new
                        {
                            Id = 3,
                            Customer_Id = 1,
                            DistanceKm = 0.0,
                            LostWeight = 5.0,
                            Name = ""
                        },
                        new
                        {
                            Id = 4,
                            AchievedDate = new DateTime(2022, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Customer_Id = 2,
                            DistanceKm = 0.0,
                            LostWeight = 10.0,
                            Name = ""
                        },
                        new
                        {
                            Id = 5,
                            Customer_Id = 2,
                            DistanceKm = 0.0,
                            LostWeight = 5.0,
                            Name = ""
                        });
                });

            modelBuilder.Entity("JuliePro_Models.ScheduledSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Complete")
                        .HasColumnType("bit");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DurationMin")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Training_Id")
                        .HasColumnType("int");

                    b.Property<bool?>("WithTrainer")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Customer_Id");

                    b.HasIndex("Training_Id");

                    b.ToTable("ScheduledSession");
                });

            modelBuilder.Entity("JuliePro_Models.Speciality", b =>
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

            modelBuilder.Entity("JuliePro_Models.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("JuliePro_Models.TrainerCertification", b =>
                {
                    b.Property<int>("Trainer_Id")
                        .HasColumnType("int");

                    b.Property<int>("Certification_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCertification")
                        .HasColumnType("datetime2");

                    b.HasKey("Trainer_Id", "Certification_Id");

                    b.HasIndex("Certification_Id");

                    b.ToTable("TrainerCertification");
                });

            modelBuilder.Entity("JuliePro_Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Training");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Cardio",
                            Name = "Step"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Étirement",
                            Name = "Yoga"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Musculaire",
                            Name = "CrossFit"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Cardio",
                            Name = "Course"
                        },
                        new
                        {
                            Id = 5,
                            Category = "Cardio",
                            Name = "Zumba"
                        },
                        new
                        {
                            Id = 6,
                            Category = "Musculaire",
                            Name = "Spinning"
                        },
                        new
                        {
                            Id = 7,
                            Category = "Étirement",
                            Name = "Taichi"
                        });
                });

            modelBuilder.Entity("JuliePro_Models.TrainingEquipment", b =>
                {
                    b.Property<int>("Training_Id")
                        .HasColumnType("int");

                    b.Property<int>("Equipment_Id")
                        .HasColumnType("int");

                    b.HasKey("Training_Id", "Equipment_Id");

                    b.HasIndex("Equipment_Id");

                    b.ToTable("TrainingEquipment");

                    b.HasData(
                        new
                        {
                            Training_Id = 1,
                            Equipment_Id = 4
                        },
                        new
                        {
                            Training_Id = 1,
                            Equipment_Id = 7
                        },
                        new
                        {
                            Training_Id = 2,
                            Equipment_Id = 3
                        },
                        new
                        {
                            Training_Id = 2,
                            Equipment_Id = 6
                        },
                        new
                        {
                            Training_Id = 3,
                            Equipment_Id = 2
                        },
                        new
                        {
                            Training_Id = 3,
                            Equipment_Id = 5
                        },
                        new
                        {
                            Training_Id = 3,
                            Equipment_Id = 4
                        },
                        new
                        {
                            Training_Id = 6,
                            Equipment_Id = 1
                        },
                        new
                        {
                            Training_Id = 2,
                            Equipment_Id = 8
                        });
                });

            modelBuilder.Entity("JuliePro_Models.CalendarEvent", b =>
                {
                    b.HasOne("JuliePro_Models.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("JuliePro_Models.Customer", b =>
                {
                    b.HasOne("JuliePro_Models.Trainer", "Trainer")
                        .WithMany("Customers")
                        .HasForeignKey("Trainer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("JuliePro_Models.Objective", b =>
                {
                    b.HasOne("JuliePro_Models.Customer", "Customer")
                        .WithMany("Objectives")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("JuliePro_Models.ScheduledSession", b =>
                {
                    b.HasOne("JuliePro_Models.Customer", "Customer")
                        .WithMany("ScheduledSessions")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuliePro_Models.Training", "Training")
                        .WithMany("ScheduledSessions")
                        .HasForeignKey("Training_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("JuliePro_Models.Trainer", b =>
                {
                    b.HasOne("JuliePro_Models.Speciality", "Speciality")
                        .WithMany("Trainers")
                        .HasForeignKey("Speciality_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("JuliePro_Models.TrainerCertification", b =>
                {
                    b.HasOne("JuliePro_Models.Certification", "Certification")
                        .WithMany("TrainerCertification")
                        .HasForeignKey("Certification_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuliePro_Models.Trainer", "Trainer")
                        .WithMany("TrainerCertification")
                        .HasForeignKey("Trainer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Certification");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("JuliePro_Models.TrainingEquipment", b =>
                {
                    b.HasOne("JuliePro_Models.Equipment", "Equipment")
                        .WithMany("TrainingEquipments")
                        .HasForeignKey("Equipment_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JuliePro_Models.Training", "Training")
                        .WithMany("TrainingEquipments")
                        .HasForeignKey("Training_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("JuliePro_Models.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("JuliePro_Models.Certification", b =>
                {
                    b.Navigation("TrainerCertification");
                });

            modelBuilder.Entity("JuliePro_Models.Customer", b =>
                {
                    b.Navigation("Objectives");

                    b.Navigation("ScheduledSessions");
                });

            modelBuilder.Entity("JuliePro_Models.Equipment", b =>
                {
                    b.Navigation("TrainingEquipments");
                });

            modelBuilder.Entity("JuliePro_Models.Speciality", b =>
                {
                    b.Navigation("Trainers");
                });

            modelBuilder.Entity("JuliePro_Models.Trainer", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("TrainerCertification");
                });

            modelBuilder.Entity("JuliePro_Models.Training", b =>
                {
                    b.Navigation("ScheduledSessions");

                    b.Navigation("TrainingEquipments");
                });
#pragma warning restore 612, 618
        }
    }
}
