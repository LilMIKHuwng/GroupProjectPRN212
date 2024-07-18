
using Repositories.Models;
using Repositories.Repo;
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
using System.IO;
using ViewEuroMatchManagerment.ViewModel;
using Microsoft.Win32;
using System.Data;
using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Spreadsheet;


namespace ViewEuroMatchManagerment
{
    /// <summary>
    /// Interaction logic for MatchesManager.xaml
    /// </summary>
    public partial class MatchesManager : System.Windows.Window
    {
        public MatchesManager()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MatchesDetail matchesDetail = new MatchesDetail();
            matchesDetail.ShowDialog();
            LoadMatchesGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMatchesGrid();
        }

        MatchRepo _repoMatch = new();
        private void LoadMatchesGrid()
        {
            List<Match> list = _repoMatch.GetAll();
            ListMatchesDataGrid.ItemsSource = null;
            ListMatchesDataGrid.ItemsSource = list;
        }

        private void ListMatchesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Match selectedMatch = ListMatchesDataGrid.SelectedItem as Match;
            if (selectedMatch == null)
            {
                MessageBox.Show("Please select a Match that you want to edit", "Select One", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MatchesDetail matchesDetail = new MatchesDetail();
            matchesDetail.selectedMatch = selectedMatch;
            matchesDetail.ShowDialog();
            LoadMatchesGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Match match = ListMatchesDataGrid.SelectedItem as Match;
            if (match == null)
            {
                MessageBox.Show("Please select a Match that you want to edit", "Select One", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var message = MessageBox.Show("Do you really want to delete this match?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (message == MessageBoxResult.Yes)
            {
                _repoMatch.Delete(match);
            }
            LoadMatchesGrid();
        }

		private void QuitButton_Click(object sender, RoutedEventArgs e)
		{
			var result = MessageBox.Show("Do you want to quit?", "Quit?", MessageBoxButton.OKCancel, MessageBoxImage.Question);
			if (result == MessageBoxResult.OK)
			{
				this.Close();
			}
		}

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            MatchRepo _repoMatch = new MatchRepo();
            List<Match> listMatch = _repoMatch.GetAll();
            try
            {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "MatchesExport.xlsx";
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
                    workbook.SaveAs(filePath);

                    MessageBox.Show("Dữ liệu từ DataGrid đã được xuất ra file Excel thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

      
           

        
    }
}
