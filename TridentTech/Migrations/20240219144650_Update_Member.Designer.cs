﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TridentTech.DBModels;

#nullable disable

namespace TridentTech.Migrations
{
    [DbContext(typeof(TridentTechContext))]
    [Migration("20240219144650_Update_Member")]
    partial class Update_Member
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TridentTech.DBModels.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasComment("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("class_name")
                        .HasComment("課程名稱");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("class_description")
                        .HasComment("課程描述");

                    b.Property<string>("EndAt")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("end_at")
                        .HasComment("下課時間");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("member_id")
                        .HasComment("會員 Id");

                    b.Property<string>("StartAt")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)")
                        .HasColumnName("start_at")
                        .HasComment("上課時間");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("TridentTech.DBModels.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasComment("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("member_account")
                        .HasComment("帳號");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("member_email")
                        .HasComment("E-mail");

                    b.Property<bool>("IsTeacher")
                        .HasMaxLength(100)
                        .HasColumnType("bit")
                        .HasColumnName("is_teacher")
                        .HasComment("是否為老師");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("member_name")
                        .HasComment("姓名");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("member_password")
                        .HasComment("密碼");

                    b.HasKey("Id");

                    b.ToTable("members");
                });

            modelBuilder.Entity("TridentTech.DBModels.Class", b =>
                {
                    b.HasOne("TridentTech.DBModels.Member", "Member")
                        .WithMany("Classes")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Member");
                });

            modelBuilder.Entity("TridentTech.DBModels.Member", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}