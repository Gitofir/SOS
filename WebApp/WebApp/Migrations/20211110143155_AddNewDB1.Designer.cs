﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Data;

namespace WebApp.Migrations
{
    [DbContext(typeof(WebAppContext))]
    [Migration("20211110143155_AddNewDB1")]
    partial class AddNewDB1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarketIndexStock", b =>
                {
                    b.Property<string>("IndicesName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StocksSymbol")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IndicesName", "StocksSymbol");

                    b.HasIndex("StocksSymbol");

                    b.ToTable("MarketIndexStock");
                });

            modelBuilder.Entity("WebApp.Models.CreditCard", b =>
                {
                    b.Property<string>("CardNum")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CVV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardHolder")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNum");

                    b.ToTable("CreditCard");
                });

            modelBuilder.Entity("WebApp.Models.MarketIndex", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Index");
                });

            modelBuilder.Entity("WebApp.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("PricePerUnit")
                        .HasColumnType("float");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.ToTable("Order");
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

                    b.Property<string>("CreditCardCardNum")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Username");

                    b.HasIndex("CreditCardCardNum");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MarketIndexStock", b =>
                {
                    b.HasOne("WebApp.Models.MarketIndex", null)
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
                        .WithMany("OwnedStocks")
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.HasOne("WebApp.Models.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardCardNum");

                    b.Navigation("CreditCard");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Navigation("OwnedStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
