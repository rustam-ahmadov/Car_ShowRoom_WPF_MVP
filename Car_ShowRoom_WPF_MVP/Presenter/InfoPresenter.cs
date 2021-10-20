using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Car_ShowRoom_WPF_MVP.View;
using Car_ShowRoom_WPF_MVP.Model;
using Car_ShowRoom_WPF_MVP.Services;

namespace Car_ShowRoom_WPF_MVP.Presenter
{
    public class InfoPresenter
    {
        Car car;
        IModalViews view;
        ISell view1;
        public InfoPresenter(IModalViews v, Car c)
        {
            car = c;
            view = v;
            view.Confirm += View_Confirm;
            v.ModelName = car.ModelName;
            v.Engine = car.Engine;
            v.Manufactured = c.Manufactured;
            view1 = v as ISell;
            view1.CarSell += View1_CarSell;
            view.ShowDialog();

        }

        private void View1_CarSell(object sender, EventArgs e)
        {
            car.ModelName = null;
        }

        private void View_Confirm(object sender, EventArgs e)
        {
            car.Engine = view.Engine;
            car.ModelName = view.ModelName;
            car.Manufactured = view.Manufactured;
        }
    }
}
