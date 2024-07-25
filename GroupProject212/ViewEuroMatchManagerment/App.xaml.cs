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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

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
