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

		public IEnumerable<Match> GetAll()
		{
			_context = new();
			return _context.Matches.ToList();
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
			_context.Matches.Update(match);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context = new();
			var match = _context.Matches.Find(id);
			if (match != null)
			{
				_context.Matches.Remove(match);
				_context.SaveChanges();
			}
		}
	}
}
