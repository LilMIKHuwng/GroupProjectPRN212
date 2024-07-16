using Repositories.Models;
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
	}
}
