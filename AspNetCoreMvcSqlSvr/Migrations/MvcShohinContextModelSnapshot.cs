﻿// <auto-generated />
using AspNetCoreMvcSqlSvr.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreMvcSqlSvr.Migrations
{
    [DbContext(typeof(MvcShohinContext))]
    partial class MvcShohinContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreMvcSqlSvr.Models.Shohin", b =>
                {
                    b.Property<int>("NumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NumId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("EditDate")
                        .HasColumnName("EditDate")
                        .HasColumnType("decimal(8, 0)");

                    b.Property<decimal>("EditTime")
                        .HasColumnName("EditTime")
                        .HasColumnType("numeric(6, 0)");

                    b.Property<string>("Note")
                        .HasColumnName("Note")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<short>("ShohinCode")
                        .HasColumnName("ShohinNum")
                        .HasColumnType("smallint");

                    b.Property<string>("ShohinName")
                        .HasColumnName("ShohinName")
                        .HasColumnType("char(50)")
                        .HasMaxLength(50);

                    b.HasKey("NumId");

                    b.ToTable("Shohin");
                });
#pragma warning restore 612, 618
        }
    }
}