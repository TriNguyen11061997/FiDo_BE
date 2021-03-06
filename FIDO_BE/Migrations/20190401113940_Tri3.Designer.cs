﻿// <auto-generated />
using System;
using FIDO_BE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FIDO_BE.Migrations
{
    [DbContext(typeof(FIDOContext))]
    [Migration("20190401113940_Tri3")]
    partial class Tri3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FIDO_BE.Models.ADUserGroups", b =>
                {
                    b.Property<int>("ADUserGroupID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AAStatus");

                    b.Property<string>("ADUserGroupDesc");

                    b.Property<string>("ADUserGroupName");

                    b.Property<DateTime?>("Ngay")
                        .HasColumnType("datetime");

                    b.HasKey("ADUserGroupID");

                    b.ToTable("ADUserGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
