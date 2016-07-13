using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApi2.Models;

namespace WebApi2.Migrations
{
    [DbContext(typeof(EventsContext))]
    partial class EventsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi2.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WebApi2.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Lat");

                    b.Property<double>("Long");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WebApi2.Models.Event", b =>
                {
                    b.HasOne("WebApi2.Models.Location", "Location")
                        .WithMany("Events")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
