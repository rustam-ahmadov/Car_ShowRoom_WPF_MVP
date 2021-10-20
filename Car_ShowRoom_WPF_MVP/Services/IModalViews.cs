using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Car_ShowRoom_WPF_MVP.Presenter;
using Car_ShowRoom_WPF_MVP.Model;
using Car_ShowRoom_WPF_MVP.View;

namespace Car_ShowRoom_WPF_MVP.Services
{
    public interface IModalViews
    {
        public string ModelName { get; set; }
        public Double Engine { get; set; }
        public DateTime Manufactured { get; set; }
        public void ShowDialog();
        public event EventHandler Confirm;
    }
}
