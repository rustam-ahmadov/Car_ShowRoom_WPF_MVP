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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window, IModalViews
    {
        #region InterfaceImplement
        public event EventHandler Confirm;
        public DateTime Manufactured { get; set; }
        public string ModelName { get; set; }
        public Double Engine { get; set; }

        void IModalViews.ShowDialog()
        {
            base.ShowDialog();
        }
        #endregion

        public AddWindow()
        {
            InitializeComponent();
            ButConfirm.IsEnabled = false;
        }

        private void ButConfirm_Click(object sender, RoutedEventArgs e)
        {
            Confirm?.Invoke(sender, e);
            this.Close();
        }

        private void TBoxModelName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ModelName = TBoxModelName.Text;
            Check();
        }

        private void DatePic_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Manufactured = DatePic.SelectedDate.Value;
            Check();
        }

       

        private void TextBoEng_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            Engine = double.Parse(TextBoEng.Text);
            Check();
        }
        void Check()
        {
            if (Engine!=0&&Manufactured!=DateTime.Today&&ModelName!=null)
            {
                ButConfirm.IsEnabled = true;
            }
        }
    }
}
