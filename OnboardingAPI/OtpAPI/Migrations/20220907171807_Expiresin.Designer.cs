// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OtpAPI.OtpAPI.Data;

namespace OtpAPI.Migrations
{
    [DbContext(typeof(OtpApiDbContext))]
    [Migration("20220907171807_Expiresin")]
    partial class Expiresin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("OtpAPI.OtpAPI.Models.Otp", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiresIn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtpCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OtpCounter")
                        .HasColumnType("int");

                    b.Property<string>("OtpUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OtpUserId");

                    b.ToTable("Otps");
                });

            modelBuilder.Entity("OtpAPI.OtpAPI.Models.OtpUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OtpUsers");
                });

            modelBuilder.Entity("OtpAPI.OtpAPI.Models.Otp", b =>
                {
                    b.HasOne("OtpAPI.OtpAPI.Models.OtpUser", "OtpUser")
                        .WithMany()
                        .HasForeignKey("OtpUserId");

                    b.Navigation("OtpUser");
                });
#pragma warning restore 612, 618
        }
    }
}
