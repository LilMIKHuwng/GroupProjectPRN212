using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repo
{
    public class MatchRepo
    {
        private EuroMatchContext _context;

        public List<Match> GetAll()
        {
            _context = new();
            return _context.Matches
                .Include(m => m.Location)
                .Include(m => m.TeamA)
                .Include(m => m.TeamB)
                .ToList();
        }


        public List<Match> Search(string HomeTeam, string GuestTeam)
        {
            _context = new();
    
            var listMatches = _context.Matches.AsQueryable();

            if (!string.IsNullOrWhiteSpace(HomeTeam))
            {
                listMatches = listMatches.Where(s => s.TeamA.Name.Contains(HomeTeam));
                listMatches = listMatches.Include("TeamA");
            }

            if (!string.IsNullOrWhiteSpace(GuestTeam))
            {
                listMatches = listMatches.Where(s => s.TeamB.Name.Contains(GuestTeam));
                listMatches = listMatches.Include("TeamB");
            }

            return listMatches.Include("TeamA").Include("TeamB").ToList();
        }
        public Match GetById(int id)
        {
            _context = new();
            return _context.Matches.Find(id);
        }

        public void Add(Match match)
        {
            _context = new();
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void Update(Match match)
        {
            _context = new();
            var existingMatch = _context.Matches.Find(match.Id);
            if (existingMatch != null)
            {
                existingMatch.Attendance = match.Attendance;
                existingMatch.LocationId = match.LocationId;
                existingMatch.TeamAid = match.TeamAid;
                existingMatch.TeamBid = match.TeamBid;
                existingMatch.GoalTeamA = match.GoalTeamA;
                existingMatch.GoalTeamB = match.GoalTeamB;

                _context.SaveChanges();
            }
        }

        public void Delete(Match match)
        {
            _context = new();
            _context.Matches.Remove(match);
            _context.SaveChanges();
        }
    }
}
