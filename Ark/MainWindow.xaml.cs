using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ark.Models.Config;
using Ark.Services;

namespace Ark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfigurationBuilder builder;
        ConfigReader configReader;
        Config ConfigModel;

        public MainWindow()
        {
            builder = new ConfigurationBuilder();
            ConfigModel = new Config();
            configReader = new ConfigReader(builder, ConfigModel);
            if (ConfigModel.mainPathsFilled())
            {
                InitializeComponent();
            }
            else
            {
                InitSettings paths = new InitSettings();
                if (paths.pathFolder != null)
                {
                    configReader.WriteValuesPaths(paths.pathFolder);
                    InitializeComponent();
                }

                else
                    this.Close();
            }
        }
    }
}