using Repositories.Models;
using Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class LocationService
	{
		private LocationRepo _repo = new LocationRepo();
		public List<Location> GetAll()
		{
			return _repo.GetAll().ToList();
		}

		public Location GetbyId(int id) 
		{
			return _repo.GetById(id);
		}

		public void Add(Location Location)
		{
			_repo.Add(Location);
		}
		public void Update(Location Location)
		{
			_repo.Update(Location);
		}
		public void Delete(int id)
		{
			_repo.Delete(id);
		}
	}
}
