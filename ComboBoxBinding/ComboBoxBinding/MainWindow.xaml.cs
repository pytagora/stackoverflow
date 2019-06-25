using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComboBoxBinding
{
    public enum Side
    {
        Left,
        Right,
        Both,
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<ConfigurationData> _configurations;
        public ObservableCollection<ConfigurationData> Configurations
        {
            get
            {
                return _configurations;
            }
            set
            {
                _configurations = value;
            }
        }

        public class ConfigurationData
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class Record
        {
            public Side Side { get; set; }
            public ConfigurationData Configuration { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            dataGrid.Columns[0].Header = "Side";
            dataGrid.Columns[1].Header = "Configuration";

            Configurations = new ObservableCollection<ConfigurationData>() { new ConfigurationData() { Name = "TEST", Id = "id_test" }, new ConfigurationData() { Name = "configuration02", Id = "abcd" } };

            DataGrid_Load();
        }

        private void DataGrid_Load()
        {
            ObservableCollection<Record> records = new ObservableCollection<Record>();
            records.Add(new Record { Side = Side.Left, Configuration = Configurations[1] } ); 
            records.Add(new Record { Side = Side.Both, Configuration = Configurations[0] } );

            dataGrid.ItemsSource = records;
        }

        private void confgComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.ItemsSource = Configurations;
        }

        private void ParseDataButton_Click(object sender, RoutedEventArgs e)
        {
            var items = dataGrid.Items;
            foreach (var item in items)
            {
                Record record = (Record)item;
                MessageBox.Show(record.Side + " " + record.Configuration.Name);
            }
        }
    }
}
