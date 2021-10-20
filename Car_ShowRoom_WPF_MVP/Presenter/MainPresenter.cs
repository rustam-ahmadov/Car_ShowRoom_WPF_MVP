using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Car_ShowRoom_WPF_MVP.View;
using Car_ShowRoom_WPF_MVP.Model;
using Car_ShowRoom_WPF_MVP.Services;
using System.Text.Json;

namespace Car_ShowRoom_WPF_MVP.Presenter
{
    public class MainPresenter
    {
        AddWindow addWindow;
        InfoWindow infoWindow;

        AddPresenter addPresenter;
        InfoPresenter infoPresenter;

        IMainView MainView;

        List<Car> cars = new();
        int _selectedIndex = -1;
        public MainPresenter(IMainView view)
        {
            MainView = view;
            MainView.Add_Click += MainView_ADD_BC;
            MainView.Info_Click += MainView_INFO_BC;
            MainView.Selection_Changed += MainView_SelChanged;
            MainView.Close += MainView_Close;
            MainView.Load += MainView_Load;
        }


        #region MainView Events

        private async void MainView_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"C:\Users\ahmad\source\repos\Car_ShowRoom_WPF_MVP\Car_ShowRoom_WPF_MVP");

            if (File.Exists("Cars\\cars.json"))
            {
                using (FileStream fs = new FileStream("Cars\\cars.json", FileMode.Open))                
                {                    
                    cars = await JsonSerializer.DeserializeAsync<List<Car>>(fs);
                }
                MainView.ListUpdate(cars);
            }
        }

        private async void MainView_Close(object sender, EventArgs e)
        {
            string path = "Cars";
            byte[] json;
            if (!Directory.Exists(path) && cars.Count > 0)
            {
                Directory.CreateDirectory("Cars");
            }

            if (Directory.Exists("Cars"))
            {
                path += "\\cars.json";
                using (FileStream fileStream = new(path, FileMode.Create))
                {
                    json = JsonSerializer.SerializeToUtf8Bytes(cars);
                    await fileStream.WriteAsync(json, 0, json.Length);
                }
            }
        }



        private void MainView_INFO_BC(object sender, EventArgs e)
        {
            if (_selectedIndex != -1)
            {
                infoWindow = new InfoWindow();
                infoPresenter = new InfoPresenter(infoWindow, cars[_selectedIndex]);
                if (cars[_selectedIndex].ModelName==null)
                {
                    cars.RemoveAt(_selectedIndex);
                }
                MainView.ListUpdate(cars);
            }
            else
                MessageBox.Show("U havent choosen any car yet!!!", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        void MainView_ADD_BC(object sender, EventArgs e)
        {
            if (cars.Count<10)
            {
                Car car = new();
                addWindow = new AddWindow();
                addPresenter = new AddPresenter(addWindow, car);
                if (car.ModelName!=null)
                {
                    cars.Add(car);
                    MainView.ListUpdate(cars);
                }
               
            }
            else
                MessageBox.Show("There is no place for another car in ShowRoom", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        void MainView_SelChanged(object sender, EventArgs e)
        {
            _selectedIndex = MainView.SelecIndex;
        }
        #endregion

    }
}
