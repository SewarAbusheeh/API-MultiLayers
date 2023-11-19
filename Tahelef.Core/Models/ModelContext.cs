using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tahelef.Core.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Stdcourse> Stdcourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=C##APIcourse;Password=Test321;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("C##APICOURSE")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("SYS_C008719");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.Categoryid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Courseid).HasName("SYS_C008721");

            entity.ToTable("COURSE");

            entity.Property(e => e.Courseid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Categoryid)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Coursename)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("COURSENAME");
            entity.Property(e => e.Imagename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IMAGENAME");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("SYS_C008722");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Loginid).HasName("SYS_C008728");

            entity.ToTable("LOGIN");

            entity.Property(e => e.Loginid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("LOGINID");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Studentid)
                .HasColumnType("NUMBER")
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Role).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("SYS_C008729");

            entity.HasOne(d => d.Student).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("SYS_C008730");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("SYS_C008715");

            entity.ToTable("ROLE");

            entity.Property(e => e.Roleid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Stdcourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008724");

            entity.ToTable("STDCOURSE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Courseid)
                .HasColumnType("NUMBER")
                .HasColumnName("COURSEID");
            entity.Property(e => e.Dateofregister)
                .HasColumnType("DATE")
                .HasColumnName("DATEOFREGISTER");
            entity.Property(e => e.Marksofstd)
                .HasColumnType("NUMBER")
                .HasColumnName("MARKSOFSTD");
            entity.Property(e => e.Stdid)
                .HasColumnType("NUMBER")
                .HasColumnName("STDID");

            entity.HasOne(d => d.Course).WithMany(p => p.Stdcourses)
                .HasForeignKey(d => d.Courseid)
                .HasConstraintName("SYS_C008726");

            entity.HasOne(d => d.Std).WithMany(p => p.Stdcourses)
                .HasForeignKey(d => d.Stdid)
                .HasConstraintName("SYS_C008725");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("SYS_C008717");

            entity.ToTable("STUDENT");

            entity.Property(e => e.Studentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Dateofbirth)
                .HasColumnType("DATE")
                .HasColumnName("DATEOFBIRTH");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
