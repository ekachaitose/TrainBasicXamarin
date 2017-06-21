using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using XamarinFirst.Api.Data;

namespace XamarinFirst.Api.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170621051407_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("XamarinFirst.Api.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthdate");

                    b.Property<int?>("Children");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<bool?>("IsMarry");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Photo");

                    b.Property<int?>("Salary");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Telephone");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });
        }
    }
}
