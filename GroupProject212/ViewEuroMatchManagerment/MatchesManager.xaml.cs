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

namespace ViewEuroMatchManagerment
{
    /// <summary>
    /// Interaction logic for MatchesManager.xaml
    /// </summary>
    public partial class MatchesManager : Window
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
    }
}
