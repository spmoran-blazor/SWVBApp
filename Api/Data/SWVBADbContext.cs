using Microsoft.EntityFrameworkCore;
using entities = WVBApp.Shared.Entities;

namespace Api.Data
{
    public partial class SWVBADbContext : DbContext
    {
        public SWVBADbContext()
        {
        }

        public SWVBADbContext(DbContextOptions<SWVBADbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<entities.AreaOfPlay> AreaOfPlay { get; set; }
        //public virtual DbSet<entities.DayOfWeek> DayOfWeek { get; set; }
        public virtual DbSet<entities.Event> Event { get; set; }
        public virtual DbSet<entities.EventRoster> EventRoster { get; set; }
        public virtual DbSet<entities.EventSchedulingCode> EventSchedulingCode { get; set; }
        public virtual DbSet<entities.Member> Member { get; set; }
        public virtual DbSet<entities.MemberExceptionDate> MemberExceptionDate { get; set; }
        public virtual DbSet<entities.MemberPreferredDays> MemberPreferredDays { get; set; }
        public virtual DbSet<entities.Message> Message { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string? by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=tcp:swvb.database.windows.net,1433;Initial Catalog=SWVB;Persist Security Info=False;User ID=spmoran;Password=1SPm081563_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////modelBuilder.Entity<entities.DayOfWeek>(entity =>
            ////{
            ////    entity.Property(e => e.Day).IsFixedLength();
            ////});

            modelBuilder.Entity<entities.Event>(entity =>
            {
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AreaOfPlay)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.AreaOfPlayId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_AreaOfPlay");

                entity.HasOne(d => d.EventSchedulingCode)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventSchedulingCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Event_EventSchedulingCode");
            });

            modelBuilder.Entity<entities.EventRoster>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.EventRosters)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventRoster_Member");
            });

            modelBuilder.Entity<entities.EventSchedulingCode>(entity =>
            {
                entity.Property(e => e.Code).IsFixedLength();
            });

            modelBuilder.Entity<entities.Member>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Gender).IsFixedLength();

                entity.Property(e => e.MobileNumber).IsFixedLength();

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<entities.MemberExceptionDate>(entity =>
            {
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberExceptionDates)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberExceptionDates_Member");
            });

            modelBuilder.Entity<entities.MemberPreferredDays>(entity =>
            {
                entity.Property(e => e.UpdateDate).HasDefaultValueSql("(getdate())");

                //entity.HasOne(d => d.DayOfWeek)
                //    .WithMany(p => p.MemberPreferredDays)
                //    .HasForeignKey(d => d.DayOfWeekId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_MemberPreferredDays_DayOfWeek");
            });

            modelBuilder.Entity<entities.Message>(entity =>
            {
                entity.Property(e => e.Body).IsFixedLength();

                entity.Property(e => e.Type).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).HasDefaultValueSql("(N'system')");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
