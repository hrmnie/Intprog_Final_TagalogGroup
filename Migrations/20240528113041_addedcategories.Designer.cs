﻿// <auto-generated />
using System;
using AdventureSeekers.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdventureSeekers.Migrations
{
    [DbContext(typeof(AdventureSeekersContext))]
    [Migration("20240528113041_addedcategories")]
    partial class addedcategories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdventureSeekers.Models.Comment", b =>
                {
                    b.Property<int>("comment_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("comment_id"));

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("comment_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("comment_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("post_id")
                        .HasColumnType("int");

                    b.HasKey("comment_id");

                    b.HasIndex("post_id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AdventureSeekers.Models.User_Post", b =>
                {
                    b.Property<int>("post_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("post_id"));

                    b.Property<string>("post_caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("post_categories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("post_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("post_location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("post_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("seeker_id")
                        .HasColumnType("int");

                    b.HasKey("post_id");

                    b.HasIndex("seeker_id");

                    b.ToTable("User_Post");
                });

            modelBuilder.Entity("AdventureSeekers.Models.User_Seeker", b =>
                {
                    b.Property<int?>("seeker_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("seeker_id"));

                    b.Property<string>("seeker_address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seeker_contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seeker_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seeker_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("seeker_password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("seeker_id");

                    b.ToTable("User_Seeker");
                });

            modelBuilder.Entity("AdventureSeekers.Models.Comment", b =>
                {
                    b.HasOne("AdventureSeekers.Models.User_Post", "User_Post")
                        .WithMany("Comments")
                        .HasForeignKey("post_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User_Post");
                });

            modelBuilder.Entity("AdventureSeekers.Models.User_Post", b =>
                {
                    b.HasOne("AdventureSeekers.Models.User_Seeker", "User_Seekers")
                        .WithMany("User_Post")
                        .HasForeignKey("seeker_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User_Seekers");
                });

            modelBuilder.Entity("AdventureSeekers.Models.User_Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("AdventureSeekers.Models.User_Seeker", b =>
                {
                    b.Navigation("User_Post");
                });
#pragma warning restore 612, 618
        }
    }
}
