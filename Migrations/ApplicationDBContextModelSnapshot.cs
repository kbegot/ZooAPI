﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooAPI.Context;

#nullable disable

namespace ZooAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ZooAPI.Entities.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("dateBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ZooAPI.Entities.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("foodName")
                        .HasColumnType("longtext");

                    b.Property<double>("weight")
                        .HasColumnType("double");

                    b.HasKey("FoodId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("ZooAPI.Entities.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("mealTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MealId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("MenuId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("ZooAPI.Entities.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("menuName")
                        .HasColumnType("longtext");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("ZooAPI.Entities.MenuFood", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuFoods");
                });

            modelBuilder.Entity("ZooAPI.Entities.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProviderName")
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderSiret")
                        .HasColumnType("longtext");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ZooAPI.Entities.Food", b =>
                {
                    b.HasOne("ZooAPI.Entities.Provider", "Provider")
                        .WithMany("Foods")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ZooAPI.Entities.Meal", b =>
                {
                    b.HasOne("ZooAPI.Entities.Animal", "Animal")
                        .WithMany("Meals")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooAPI.Entities.Menu", "Menu")
                        .WithMany("Meals")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("ZooAPI.Entities.MenuFood", b =>
                {
                    b.HasOne("ZooAPI.Entities.Food", "Food")
                        .WithMany("MenuFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooAPI.Entities.Menu", "Menu")
                        .WithMany("MenuFoods")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("ZooAPI.Entities.Animal", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("ZooAPI.Entities.Food", b =>
                {
                    b.Navigation("MenuFoods");
                });

            modelBuilder.Entity("ZooAPI.Entities.Menu", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("MenuFoods");
                });

            modelBuilder.Entity("ZooAPI.Entities.Provider", b =>
                {
                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
