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
using Car_ShowRoom_WPF_MVP.Presenter;

namespace Car_ShowRoom_WPF_MVP.View
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window, IModalViews, ISell
    {
        #region Implementation of the Interface

        public event EventHandler Confirm;

        public string ModelName { get; set; }
        public Double Engine { get; set; }
        public DateTime Manufactured { get; set; }
        public void ShowDialog()
        {
            Button_Confirm.IsEnabled = false;
            TBoxEngine.Text = Engine.ToString();
            TBoxModelName.Text = ModelName;
            DPicker.SelectedDate = Manufactured;
            base.ShowDialog();
        }
        #endregion

        public InfoWindow()
        {
            InitializeComponent();
        }

        public event EventHandler CarSell;


        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            CarSell?.Invoke(sender, e);
            Close();
        }

        private void Button_Confirm_Click(object sender, RoutedEventArgs e)
        {
            Confirm?.Invoke(sender, e);
            Close();
        }

        private void TBoxModelName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ModelName = TBoxModelName.Text;
            Check();
        }

        private void TBoxEngine_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBoxEngine.Text!="")
            {
                Engine = double.Parse(TBoxEngine.Text);
                Check();
            }
            
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Manufactured = DPicker.SelectedDate.Value;
        }

        void Check()
        {
            if (ModelName != "" && Engine != -1)
                Button_Confirm.IsEnabled = true;

            else
                Button_Confirm.IsEnabled = false;
        }

    }
}
