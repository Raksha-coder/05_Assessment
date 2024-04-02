﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(HealthDbContext))]
    [Migration("20240401053711_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.AssementQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssessmentId")
                        .HasColumnType("int");

                    b.Property<string>("Questions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Response_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isRequired")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.ToTable("AssementQuestionsTable");
                });

            modelBuilder.Entity("Domain.Assessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int>("isScorable")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AssessmentsTable");
                });

            modelBuilder.Entity("Domain.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PatientTable");
                });

            modelBuilder.Entity("Domain.PatientToAssessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssessmentId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.HasIndex("PatientId");

                    b.ToTable("PatientToAssessmentTable");
                });

            modelBuilder.Entity("Domain.PatientToAssessmentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssementQuestionsId")
                        .HasColumnType("int");

                    b.Property<int>("Patient_Assessment_Id")
                        .HasColumnType("int");

                    b.Property<int>("Question_Id")
                        .HasColumnType("int");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssementQuestionsId");

                    b.HasIndex("Patient_Assessment_Id");

                    b.HasIndex("Question_Id");

                    b.ToTable("PatientToAssessmentDetailsTable");
                });

            modelBuilder.Entity("Domain.QuestionResponses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Responses")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId")
                        .IsUnique();

                    b.ToTable("QuestionsResponseTable");
                });

            modelBuilder.Entity("Domain.AssementQuestions", b =>
                {
                    b.HasOne("Domain.Assessment", "Assessment")
                        .WithMany("AssementsQue")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assessment");
                });

            modelBuilder.Entity("Domain.PatientToAssessment", b =>
                {
                    b.HasOne("Domain.Assessment", "Assessment")
                        .WithMany("Patient_Assessment")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Patient", "Patients")
                        .WithMany("Patient_Assessment")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assessment");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("Domain.PatientToAssessmentDetails", b =>
                {
                    b.HasOne("Domain.AssementQuestions", null)
                        .WithMany("Details")
                        .HasForeignKey("AssementQuestionsId");

                    b.HasOne("Domain.PatientToAssessment", "PatientToAssessment")
                        .WithMany("Details")
                        .HasForeignKey("Patient_Assessment_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AssementQuestions", "AssessmentQuestion")
                        .WithMany()
                        .HasForeignKey("Question_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AssessmentQuestion");

                    b.Navigation("PatientToAssessment");
                });

            modelBuilder.Entity("Domain.QuestionResponses", b =>
                {
                    b.HasOne("Domain.AssementQuestions", "AssessmentQuestion")
                        .WithOne("QuestionResponses")
                        .HasForeignKey("Domain.QuestionResponses", "QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssessmentQuestion");
                });

            modelBuilder.Entity("Domain.AssementQuestions", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("QuestionResponses")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Assessment", b =>
                {
                    b.Navigation("AssementsQue");

                    b.Navigation("Patient_Assessment");
                });

            modelBuilder.Entity("Domain.Patient", b =>
                {
                    b.Navigation("Patient_Assessment");
                });

            modelBuilder.Entity("Domain.PatientToAssessment", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
