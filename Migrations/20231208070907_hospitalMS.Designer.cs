﻿// <auto-generated />
using System;
using Hospital_Managment_System.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hospital_Managment_System.Migrations
{
    [DbContext(typeof(HospitalDBContext))]
    [Migration("20231208070907_hospitalMS")]
    partial class hospitalMS
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hospital_Managment_System.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<TimeOnly>("AppointmentTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("AppointmnetDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Hospital_Managment_System.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Hospital_Managment_System.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("PatientId");

                    b.HasIndex("RoomId");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("Hospital_Managment_System.Entities.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("RoomType")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Hospital_Managment_System.Entities.Appointment", b =>
                {
                    b.HasOne("Hospital_Managment_System.Entities.Doctor", null)
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital_Managment_System.Entities.Patient", null)
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hospital_Managment_System.Entities.Patient", b =>
                {
                    b.HasOne("Hospital_Managment_System.Entities.Room", null)
                        .WithMany("Patients")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hospital_Managment_System.Entities.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Hospital_Managment_System.Entities.Patient", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Hospital_Managment_System.Entities.Room", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
