using Microsoft.EntityFrameworkCore;
using TournamentTracker.Core.Models;

namespace TournamentTracker.Infrastructure;

public partial class TournamentTrackerContext : DbContext
{
    public TournamentTrackerContext()
    {
    }

    public TournamentTrackerContext(DbContextOptions<TournamentTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Matchup> Matchups { get; set; }

    public virtual DbSet<MatchupEntry> MatchupEntries { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Prize> Prizes { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    public virtual DbSet<TournamentEntry> TournamentEntries { get; set; }

    public virtual DbSet<TournamentPrize> TournamentPrizes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6QE2B0K;Initial Catalog=TournamentTracker;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Matchup>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Tournament).WithMany(p => p.Matchups)
                .HasForeignKey(d => d.TournamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Matchups_Tournaments");

            entity.HasOne(d => d.Winner).WithMany(p => p.Matchups)
                .HasForeignKey(d => d.WinnerId)
                .HasConstraintName("FK_Matchups_Teams");
        });

        modelBuilder.Entity<MatchupEntry>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Matchup).WithMany(p => p.MatchupEntries)
                .HasForeignKey(d => d.MatchupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MatchupEntries_Matchups");

            entity.HasOne(d => d.TeamCompeting).WithMany(p => p.MatchupEntries)
                .HasForeignKey(d => d.TeamCompetingId)
                .HasConstraintName("FK_MatchupEntries_Teams");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3213E83F561A0F24");

            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmailAddress).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prize>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlaceName).HasMaxLength(50);
            entity.Property(e => e.PrizeAmount).HasColumnType("money");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TeamName).HasMaxLength(50);
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Person).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMembers_Person");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamMembers)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamMembers_Teams");
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EntryFee).HasColumnType("money");
            entity.Property(e => e.TournamentName).HasMaxLength(50);
        });

        modelBuilder.Entity<TournamentEntry>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Team).WithMany(p => p.TournamentEntries)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TournamentEntries_Teams");

            entity.HasOne(d => d.Tournament).WithMany(p => p.TournamentEntries)
                .HasForeignKey(d => d.TournamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TournamentEntries_Tournaments");
        });

        modelBuilder.Entity<TournamentPrize>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Prize).WithMany(p => p.TournamentPrizes)
                .HasForeignKey(d => d.PrizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TournamentPrizes_Prizes");

            entity.HasOne(d => d.Tournament).WithMany(p => p.TournamentPrizes)
                .HasForeignKey(d => d.TournamentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TournamentPrizes_Tournaments");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
