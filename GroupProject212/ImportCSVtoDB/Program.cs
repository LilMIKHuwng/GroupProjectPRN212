using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System.Globalization;

namespace ImportCSVtoDB
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (var context = new EuroMatchContext())
			{
				// Ensure database is created
				context.Database.Migrate();

				// Read CSV file
				var lines = File.ReadAllLines(@"D:\Hoc_Ki_5\PRN212\Group_Project\ViewEuroMatchManagerment\ImportCSVtoDB\Data\Euro_2024_Matches.csv");

				// Assuming the first line is the header
				var header = lines[0].Split(',');

				foreach (var line in lines.Skip(1))
				{
					var columns = line.Split(',');

					var teamA = new Team { Name = columns[2] };
					var teamB = new Team { Name = columns[3] };
					var location = new Location { Name = columns[0] };

					// Add teams and location if they don't exist
					var teamAEntity = context.Teams.FirstOrDefault(t => t.Name == teamA.Name);
					if (teamAEntity == null)
					{
						context.Teams.Add(teamA);
						context.SaveChanges();
						teamAEntity = teamA;
					}

					var teamBEntity = context.Teams.FirstOrDefault(t => t.Name == teamB.Name);
					if (teamBEntity == null)
					{
						context.Teams.Add(teamB);
						context.SaveChanges();
						teamBEntity = teamB;
					}

					var locationEntity = context.Locations.FirstOrDefault(l => l.Name == location.Name);
					if (locationEntity == null)
					{
						context.Locations.Add(location);
						context.SaveChanges();
						locationEntity = location;
					}

					// Check if the match already exists
					var existingMatch = context.Matches.FirstOrDefault(m =>
						m.TeamAid == teamAEntity.Id &&
						m.TeamBid == teamBEntity.Id &&
						m.LocationId == locationEntity.Id);

					if (existingMatch == null)
					{
						// Create and add the match
						var match = new Match
						{
							TeamAid = teamAEntity.Id,
							TeamBid = teamBEntity.Id,
							LocationId = locationEntity.Id,
							Attendance = columns[1],
							GoalTeamA = int.Parse(columns[4]),
							GoalTeamB = int.Parse(columns[5]),
						};

						context.Matches.Add(match);
					}
				}

				context.SaveChanges();
			}

			Console.WriteLine("Data imported successfully.");
		}
	}
}
