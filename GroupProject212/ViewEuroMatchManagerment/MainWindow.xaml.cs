using ClosedXML.Excel;
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
using ClosedXML.Excel;
using Microsoft.Win32;
using Repositories.Repo;

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
			MatchesManager match = new MatchesManager();
			match.ShowDialog();
		}

		private void btn_PDF_Click(object sender, RoutedEventArgs e)
		{

		}

        private void btn_Excel_Click(object sender, RoutedEventArgs e)
        {
            MatchRepo _repoMatch = new MatchRepo();
            List<Match> listMatch = _repoMatch.GetAll();

            TeamRepo _teamRepo = new TeamRepo();
            List<Team> listTeam = _teamRepo.GetAll();

            LocationRepo _locationRepo = new LocationRepo();
            List<Location> listLocation = _locationRepo.GetAll();

            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "MatchesEuroExport.xlsx";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;

                    var workbook = new XLWorkbook();

                    // match
                    var worksheetMatches = workbook.Worksheets.Add("Matches Data");
                    worksheetMatches.Cell(1, 1).Value = "Match ID";
                    worksheetMatches.Cell(1, 2).Value = "Home Team";
                    worksheetMatches.Cell(1, 3).Value = "Guest Team";
                    worksheetMatches.Cell(1, 4).Value = "Location";
                    worksheetMatches.Cell(1, 5).Value = "Attendance";
                    worksheetMatches.Cell(1, 6).Value = "Home Team Goal";
                    worksheetMatches.Cell(1, 7).Value = "Guest Team Goal";

                    int row = 2;
                    foreach (var match in listMatch)
                    {
                        worksheetMatches.Cell(row, 1).Value = match.Id;
                        worksheetMatches.Cell(row, 2).Value = match.TeamA.Name;
                        worksheetMatches.Cell(row, 3).Value = match.TeamB.Name;
                        worksheetMatches.Cell(row, 4).Value = match.Location.Name;
                        worksheetMatches.Cell(row, 5).Value = match.Attendance;
                        worksheetMatches.Cell(row, 6).Value = match.GoalTeamA;
                        worksheetMatches.Cell(row, 7).Value = match.GoalTeamB;

                        row++;
                    }

                    // team
                    var worksheetTeams = workbook.Worksheets.Add("Team Data");
                    worksheetTeams.Cell(1, 1).Value = "Team ID";
                    worksheetTeams.Cell(1, 2).Value = "Team Name";

                    int row2 = 2;
                    foreach (var team in listTeam)
                    {
                        worksheetTeams.Cell(row2, 1).Value = team.Id;
                        worksheetTeams.Cell(row2, 2).Value = team.Name;

                        row2++;
                    }

                    //location
                    var worksheetLocation = workbook.Worksheets.Add("Stadium Data");
                    worksheetLocation.Cell(1, 1).Value = "Stadium ID";
                    worksheetLocation.Cell(1, 2).Value = "Stadium Name";

                    int row3 = 2;
                    foreach (var location in listLocation)
                    {
                        worksheetLocation.Cell(row3, 1).Value = location.Id;
                        worksheetLocation.Cell(row3, 2).Value = location.Name;

                        row3++;
                    }

                    workbook.SaveAs(filePath);

                    MessageBox.Show("Dữ liệu từ DataGrid đã được xuất ra file Excel thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        private void btn_Quit_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}