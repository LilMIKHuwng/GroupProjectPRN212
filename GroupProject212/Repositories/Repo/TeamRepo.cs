using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repo
{
	public class TeamRepo
	{
		private EuroMatchContext _context;

		public List<Team> GetAll()
		{
			_context = new();
			return _context.Teams.ToList();
		}

		public Team GetById(int id)
		{
			_context = new();
			return _context.Teams.Find(id);
		}
		public List<Team> Search(string TeamTitle)
		{
			_context = new();
			return _context.Teams.Where(t => t.Name.Contains(TeamTitle)).ToList();
		}
		public void Add(Team team)
		{
			_context = new();
			_context.Teams.Add(team);
			_context.SaveChanges();
		}

		public void Update(Team team)
		{
			_context = new();
			_context.Teams.Update(team);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context = new();
			var team = _context.Teams.Find(id);
			if (team != null)
			{
				_context.Teams.Remove(team);
				_context.SaveChanges();
			}
		}
	}
}
