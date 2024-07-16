using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewEuroMatchManagerment;

namespace GroupProjectPRN212
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			ImportDataSetToDB();
			InitializeComponent();
		}

		private void ImportDataSetToDB()
		{
			using (var context = new EuroMatchContext())
			{
				// Ensure database is created
				context.Database.Migrate();

				// Read CSV file
				var lines = File.ReadAllLines(@"D:\Hoc_Ki_5\PRN212\Group_Project\GroupProject212\ImportCSVtoDB\Data\Euro_2024_Matches.csv");

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
						var match = new Repositories.Models.Match
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
		}

		private void btn_Team_Click(object sender, RoutedEventArgs e)
		{
			TeamView team = new TeamView();
			team.ShowDialog();
		}

		private void btn_Stadium_Click(object sender, RoutedEventArgs e)
		{
			StadiumView stadium = new StadiumView();
			stadium.ShowDialog();
		}

		private void btn_Match_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn_PDF_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn_Excel_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn_Quit_Click(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show("Do you want to quit?", "Quit?", MessageBoxButton.OKCancel, MessageBoxImage.Question);
			if (result == MessageBoxResult.OK)
			{
				Application.Current.Shutdown();
			}
		}
	}
}