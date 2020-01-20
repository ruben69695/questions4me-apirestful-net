﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using questions4me_apirestful_net.Data;

namespace questions4me_apirestful_net.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200120203952_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("questions4me_apirestful_net.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("AnsweredAt")
                        .HasColumnName("answer_at")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Content")
                        .HasColumnName("content")
                        .HasColumnType("varchar(550)")
                        .HasMaxLength(450);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("timestamptz");

                    b.Property<string>("CreatedBy")
                        .HasColumnName("created_by")
                        .HasColumnType("varchar(220)")
                        .HasMaxLength(220);

                    b.HasKey("Id");

                    b.ToTable("questions");
                });
#pragma warning restore 612, 618
        }
    }
}
