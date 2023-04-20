using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RHRM_API_ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRM_API_Infrastructure.Data
{
    public class RecruitingDbContext : DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> option) : base(option)
        {
            
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<EmployeeRequirementType> EmployeeRequirementTypes { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Status> Statuses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //First Way: however, if there are many of these, it becomes messy.
            //modelBuilder.Entity<EmployeeType>()
            //    .HasMany(a => a.EmployeeRequirementTypes)
            //    .WithOne(b => b.EmployeeType)
            //    .HasForeignKey(b => b.Id);

            //Fluent API
            modelBuilder.Entity<EmployeeRequirementType>(ConfigureEmployeeRequirementType);
            modelBuilder.Entity<EmployeeType>(ConfigureEmployeeType);
        }
        private void ConfigureEmployeeRequirementType(EntityTypeBuilder<EmployeeRequirementType> builder)
        {
            builder.ToTable("EmployeeRequirementTypes");
            builder.HasKey(e => new { e.EmployeeTypeId, e.JobRequirementId });
            builder.HasOne(a => a.EmployeeType).WithMany(b => b.EmployeeRequirementTypes).HasForeignKey(b => b.EmployeeTypeId);
            builder.HasOne(a => a.JobRequirement).WithMany(b => b.EmployeeRequirementTypes).HasForeignKey(b => b.JobRequirementId);
        }
        private void ConfigureEmployeeType(EntityTypeBuilder<EmployeeType> builder)
        {
            builder.ToTable("EmployeeTypes");
            builder.HasKey(et => et.Id);
            builder.Property(n => n.TypeName).HasMaxLength(128);
            //builder.Property(r => r.ReviewText).HasMaxLength(4000);
            //builder.Property(r => r.Rating).HasColumnType("decimal(3, 2)");
            //builder.Property(r => r.CreatedDate).HasDefaultValueSql("getdate()");
        }
        
    }
}
