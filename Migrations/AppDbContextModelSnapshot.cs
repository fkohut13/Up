﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Programdata.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.17");

            modelBuilder.Entity("Program.Models.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Musicname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("album")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Playlist");
                });
#pragma warning restore 612, 618
        }
    }
}