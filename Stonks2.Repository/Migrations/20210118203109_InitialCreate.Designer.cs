﻿// <auto-generated />
using System;
using AutomaticStockTrader.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutomaticStockTrader.Repository.Migrations
{
    [DbContext(typeof(StockContext))]
    [Migration("20210118203109_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AutomaticStockTrader.Repository.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("ActualCostPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("ActualSharesBought")
                        .HasColumnType("bigint");

                    b.Property<decimal>("AttemptedCostPerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("AttemptedSharesBought")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("OrderPlaced")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AutomaticStockTrader.Repository.Models.StratagysStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StockSymbol")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Strategy")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TradingFrequency")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockSymbol", "Strategy", "TradingFrequency")
                        .IsUnique()
                        .HasFilter("[StockSymbol] IS NOT NULL AND [Strategy] IS NOT NULL");

                    b.ToTable("StratagysStocks");
                });

            modelBuilder.Entity("AutomaticStockTrader.Repository.Models.Order", b =>
                {
                    b.HasOne("AutomaticStockTrader.Repository.Models.StratagysStock", "Position")
                        .WithMany("Orders")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("AutomaticStockTrader.Repository.Models.StratagysStock", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
