using Repositories.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ViewEuroMatchManagerment
{
	/// <summary>
	/// Interaction logic for CreateTeam.xaml
	/// </summary>
	public partial class CreateTeam : Window
	{
		EuroMatchContext _context;
		TeamService _team;
		public CreateTeam()
		{
			InitializeComponent();
			_context = new EuroMatchContext();
			_team = new TeamService();
		}
		private bool ValidateInput()
		{
			if (txtTeam.Text == "")
			{
				System.Windows.MessageBox.Show("Please input Team Name!");
				return false;
			}
			else
			{
				if (!(txtTeam.Text.Length >= 2 && txtTeam.Text.Length <= 40))
				{
					System.Windows.MessageBox.Show("Team Name is in the range of 2 – 40 characters!");
					return false;
				}
				else if (!(Char.IsUpper(txtTeam.Text, 0)))
				{
					System.Windows.MessageBox.Show("Team Name start with uppercase letter!");
					return false;
				}
				else if (Regex.IsMatch(txtTeam.Text, @"[^a-zA-Z\s]")) // Allows only letters and spaces
				{
					System.Windows.MessageBox.Show("Team Name must not contain special characters!");
					return false;
				}
			}


			return true;
		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			if (ValidateInput())
			{
				//B1: Tao Airconditioner object
				var team = new Team()
				{
					Name = txtTeam.Text,
				};
				//B2: Tao repo
				//B3: Save to database
				_team.Add(team);
				//B4: Close form
				//B5: Load lai list
				this.Close();
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
