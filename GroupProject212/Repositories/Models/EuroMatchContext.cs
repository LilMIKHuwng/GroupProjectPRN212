using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repositories.Models;

public partial class EuroMatchContext : DbContext
{
    public EuroMatchContext()
    {
    }

    public EuroMatchContext(DbContextOptions<EuroMatchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Match> Matches { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

	private string GetConnectionString()
	{
		IConfiguration config = new ConfigurationBuilder()
			 .SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json", true, true)
					.Build();
		var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

		return strConn;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC07F4364EE2");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Matches__3214EC07477B819A");

            entity.Property(e => e.Attendance).HasMaxLength(100);
            entity.Property(e => e.TeamAid).HasColumnName("TeamAId");
            entity.Property(e => e.TeamBid).HasColumnName("TeamBId");

            entity.HasOne(d => d.Location).WithMany(p => p.Matches)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Matches__Locatio__72C60C4A");

            entity.HasOne(d => d.TeamA).WithMany(p => p.MatchTeamAs)
                .HasForeignKey(d => d.TeamAid)
                .HasConstraintName("FK__Matches__TeamAId__70DDC3D8");

            entity.HasOne(d => d.TeamB).WithMany(p => p.MatchTeamBs)
                .HasForeignKey(d => d.TeamBid)
                .HasConstraintName("FK__Matches__TeamBId__71D1E811");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teams__3214EC07BBCFA186");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
