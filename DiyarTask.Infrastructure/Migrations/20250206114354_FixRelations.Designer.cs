﻿// <auto-generated />
using System;
using DiyarTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DiyarTask.Infrastructure.Migrations
{
    [DbContext(typeof(DiyarDbContext))]
    [Migration("20250206114354_FixRelations")]
    partial class FixRelations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.CustomerrAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.InvoiceAggregate.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentStatus");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.InvoiceAggregate.PaymentError", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OccurredOnLocal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OccurredOnUTC")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("InvoiceId1")
                        .IsUnique()
                        .HasFilter("[InvoiceId1] IS NOT NULL");

                    b.ToTable("PaymentErrors");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NotificationTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NotificationTemplateId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SentDateLocal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SentDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("SentStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("NotificationTemplateId");

                    b.HasIndex("NotificationTemplateId1");

                    b.HasIndex("SentDateUtc");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationError", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ErrorMessage")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("NotificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NotificationId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OccurredOnLocal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OccurredOnUTC")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.HasIndex("NotificationId1")
                        .IsUnique()
                        .HasFilter("[NotificationId1] IS NOT NULL");

                    b.ToTable("NotificationErrors");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NotificationTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("NotificationTypeId1")
                        .HasColumnType("int");

                    b.Property<string>("TemplateContent")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationTypeId");

                    b.HasIndex("NotificationTypeId1");

                    b.ToTable("NotificationTemplates");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodeEnum")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("NotificationTypes");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.Reminder.Reminder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationInterval")
                        .HasColumnType("int");

                    b.Property<int>("DurationType")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReminderTiming")
                        .HasColumnType("int");

                    b.Property<int>("RepeatCount")
                        .HasColumnType("int");

                    b.Property<int>("RepeatType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedDate");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.Reminder.ReminderUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReminderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ReminderId");

                    b.ToTable("ReminderUsers");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.InvoiceAggregate.Invoice", b =>
                {
                    b.HasOne("DiyarTask.Domain.Aggregates.CustomerrAggregate.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.InvoiceAggregate.PaymentError", b =>
                {
                    b.HasOne("DiyarTask.Domain.Aggregates.InvoiceAggregate.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiyarTask.Domain.Aggregates.InvoiceAggregate.Invoice", null)
                        .WithOne("PaymentError")
                        .HasForeignKey("DiyarTask.Domain.Aggregates.InvoiceAggregate.PaymentError", "InvoiceId1");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.Notification", b =>
                {
                    b.HasOne("DiyarTask.Domain.Aggregates.CustomerrAggregate.Customer", null)
                        .WithMany("Notifications")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiyarTask.Domain.Aggregates.CustomerrAggregate.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId1");

                    b.HasOne("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationTemplate", null)
                        .WithMany("Notifications")
                        .HasForeignKey("NotificationTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationTemplate", "NotificationTemplate")
                        .WithMany()
                        .HasForeignKey("NotificationTemplateId1");

                    b.Navigation("Customer");

                    b.Navigation("NotificationTemplate");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationError", b =>
                {
                    b.HasOne("DiyarTask.Domain.Aggregates.NotificationAggregate.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiyarTask.Domain.Aggregates.NotificationAggregate.Notification", null)
                        .WithOne("NotificationError")
                        .HasForeignKey("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationError", "NotificationId1");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationTemplate", b =>
                {
                    b.HasOne("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationType", null)
                        .WithMany("NotificationTemplates")
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationType", "NotificationType")
                        .WithMany()
                        .HasForeignKey("NotificationTypeId1");

                    b.Navigation("NotificationType");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.Reminder.ReminderUser", b =>
                {
                    b.HasOne("DiyarTask.Domain.Aggregates.CustomerrAggregate.Customer", "Customer")
                        .WithMany("ReminderUsers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiyarTask.Domain.Aggregates.Reminder.Reminder", "Reminder")
                        .WithMany("ReminderUsers")
                        .HasForeignKey("ReminderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Reminder");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.CustomerrAggregate.Customer", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Notifications");

                    b.Navigation("ReminderUsers");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.InvoiceAggregate.Invoice", b =>
                {
                    b.Navigation("PaymentError");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.Notification", b =>
                {
                    b.Navigation("NotificationError");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationTemplate", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.NotificationAggregate.NotificationType", b =>
                {
                    b.Navigation("NotificationTemplates");
                });

            modelBuilder.Entity("DiyarTask.Domain.Aggregates.Reminder.Reminder", b =>
                {
                    b.Navigation("ReminderUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
