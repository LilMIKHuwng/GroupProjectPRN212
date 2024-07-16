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
    /// Interaction logic for MatchesDetail.xaml
    /// </summary>
    public partial class MatchesDetail : Window
    {
        public MatchesDetail()
        {
            InitializeComponent();
            TeamRepo _repoTeam = new();
            LocationRepo _repoLocation = new();
            listTeams = _repoTeam.GetAll();
            listLocation = _repoLocation.GetAll();
        }
        MatchRepo _repoMatch = new();
        public Match selectedMatch { private get; set; } = null;
        List<Team> listTeams;
        List<Location> listLocation;
        private void Windown_Loaded(object sender, RoutedEventArgs e)
        {
            LoadComboBox(listTeams, HomeTeamComboBox, "Name", "Id");
            LoadComboBox(listTeams, GuestTeamComboBox, "Name", "Id");
            LoadComboBox(listLocation, LocationComboBox, "Name", "Id");
            if (selectedMatch != null)
            {
                TitleLabel.Content = "Update Match";
                IdMatchTextBox.Text = selectedMatch.Id.ToString();
                IdMatchTextBox.IsEnabled = false;
                LocationComboBox.SelectedValue = selectedMatch.LocationId;
                HomeTeamComboBox.SelectedValue = selectedMatch.TeamAid;
                GuestTeamComboBox.SelectedValue = selectedMatch.TeamBid;
                GoalHomeTeamTextBox.Text = selectedMatch.GoalTeamA.ToString();
                GoalGuestTeamTextBox.Text = selectedMatch.GoalTeamB.ToString();
                AttendanceTextBox.Text = selectedMatch.Attendance.ToString();
            }
            else
            {
                IdMatchTextBox.Visibility = Visibility.Collapsed;
                IdMatchLable.Visibility = Visibility.Collapsed;
            }

        }

        private void LoadComboBox<T>(List<T> list, ComboBox comboBox, string displayMemberPath, string selectedValuePath)
        {
            comboBox.ItemsSource = list;
            comboBox.DisplayMemberPath = displayMemberPath;
            comboBox.SelectedValuePath = selectedValuePath;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AttendanceTextBox.Text) || HomeTeamComboBox.SelectedItem == null || GuestTeamComboBox.SelectedItem == null
               || LocationComboBox.SelectedItem == null || string.IsNullOrWhiteSpace(GoalHomeTeamTextBox.Text) || string.IsNullOrWhiteSpace(GoalGuestTeamTextBox.Text))
            {
                MessageBox.Show("All fields of Matche are required", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                int attendance = int.Parse(AttendanceTextBox.Text);
                int goalHomeTeam = int.Parse(GoalHomeTeamTextBox.Text);
                int goalGuestTeam = int.Parse(GoalGuestTeamTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong format field", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            

            if (selectedMatch != null)
            {
                selectedMatch.Attendance = AttendanceTextBox.Text;
                selectedMatch.LocationId = int.Parse(LocationComboBox.SelectedValue.ToString());
                selectedMatch.TeamAid = int.Parse(HomeTeamComboBox.SelectedValue.ToString());
                selectedMatch.TeamBid = int.Parse(GuestTeamComboBox.SelectedValue.ToString());
                selectedMatch.GoalTeamA = int.Parse(GoalHomeTeamTextBox.Text);
                selectedMatch.GoalTeamB = int.Parse(GoalGuestTeamTextBox.Text);

                _repoMatch.Update(selectedMatch);
                this.Close();
            }
            else
            {
                Match newMatch = new Match();
                newMatch.Attendance = AttendanceTextBox.Text;
                newMatch.LocationId = int.Parse(LocationComboBox.SelectedValue.ToString());
                newMatch.TeamAid = int.Parse(HomeTeamComboBox.SelectedValue.ToString());
                newMatch.TeamBid = int.Parse(GuestTeamComboBox.SelectedValue.ToString());
                newMatch.GoalTeamA = int.Parse(GoalHomeTeamTextBox.Text);
                newMatch.GoalTeamB = int.Parse(GoalGuestTeamTextBox.Text);
                _repoMatch.Add(newMatch);
                DialogResult = true;
                this.Close();
            }
        }

        private void HomeTeamComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (HomeTeamComboBox.SelectedItem != null)
            {
                Team selectedTeam = HomeTeamComboBox.SelectedItem as Team;
                List<Team> filteredTeams = listTeams.Where(team => team.Id != selectedTeam.Id).ToList();
                LoadComboBox(filteredTeams, GuestTeamComboBox, "Name", "Id");
            }
            else
            {
                LoadComboBox(listTeams, GuestTeamComboBox, "Name", "Id");
            }
        }

        private void GuestTeamComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GuestTeamComboBox.SelectedItem != null)
            {
                Team selectedTeam = GuestTeamComboBox.SelectedItem as Team;
                List<Team> filteredTeams = listTeams.Where(team => team.Id != selectedTeam.Id).ToList();
                LoadComboBox(filteredTeams, HomeTeamComboBox, "Name", "Id");
            }
            else
            {
                LoadComboBox(listTeams, HomeTeamComboBox, "Name", "Id");
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
