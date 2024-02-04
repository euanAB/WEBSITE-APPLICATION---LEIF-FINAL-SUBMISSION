using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Leif_Gym_Manager.Models;

public partial class LeifGymManagerMdfContext : DbContext
{
    public LeifGymManagerMdfContext()
    {
    }

    public LeifGymManagerMdfContext(DbContextOptions<LeifGymManagerMdfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppointmentManager> AppointmentManagers { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberCurrentVisitLog> MemberCurrentVisitLogs { get; set; }

    public virtual DbSet<MemberHistoricalVisitLog> MemberHistoricalVisitLogs { get; set; }

    public virtual DbSet<MemberShipType> MemberShipTypes { get; set; }

    public virtual DbSet<MemberStatuss> MemberStatuses { get; set; }

    public virtual DbSet<PaymentMethodss> PaymentMethodsus { get; set; }

    public virtual DbSet<PaymentStatuss> PaymentStatuses { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=Z:\\THE COMMERCIAL GROUP GATEWAY\\UNIVERSITY\\COMPUTING WITH WEB DEVELOPMENT\\WEB APPLICATIONS\\FINAL Leif_Gym_Manager (V4)\\Leif_Gym_Manager\\Database\\Leif_Gym_Manager.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppointmentManager>(entity =>
        {
            entity.HasKey(e => e.AppointmentManagerId).HasName("PK__Appointm__1CC4C8D1DE7FD9D8");

            entity.ToTable("AppointmentManager");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Class).WithMany(p => p.AppointmentManagers)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Class__4AB81AF0");

            entity.HasOne(d => d.Member).WithMany(p => p.AppointmentManagers)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__Membe__49C3F6B7");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__B0970537A27C69D2");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId).HasColumnName("Class_Id");
            entity.Property(e => e.Capacity)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ClassName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Day)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Field)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.Time).HasColumnType("datetime");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Staff).WithMany(p => p.Classes)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class__Staff_Id__2D27B809");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Location1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Location");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MembersId).HasName("PK__Members__06035466E7B6B043");

            entity.HasIndex(e => e.FobNumber, "UQ__Members__E632152B0322B14E").IsUnique();

            entity.Property(e => e.MembersId).HasColumnName("Members_Id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("Date_Of_Birth");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Ethinicity)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FobNumber)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Height).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MedicalNotes).IsUnicode(false);
            entity.Property(e => e.MemberShipTypeId).HasColumnName("MemberShipType_Id");
            entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentType_Id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Religion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MemberShipType).WithMany(p => p.Members)
                .HasForeignKey(d => d.MemberShipTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberShipType");

            entity.HasOne(d => d.PaymentType).WithMany(p => p.Members)
                .HasForeignKey(d => d.PaymentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentType");
        });

        modelBuilder.Entity<MemberCurrentVisitLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Member_Current_Visit_Log");

            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("CheckIN");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CurrentVisitLogId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Current_Visit_Log_Id");
            entity.Property(e => e.FobNumber)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.FobNumberNavigation).WithMany()
                .HasPrincipalKey(p => p.FobNumber)
                .HasForeignKey(d => d.FobNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Member_Cu__FobNu__6EF57B66");
        });

        modelBuilder.Entity<MemberHistoricalVisitLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Member_Historical_Visit_Log");

            entity.Property(e => e.CheckOut).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FobNumber)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.HistoricalVisitLogId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Historical_Visit_Log_Id");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.FobNumberNavigation).WithMany()
                .HasPrincipalKey(p => p.FobNumber)
                .HasForeignKey(d => d.FobNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Member_Hi__FobNu__6FE99F9F");
        });

        modelBuilder.Entity<MemberShipType>(entity =>
        {
            entity.HasKey(e => e.MemberShipTypeId).HasName("PK__MemberSh__165B1606B777E024");

            entity.ToTable("MemberShipType");

            entity.Property(e => e.MemberShipTypeId).HasColumnName("MemberShipType_Id");
            entity.Property(e => e.ContactTerm)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Frequency)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MemberShipName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<MemberStatuss>(entity =>
        {
            entity.HasKey(e => e.MemberStatusId).HasName("PK__MemberSt__E8DB7CB0F52ECE48");

            entity.ToTable("MemberStatus");

            entity.Property(e => e.MemberStatusId).HasColumnName("MemberStatus_Id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.MemberStatus1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("MemberStatus");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentMethodss>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodsId).HasName("PK__PaymentMethodSt__E8DB7CB0F52ECE48");

            entity.ToTable("PaymentMethods");
            entity.Property(e => e.PaymentMethodsId).HasColumnName("PaymentMethod_Id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethods1)
                .HasMaxLength(250)
                .IsUnicode(false)
            .HasColumnName("PaymentMethods");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentStatuss>(entity =>
        {
            entity.HasKey(e => e.PaymentStatusId).HasName("PK__PaymentSt__E8DB7CB0F52ECE48");

            entity.ToTable("PaymentStatus");

            entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatus_Id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PaymentStatus");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__tmp_ms_x__DA6C7FC163939FBC");

            entity.ToTable("PaymentType");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_Id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Membersname)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Method)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentAmount)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Payment_Amount");
            entity.Property(e => e.Status)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__D80AB4BBB2377367");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.RoleName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__tmp_ms_x__32D1F4239859F18E");

            entity.Property(e => e.StaffId).HasColumnName("Staff_Id");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.Staff)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff__RoleId__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
