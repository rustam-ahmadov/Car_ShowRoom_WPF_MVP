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


using Car_ShowRoom_WPF_MVP.Services;
using Car_ShowRoom_WPF_MVP.Model;
using Car_ShowRoom_WPF_MVP.View;

namespace Car_ShowRoom_WPF_MVP.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainView : Window, IMainView
    {
        List<Car> cars;

        public MainView()
        {
            InitializeComponent();
            new Presenter.MainPresenter(this);
        }

        #region Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Load(sender, e);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close(sender, e);
        }
        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            Info_Click.Invoke(sender, e);

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Add_Click?.Invoke(sender, e);
        }
        private void ListBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelecIndex = ListBoxCars.SelectedIndex;
            Selection_Changed?.Invoke(sender, e);
        }

        #endregion

        #region InterfaceImplementation

        public event EventHandler Info_Click;
        public event EventHandler Add_Click;
        public event EventHandler Selection_Changed;
        public event EventHandler Sort;
        public event EventHandler Close;
        public event EventHandler Load;
        public int SelecIndex { get; set; }

        public void ListUpdate(IEnumerable<Car> cars)
        {

            ListBoxCars.Items.Clear();

            foreach (var item in cars)
            {
                ListBoxCars.Items.Add(item);
            }
        }


        #endregion


    }



}
