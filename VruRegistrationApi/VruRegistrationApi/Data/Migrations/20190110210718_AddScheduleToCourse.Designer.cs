﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VruRegistrationApi.Data;

namespace VruRegistrationApi.Migrations
{
    [DbContext(typeof(VruRegistrationDbContext))]
    [Migration("20190110210718_AddScheduleToCourse")]
    partial class AddScheduleToCourse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VruRegistrationApi.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<TimeSpan>("EndTime");

                    b.Property<int>("InstructorIdId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<int>("SemesterIdId");

                    b.Property<TimeSpan>("StartTime");

                    b.HasKey("ID");

                    b.HasIndex("InstructorIdId");

                    b.HasIndex("SemesterIdId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("VruRegistrationApi.Models.Enrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseIdID");

                    b.Property<int>("StudentIdId");

                    b.HasKey("Id");

                    b.HasIndex("CourseIdID");

                    b.HasIndex("StudentIdId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("VruRegistrationApi.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50);

                    b.Property<int>("YearsExperience");

                    b.HasKey("Id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("VruRegistrationApi.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("VruRegistrationApi.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("VruRegistrationApi.Models.Course", b =>
                {
                    b.HasOne("VruRegistrationApi.Models.Instructor", "InstructorId")
                        .WithMany()
                        .HasForeignKey("InstructorIdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VruRegistrationApi.Models.Semester", "SemesterId")
                        .WithMany()
                        .HasForeignKey("SemesterIdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VruRegistrationApi.Models.Enrollment", b =>
                {
                    b.HasOne("VruRegistrationApi.Models.Course", "CourseId")
                        .WithMany()
                        .HasForeignKey("CourseIdID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VruRegistrationApi.Models.Student", "StudentId")
                        .WithMany()
                        .HasForeignKey("StudentIdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
