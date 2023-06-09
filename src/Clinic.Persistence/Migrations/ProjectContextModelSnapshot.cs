﻿// <auto-generated />
using System;
using Clinic.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinic.Persistence.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Clinic.Domain.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Center", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("UserId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Insured", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Insureds");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("UserId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Clinic.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("InstallmentCount")
                        .HasColumnType("int");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Bill", b =>
                {
                    b.HasOne("Clinic.Domain.Models.Visit", "Visit")
                        .WithMany("Bills")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Clinic.Domain.ValueObjects.Money", "Payment", b1 =>
                        {
                            b1.Property<int>("BillId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal")
                                .HasColumnName("Payment");

                            b1.HasKey("BillId");

                            b1.ToTable("Bills");

                            b1.WithOwner()
                                .HasForeignKey("BillId");
                        });

                    b.Navigation("Payment")
                        .IsRequired();

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Center", b =>
                {
                    b.OwnsOne("Clinic.Domain.ValueObjects.Name", "Title", b1 =>
                        {
                            b1.Property<int>("CenterId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Title");

                            b1.HasKey("CenterId");

                            b1.ToTable("Centers");

                            b1.WithOwner()
                                .HasForeignKey("CenterId");
                        });

                    b.Navigation("Title")
                        .IsRequired();
                });

            modelBuilder.Entity("Clinic.Domain.Models.Doctor", b =>
                {
                    b.HasOne("Clinic.Domain.Models.Expert", "Expert")
                        .WithMany("Doctors")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Clinic.Domain.Models.User", "User")
                        .WithMany("Doctors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Expert", b =>
                {
                    b.OwnsOne("Clinic.Domain.ValueObjects.Name", "Title", b1 =>
                        {
                            b1.Property<int>("ExpertId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Title");

                            b1.HasKey("ExpertId");

                            b1.ToTable("Experts");

                            b1.WithOwner()
                                .HasForeignKey("ExpertId");
                        });

                    b.Navigation("Title")
                        .IsRequired();
                });

            modelBuilder.Entity("Clinic.Domain.Models.Insured", b =>
                {
                    b.OwnsOne("Clinic.Domain.ValueObjects.Number", "IdentityNumber", b1 =>
                        {
                            b1.Property<int>("InsuredId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(12)
                                .HasColumnType("varchar(12)")
                                .HasColumnName("IdentityNumber");

                            b1.HasKey("InsuredId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Insureds");

                            b1.WithOwner()
                                .HasForeignKey("InsuredId");
                        });

                    b.OwnsOne("Clinic.Domain.ValueObjects.Mobile", "Tell", b1 =>
                        {
                            b1.Property<int>("InsuredId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Tell");

                            b1.HasKey("InsuredId");

                            b1.ToTable("Insureds");

                            b1.WithOwner()
                                .HasForeignKey("InsuredId");
                        });

                    b.OwnsOne("Clinic.Domain.ValueObjects.Name", "Title", b1 =>
                        {
                            b1.Property<int>("InsuredId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Title");

                            b1.HasKey("InsuredId");

                            b1.ToTable("Insureds");

                            b1.WithOwner()
                                .HasForeignKey("InsuredId");
                        });

                    b.Navigation("IdentityNumber")
                        .IsRequired();

                    b.Navigation("Tell")
                        .IsRequired();

                    b.Navigation("Title")
                        .IsRequired();
                });

            modelBuilder.Entity("Clinic.Domain.Models.Patient", b =>
                {
                    b.HasOne("Clinic.Domain.Models.Insured", "Insured")
                        .WithMany("Patients")
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Clinic.Domain.Models.User", "User")
                        .WithMany("Patients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Clinic.Domain.ValueObjects.Number", "IdentityCart", b1 =>
                        {
                            b1.Property<int>("PatientId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(12)
                                .HasColumnType("varchar(12)")
                                .HasColumnName("IdentityCart");

                            b1.HasKey("PatientId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("IdentityCart")
                        .IsRequired();

                    b.Navigation("Insured");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Clinic.Domain.Models.User", b =>
                {
                    b.HasOne("Clinic.Domain.Models.Center", "Center")
                        .WithMany("Users")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Clinic.Domain.ValueObjects.Name", "Family", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Family");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Clinic.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("varchar(200)")
                                .HasColumnName("Name");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Clinic.Domain.ValueObjects.Mobile", "Tell", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Tell");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Center");

                    b.Navigation("Family")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Tell")
                        .IsRequired();
                });

            modelBuilder.Entity("Clinic.Domain.Models.Visit", b =>
                {
                    b.HasOne("Clinic.Domain.Models.Doctor", "Doctor")
                        .WithMany("Visits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Clinic.Domain.Models.Patient", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Clinic.Domain.ValueObjects.Money", "InstallmentPay", b1 =>
                        {
                            b1.Property<int>("VisitId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal")
                                .HasColumnName("InstallmentPay");

                            b1.HasKey("VisitId");

                            b1.ToTable("Visits");

                            b1.WithOwner()
                                .HasForeignKey("VisitId");
                        });

                    b.OwnsOne("Clinic.Domain.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<int>("VisitId")
                                .HasColumnType("int");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal")
                                .HasColumnName("Price");

                            b1.HasKey("VisitId");

                            b1.ToTable("Visits");

                            b1.WithOwner()
                                .HasForeignKey("VisitId");
                        });

                    b.Navigation("Doctor");

                    b.Navigation("InstallmentPay");

                    b.Navigation("Patient");

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("Clinic.Domain.Models.Center", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Doctor", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Expert", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Insured", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Patient", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Clinic.Domain.Models.User", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Clinic.Domain.Models.Visit", b =>
                {
                    b.Navigation("Bills");
                });
#pragma warning restore 612, 618
        }
    }
}
