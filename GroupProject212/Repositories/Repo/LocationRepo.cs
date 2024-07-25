using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repo
{
	public class LocationRepo
	{
		private EuroMatchContext _context;

		public List<Location> GetAll()
		{
			_context = new();
			return _context.Locations.ToList();
		}
		public List<Location> Search(string LocationName)
		{
			_context = new();

			return _context.Locations.Where(t => t.Name.Contains(LocationName)).ToList();
		}
		public Location GetById(int id)
		{
			_context = new();
			return _context.Locations.Find(id);
		}

		public void Add(Location location)
		{
			_context = new();
			_context.Locations.Add(location);
			_context.SaveChanges();
		}

		public void Update(Location location)
		{
			_context = new();
			_context.Locations.Update(location);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			_context = new();
			var location = _context.Locations.Find(id);
			if (location != null)
			{
				_context.Locations.Remove(location);
				_context.SaveChanges();
			}
		}
	}
}
