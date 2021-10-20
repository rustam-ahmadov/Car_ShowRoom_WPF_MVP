using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


using Car_ShowRoom_WPF_MVP.Presenter;
using Car_ShowRoom_WPF_MVP.Model;
using Car_ShowRoom_WPF_MVP.View;

namespace Car_ShowRoom_WPF_MVP.Services
{
    public interface IMainView
    {
        public event EventHandler Info_Click;
        public event EventHandler Add_Click;
        public event EventHandler Selection_Changed;
        public event EventHandler Sort;
        public event EventHandler Close;
        public event EventHandler Load;

        public void ListUpdate(IEnumerable<Car> cars);
        public int SelecIndex { get; set; }
    }
}
