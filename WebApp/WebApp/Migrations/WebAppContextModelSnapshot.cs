﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

namespace WebApp.Migrations
{
    [DbContext(typeof(WebAppContext))]
    partial class WebAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IndexStock", b =>
                {
                    b.Property<string>("IndicesName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StocksSymbol")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IndicesName", "StocksSymbol");

                    b.HasIndex("StocksSymbol");

                    b.ToTable("IndexStock");
                });

            modelBuilder.Entity("WebApp.Models.Index", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Index");
                });

            modelBuilder.Entity("WebApp.Models.Stock", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Change")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Symbol");

                    b.HasIndex("Username");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Creditcard")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Username");

                    b.ToTable("User");
                });

            modelBuilder.Entity("IndexStock", b =>
                {
                    b.HasOne("WebApp.Models.Index", null)
                        .WithMany()
                        .HasForeignKey("IndicesName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Stock", null)
                        .WithMany()
                        .HasForeignKey("StocksSymbol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.Stock", b =>
                {
                    b.HasOne("WebApp.Models.User", null)
                        .WithMany("StocksList")
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Navigation("StocksList");
                });
#pragma warning restore 612, 618
        }
    }
}
