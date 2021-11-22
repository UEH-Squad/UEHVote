using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UEHVote.Models;

namespace UEHVote.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<VotedCandidate>().HasOne(x => x.Vote).WithMany(x => x.VotedCandidates).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<ActivityImage> ActivityImages { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateImage> CandidateImages { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<VotedCandidate> VotedCandidates { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
