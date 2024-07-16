using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewEuroMatchManagerment.ViewModel
{
	public class MatchVm
	{
		public int Id { get; set; }

		public int? Home_Team { get; set; }

		public int? Away_Team { get; set; }

		public int? Stadium { get; set; }

		public string? Attendance { get; set; }

		public int? Goal_Home_Team { get; set; }

		public int? Goal_Away_Team { get; set; }
	}
}
