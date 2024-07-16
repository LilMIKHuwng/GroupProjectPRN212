using Repositories.Models;
using Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class TeamService
	{
		private TeamRepo _repo = new TeamRepo();
		public List<Team> GetAll()
		{
			return _repo.GetAll().ToList();
		}

		public Team GetbyId(int id)
		{
			return _repo.GetById(id);
		}

		public void Add(Team Team)
		{
			_repo.Add(Team);
		}
		public void Update(Team Team)
		{
			_repo.Update(Team);
		}
		public void Delete(int id)
		{
			_repo.Delete(id);
		}
	}
}
