// <auto-generated />
using System;
using CMPE399_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMPE399_Project.Migrations
{
    [DbContext(typeof(DemoTokenContext))]
    [Migration("20211208124008_DbMigration")]
    partial class DbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMPE399_Project.Data.RefreshToken", b =>
                {
                    b.Property<int>("RefreshTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Used")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("RefreshTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("CMPE399_Project.Data.RolesMaster", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("RolesMaster");
                });

            modelBuilder.Entity("CMPE399_Project.Data.TaskStatus", b =>
                {
                    b.Property<long>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("TaskStatus");
                });

            modelBuilder.Entity("CMPE399_Project.Data.Tasks", b =>
                {
                    b.Property<long>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TaskStatusStatusId")
                        .HasColumnType("bigint");

                    b.HasKey("TaskId");

                    b.HasIndex("TaskStatusStatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("CMPE399_Project.Data.UserRoles", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK_UserRoles");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("CMPE399_Project.Data.UserTasks", b =>
                {
                    b.Property<long>("TaskId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TaskId", "UserId")
                        .HasName("PK_UserTasks");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("CMPE399_Project.Data.UsersMaster", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UsersMaster");
                });

            modelBuilder.Entity("CMPE399_Project.Data.RefreshToken", b =>
                {
                    b.HasOne("CMPE399_Project.Data.UsersMaster", "User")
                        .WithMany("RefreshToken")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CMPE399_Project.Data.Tasks", b =>
                {
                    b.HasOne("CMPE399_Project.Data.TaskStatus", "TaskStatus")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskStatusStatusId");

                    b.Navigation("TaskStatus");
                });

            modelBuilder.Entity("CMPE399_Project.Data.UserRoles", b =>
                {
                    b.HasOne("CMPE399_Project.Data.RolesMaster", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMPE399_Project.Data.UsersMaster", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CMPE399_Project.Data.UserTasks", b =>
                {
                    b.HasOne("CMPE399_Project.Data.Tasks", "Task")
                        .WithMany("UserTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMPE399_Project.Data.UsersMaster", "User")
                        .WithMany("UserTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CMPE399_Project.Data.RolesMaster", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("CMPE399_Project.Data.TaskStatus", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("CMPE399_Project.Data.Tasks", b =>
                {
                    b.Navigation("UserTasks");
                });

            modelBuilder.Entity("CMPE399_Project.Data.UsersMaster", b =>
                {
                    b.Navigation("RefreshToken");

                    b.Navigation("UserRoles");

                    b.Navigation("UserTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
