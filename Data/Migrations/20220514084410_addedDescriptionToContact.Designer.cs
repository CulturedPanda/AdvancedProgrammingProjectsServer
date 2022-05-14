﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AdvancedProgrammingProjectsServerContext))]
    [Migration("20220514084410_addedDescriptionToContact")]
    partial class addedDescriptionToContact
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.Property<string>("contactOf")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RegisteredUserusername")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<string>("last")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("lastdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("server")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("contactOf", "id");

                    b.HasIndex("RegisteredUserusername");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Domain.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("RegisteredUserusername")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("with")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("RegisteredUserusername");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConversationId")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("sent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("ConversationId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Domain.PendingUser", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("encryptionAlgorithm")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nickname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("secretQuestionsId")
                        .HasColumnType("int");

                    b.Property<string>("verificationcode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("username");

                    b.HasIndex("secretQuestionsId");

                    b.ToTable("PendingUser");
                });

            modelBuilder.Entity("Domain.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeSubmitted")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Domain.RegisteredUser", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("encryptionAlgorithm")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nickNum")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("nickname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("salt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("secretQuestionsId")
                        .HasColumnType("int");

                    b.Property<string>("verificationcode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("username");

                    b.HasIndex("secretQuestionsId");

                    b.ToTable("RegisteredUser");
                });

            modelBuilder.Entity("Domain.SecretQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SecretQuestion");
                });

            modelBuilder.Entity("Domain.Contact", b =>
                {
                    b.HasOne("Domain.RegisteredUser", null)
                        .WithMany("contacts")
                        .HasForeignKey("RegisteredUserusername");
                });

            modelBuilder.Entity("Domain.Conversation", b =>
                {
                    b.HasOne("Domain.RegisteredUser", null)
                        .WithMany("conversations")
                        .HasForeignKey("RegisteredUserusername");
                });

            modelBuilder.Entity("Domain.Message", b =>
                {
                    b.HasOne("Domain.Conversation", null)
                        .WithMany("messages")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.PendingUser", b =>
                {
                    b.HasOne("Domain.SecretQuestion", "secretQuestions")
                        .WithMany()
                        .HasForeignKey("secretQuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("secretQuestions");
                });

            modelBuilder.Entity("Domain.RegisteredUser", b =>
                {
                    b.HasOne("Domain.SecretQuestion", "secretQuestions")
                        .WithMany()
                        .HasForeignKey("secretQuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("secretQuestions");
                });

            modelBuilder.Entity("Domain.Conversation", b =>
                {
                    b.Navigation("messages");
                });

            modelBuilder.Entity("Domain.RegisteredUser", b =>
                {
                    b.Navigation("contacts");

                    b.Navigation("conversations");
                });
#pragma warning restore 612, 618
        }
    }
}
