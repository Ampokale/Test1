using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace aspnetserver.EntityLayer
{
    public partial class NetFSDContext : DbContext
    {
        public NetFSDContext()
        {
        }

        public NetFSDContext(DbContextOptions<NetFSDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProjectT> Projects { get; set; }
        public virtual DbSet<ProjectMemberT> ProjectMembers { get; set; }
        public virtual DbSet<ReportT> Reports { get; set; }
        public virtual DbSet<StatusTableT> StatusTables { get; set; }
        public virtual DbSet<TbTaskT> TbTasks { get; set; }
        public virtual DbSet<UserT> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //work for local host use 
               // optionsBuilder.UseSqlServer(@"server=AmolVM\SQLEXPRESS;database=kanbanboard;trusted_connection=true");
                 //work for azure wesite
                optionsBuilder.UseSqlServer(@"Server = tcp:sqlkanban.database.windows.net, 1433; Initial Catalog = kanban; Persist Security Info = False; User ID = amol; Password = adm@1234; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 2000;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectT>(entity =>
            {
                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("createdBy");

                entity.Property(e => e.ProjectDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("projectDesc");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("projectName");

                entity.Property(e => e.Startdate)
                    .HasColumnType("date")
                    .HasColumnName("startdate")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Projects)
                    .HasPrincipalKey(p => p.Email)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Projects__create__45BE5BA9");
            });

            modelBuilder.Entity<ProjectMemberT>(entity =>
            {

                entity.Property(e => e.ProjMemberId).HasColumnName("projMemberId");
                entity.ToTable("projectMembers");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany()
                    .HasPrincipalKey(p => p.Email)
                    .HasForeignKey(d => d.Email)
                    .HasConstraintName("FK__projectMe__email__4F47C5E3");

                entity.HasOne(d => d.Project)
                    .WithMany()
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__projectMe__proje__4D5F7D71");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__projectMe__UserI__4E53A1AA");
            });

            modelBuilder.Entity<ReportT>(entity =>
            {

                //entity.Property(e => e.ReportId).HasColumnName("reportId");
                //entity.ToTable("report");
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__tb_Report__DC11576792592C7A");

                entity.ToTable("reportTb");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.ReportedOn)
                    .HasColumnType("date")
                    .HasColumnName("reportedOn")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TaskDetails)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("taskDetails");

                entity.Property(e => e.Taskstatus).HasColumnName("taskstatus");

                entity.Property(e => e.WhatAction)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("whatAction");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK__report__pId__634EBE90");
            });

            modelBuilder.Entity<StatusTableT>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__statusTa__36257A18B33680BD");

                entity.ToTable("statusTable");

                entity.Property(e => e.StatusId).HasColumnName("statusId");

                entity.Property(e => e.SDetail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sDetail");
            });

            modelBuilder.Entity<TbTaskT>(entity =>
            {
                entity.HasKey(e => e.TId)
                    .HasName("PK__tb_Task__DC11576792592C7A");

                entity.ToTable("tb_Task");

                entity.Property(e => e.TId).HasColumnName("tId");

                entity.Property(e => e.AssignedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("assignedBy");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PId).HasColumnName("pId");

                entity.Property(e => e.TaskDetails)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("taskDetails");

                entity.Property(e => e.TaskStatus).HasColumnName("taskStatus");

                entity.HasOne(d => d.PIdNavigation)
                    .WithMany(p => p.TbTasks)
                    .HasForeignKey(d => d.PId)
                    .HasConstraintName("FK__tb_Task__pId__531856C7");

                entity.HasOne(d => d.TaskStatusNavigation)
                    .WithMany(p => p.TbTasks)
                    .HasForeignKey(d => d.TaskStatus)
                    .HasConstraintName("FK__tb_Task__taskSta__540C7B00");
            });

            modelBuilder.Entity<UserT>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__A9D10534A77A9C9F")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Roles)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Member')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
