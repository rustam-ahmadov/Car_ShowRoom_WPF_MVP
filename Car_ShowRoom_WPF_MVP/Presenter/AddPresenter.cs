using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Car_ShowRoom_WPF_MVP.View;
using Car_ShowRoom_WPF_MVP.Model;
using Car_ShowRoom_WPF_MVP.Services;

namespace Car_ShowRoom_WPF_MVP.Presenter
{
    public class AddPresenter
    {
        IModalViews view;
        Car car;
        public AddPresenter(IModalViews v, Car c)
        {
            car = c;
            view = v;
            view.Confirm += new EventHandler(IAddV_Confirm);
            view.ShowDialog();
        }
        private void IAddV_Confirm(object sender, EventArgs e)
        {
            car.ModelName = view.ModelName;
            car.Engine = view.Engine;
            car.Manufactured = view.Manufactured;
        }
    }
}
