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
	/// Interaction logic for UpdateStadium.xaml
	/// </summary>
	public partial class UpdateStadium : Window
	{
		EuroMatchContext _context;
		LocationService _stadium;
		int stadiumId;
		public UpdateStadium(int stadiumId)
		{
			InitializeComponent();
			_context = new EuroMatchContext();
			_stadium = new LocationService();
			this.stadiumId = stadiumId;
			LoadData();
		}
		private void LoadData()
		{
			var stadium = _stadium.GetbyId(stadiumId);
			txtID.Text = stadium.Id.ToString();
			txtStadium.Text = stadium.Name.ToString();
		}
		private bool ValidateInput()
		{
			if (txtStadium.Text == "")
			{
				System.Windows.MessageBox.Show("Please input Stadium Name!");
				return false;
			}
			else
			{
				if (!(txtStadium.Text.Length >= 2 && txtStadium.Text.Length <= 40))
				{
					System.Windows.MessageBox.Show("Stadium Name is in the range of 2 – 40 characters!");
					return false;
				}
				else if (!(Char.IsUpper(txtStadium.Text, 0)))
				{
					System.Windows.MessageBox.Show("Stadium Name start with uppercase letter!");
					return false;
				}
				else if (Regex.IsMatch(txtStadium.Text, @"[^a-zA-Z\s]")) // Allows only letters and spaces
				{
					System.Windows.MessageBox.Show("Stadium Name must not contain special characters!");
					return false;
				}
			}


			return true;
		}
		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (ValidateInput())
			{
				var stadium = _context.Locations.Find(stadiumId);

				stadium.Name = txtStadium.Text;

				_context.SaveChanges();
				this.Close();
				// Tải lại danh sách (tùy thuộc vào cách bạn quản lý danh sách sinh viên)

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
