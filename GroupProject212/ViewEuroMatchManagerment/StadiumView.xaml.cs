using Repositories.Models;
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
using Repositories.Repo;
using Microsoft.Win32;

namespace ViewEuroMatchManagerment
{
	/// <summary>
	/// Interaction logic for StadiumView.xaml
	/// </summary>
	public partial class StadiumView : Window
	{
		EuroMatchContext _context;

		LocationRepo _stadiumRepo = new();

		LocationRepo _stadium;
		public StadiumView()
		{
			InitializeComponent();
			_context = new EuroMatchContext();
			_stadium = new LocationRepo();
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
                ImageStadium = x.ImageStadium
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

		private void btnExport_Click(object sender, RoutedEventArgs e)
		{
			LocationRepo _locationRepo = new LocationRepo();
			List<Location> listLocation = _locationRepo.GetAll();

			try
			{
				var saveFileDialog = new SaveFileDialog();
				saveFileDialog.FileName = "StadiumExport.xlsx";
				saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

				if (saveFileDialog.ShowDialog() == true)
				{
					string filePath = saveFileDialog.FileName;

					var workbook = new XLWorkbook();

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

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			string locationName = LocationNameTextBox.Text;
			List<Location> listSearchTeams = _stadiumRepo.Search(locationName);
			List<LocationVm> listVM = new List<LocationVm>();
			foreach (Location location in listSearchTeams)
			{
				LocationVm locationVm = new LocationVm()
				{
					Id = location.Id,
					Stadium = location.Name
				};
				listVM.Add(locationVm);
			}
			dtgStadium.ItemsSource = null;
			dtgStadium.ItemsSource = listVM;
		}
	}
}
