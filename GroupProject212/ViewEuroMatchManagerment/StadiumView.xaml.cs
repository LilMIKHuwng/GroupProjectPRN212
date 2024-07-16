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
	/// Interaction logic for StadiumView.xaml
	/// </summary>
	public partial class StadiumView : Window
	{
		EuroMatchContext _context;
		LocationService _stadium;
		public StadiumView()
		{
			InitializeComponent();
			_context = new EuroMatchContext();
			_stadium = new LocationService();
			LoadDataToDataGridView();
		}

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}
		private void LoadDataToDataGridView()
		{
			_context = new EuroMatchContext();
			dtgStadium.ItemsSource = null;
			var stadiumList = _context.Locations.ToList();
			var anonymousList = stadiumList.Select(x => new LocationVm
			{
				Id = x.Id,
				Stadium = x.Name,
			}).ToList();

			dtgStadium.AutoGenerateColumns = true;
			dtgStadium.ItemsSource = anonymousList;

		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{

			var selectedItem = dtgStadium.SelectedItem as LocationVm;
			if (selectedItem != null)
			{
				int ACid = selectedItem.Id;
				_stadium.Delete(ACid);
				LoadDataToDataGridView();
			}
			else
			{
				System.Windows.MessageBox.Show("Please Choose An Item To Delete!");
			}

		}

		private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			CreateStadium create = new CreateStadium();
			create.ShowDialog();
			LoadDataToDataGridView();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			var selectedItem = dtgStadium.SelectedItem as LocationVm;
			if (selectedItem != null)
			{
				UpdateStadium update = new UpdateStadium(selectedItem.Id);
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
