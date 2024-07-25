using GroupProjectPRN212;
using Repositories.Models;
using Repositories.Repo;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ViewEuroMatchManagerment.Helper;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;


namespace ViewEuroMatchManagerment
{
	/// <summary>
	/// Interaction logic for UpdateStadium.xaml
	/// </summary>
	public partial class UpdateStadium : Window
	{
		EuroMatchContext _context;
		LocationRepo _stadium;
		private ImgUpload _imgUpload;
		int stadiumId;
		public UpdateStadium(int stadiumId)
		{
			InitializeComponent();
            var app = ((App)Application.Current);
            _imgUpload = new ImgUpload(app._firebaseEntities);
            _context = new EuroMatchContext();
			_stadium = new LocationRepo();
			this.stadiumId = stadiumId;
			LoadData();
		}
		private void LoadData()
		{
			var stadium = _stadium.GetById(stadiumId);
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
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (ValidateInput())
			{
				var stadium = _context.Locations.Find(stadiumId);

				stadium.Name = txtStadium.Text;
				stadium.ImageStadium = _imageUrl;
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
