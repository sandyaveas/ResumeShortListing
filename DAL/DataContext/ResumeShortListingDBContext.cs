using System;
using BO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.DataContext
{
    public partial class ResumeShortListingDBContext : DbContext
    {
        private AppConfiguration settings;

        public ResumeShortListingDBContext()
        {
            settings = new AppConfiguration();
        }

        public ResumeShortListingDBContext(DbContextOptions<ResumeShortListingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidate { get; set; }

        public virtual DbSet<Skill> Skill { get; set; }

        public virtual DbSet<JobExperience> JobExperience { get; set; }

        public virtual DbSet<PersonalDetail> PersonalDetail { get; set; }

        public virtual DbSet<CanActivity> CanActivity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(settings.sqlConnectionString);
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Candidate>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.Id)
        //    //        .HasName("IX_Candidate")
        //    //        .IsUnique();

        //    //    entity.Property(e => e.Address).HasMaxLength(1000);

        //    //    entity.Property(e => e.City).HasMaxLength(100);

        //    //    entity.Property(e => e.Email)
        //    //        .IsRequired()
        //    //        .HasMaxLength(255);

        //    //    entity.Property(e => e.FirstName)
        //    //        .IsRequired()
        //    //        .HasMaxLength(100);

        //    //    entity.Property(e => e.LastName).HasMaxLength(100);

        //    //    entity.Property(e => e.Mobile)
        //    //        .IsRequired()
        //    //        .HasMaxLength(15);

        //    //    entity.Property(e => e.Pincode).HasMaxLength(10);

        //    //    entity.Property(e => e.State).HasMaxLength(100);
        //    //});

        //    //modelBuilder.Entity<Skill>(entity =>
        //    //{
        //    //    entity.HasIndex(e => e.Id)
        //    //        .HasName("IX_Skill")
        //    //        .IsUnique();

        //    //    entity.Property(e => e.SkillName).HasMaxLength(100);
        //    //});

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
