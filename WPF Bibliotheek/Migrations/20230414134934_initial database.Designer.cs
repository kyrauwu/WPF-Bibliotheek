﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPF_Bibliotheek.Model;

namespace WPF_Bibliotheek.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20230414134934_initial database")]
    partial class initialdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorItem", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("AuthorItem");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            ItemId = 1
                        },
                        new
                        {
                            AuthorId = 1,
                            ItemId = 2
                        },
                        new
                        {
                            AuthorId = 2,
                            ItemId = 3
                        },
                        new
                        {
                            AuthorId = 2,
                            ItemId = 4
                        },
                        new
                        {
                            AuthorId = 3,
                            ItemId = 5
                        });
                });

            modelBuilder.Entity("WPF_Bibliotheek.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "J K Rolling"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Suzanne Coolins"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AE Sports"
                        });
                });

            modelBuilder.Entity("WPF_Bibliotheek.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Harry Pooter book 1",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Harry Pooter book 2",
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hungry Games movie 1",
                            Type = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Hungry Games movie 3",
                            Type = 3
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fifa 23",
                            Type = 5
                        });
                });

            modelBuilder.Entity("AuthorItem", b =>
                {
                    b.HasOne("WPF_Bibliotheek.Model.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WPF_Bibliotheek.Model.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
