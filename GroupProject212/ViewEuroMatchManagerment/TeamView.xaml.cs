using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using Microsoft.Win32;
using Repositories.Models;
using Repositories.Repo;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClosedXML.Excel;
using ViewEuroMatchManagerment.ViewModel;

namespace ViewEuroMatchManagerment
{
	/// <summary>
	/// Interaction logic for Team.xaml
	/// </summary>
	public partial class TeamView : Window
	{
		EuroMatchContext _context;
		TeamService _team;
		TeamRepo _teamRepo = new();
		public TeamView()
		{
			InitializeComponent();
			_context = new EuroMatchContext();
			_team = new TeamService();
			LoadDataToDataGridView();
		}

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}
		private void LoadDataToDataGridView()
		{
			_context = new EuroMatchContext();
			dtgTeam.ItemsSource = null;
			var teamList = _context.Teams.ToList();
			var anonymousList = teamList.Select(x => new TeamVm
			{
				Id = x.Id,
				Team = x.Name,
			}).ToList();

			dtgTeam.AutoGenerateColumns = true;
			dtgTeam.ItemsSource = anonymousList;

		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{

			var selectedItem = dtgTeam.SelectedItem as TeamVm;
			if (selectedItem != null)
			{
				int ACid = selectedItem.Id;
				_team.Delete(ACid);
				LoadDataToDataGridView();
			}
			else
			{
				System.Windows.MessageBox.Show("Please Choose An Item To Delete!");
			}

		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			CreateTeam create = new CreateTeam();
			create.ShowDialog();
			LoadDataToDataGridView();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			var selectedItem = dtgTeam.SelectedItem as TeamVm;
			if (selectedItem != null)
			{
				UpdateTeam update = new UpdateTeam(selectedItem.Id);
				update.ShowDialog();
				LoadDataToDataGridView();
			}
			else
			{
				System.Windows.MessageBox.Show("Please Choose An Item To Update!");
			}
		}


		private void btnQuit_Click(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show("Do you want to quit?", "Quit?", MessageBoxButton.OKCancel, MessageBoxImage.Question);
			if (result == MessageBoxResult.OK)
			{
				this.Close();
			}
		}

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            TeamRepo _teamRepo = new TeamRepo();
            List<Team> listTeam = _teamRepo.GetAll();

            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "TeamExport.xlsx";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;

                    var workbook = new XLWorkbook();

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

                  
                    workbook.SaveAs(filePath);

                    MessageBox.Show("Dữ liệu từ DataGrid đã được xuất ra file Excel thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string teamTitle = TeamTitleTextBox.Text;
            List<Team> listSearchTeams = _teamRepo.Search(teamTitle);
            List<TeamVm> listVM = new List<TeamVm>();
			foreach (var team in listSearchTeams)
			{
				TeamVm teamVm = new TeamVm()
				{
					Id = team.Id,
					Team = team.Name
				};
				listVM.Add(teamVm);
			}
            dtgTeam.ItemsSource = null;
            dtgTeam.ItemsSource = listVM;

        }
    }
}
