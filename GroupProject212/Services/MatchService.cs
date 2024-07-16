using Repositories.Models;
using Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Match = Repositories.Models.Match;

namespace Services
{
	public class MatchService
	{
		private MatchRepo _repo = new MatchRepo();
		public List<Match> GetAll()
		{
			return _repo.GetAll().ToList();
		}

		public Match GetbyId(int id)
		{
			return _repo.GetById(id);
		}

		public void Add(Match match)
		{
			_repo.Add(match);
		}
		public void Update(Match match)
		{
			_repo.Update(match);
		}
		public void Delete(int id)
		{
			_repo.Delete(id);
		}
	}
}
