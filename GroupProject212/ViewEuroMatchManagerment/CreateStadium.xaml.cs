﻿using GroupProjectPRN212;
using Repositories.Models;
using Repositories.Repo;
using System.Text.RegularExpressions;
using System.Windows;
using ViewEuroMatchManagerment.Helper;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace ViewEuroMatchManagerment
{
	/// <summary>
	/// Interaction logic for CreateStadium.xaml
	/// </summary>
	public partial class CreateStadium : Window
	{
		private readonly ImgUpload _imgUpload;
		EuroMatchContext _context;
		LocationRepo _stadium;
		public CreateStadium()
		{
			InitializeComponent();
			var app = ((App)Application.Current);
			_imgUpload = new ImgUpload(app._firebaseEntities);
			_context = new EuroMatchContext();
			_stadium = new LocationRepo();
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
        public string _imageUrl;
        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image file (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                txtImgStadium.Text = filePath;
                _imageUrl = await _imgUpload.UploadFileImg(filePath);
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
		{
			if (ValidateInput())
			{
				//B1: Tao Airconditioner object
				var stadium = new Location()
				{
					Name = txtStadium.Text,
					ImageStadium = _imageUrl
                };
				//B2: Tao repo
				//B3: Save to database
				_stadium.Add(stadium);
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
