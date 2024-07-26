using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using ViewEuroMatchManagerment.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace GroupProjectPRN212
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration _configurations {  get; private set; }
        public FirebaseEntities _firebaseEntities {  get; private set; }
        public IServiceProvider _servicesProvider {  get; private set; }
        private System.Windows.Forms.NotifyIcon _notifyIcon;

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose(); // Dispose the tray icon
            base.OnExit(e); // Exit the application
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Icon = new System.Drawing.Icon(@"D:\FPTU\Ky5\PRN211\GroupProjectPRN212\football-05_icon-icons.com_75132.ico"),
                Visible = true,
                Text = "Euro Match Management"
            };

            _notifyIcon.DoubleClick += (s, args) =>
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                mainWindow.WindowState = WindowState.Normal;
            };

            // Create the context menu
            var contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            contextMenuStrip.Items.Add("Exit", null, (s, args) => Shutdown()); // Shut down the application

            _notifyIcon.ContextMenuStrip = contextMenuStrip;
            // Cấu hình đọc từ appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configurations = builder.Build();
            _firebaseEntities = new FirebaseEntities();
            _configurations.GetSection("FirebaseSettings").Bind(_firebaseEntities);

            //Cấu hình dependency injection App
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(_firebaseEntities);
            _servicesProvider = serviceCollection.BuildServiceProvider();
        }
    }

}
