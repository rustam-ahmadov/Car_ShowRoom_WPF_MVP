using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_ShowRoom_WPF_MVP.Model
{
    public class Car
    {
        bool _ready;
        public Car()
        {
            _ready = true;
        }
        public string ModelName { get; set; }
        public double Engine { get; set; }
        public string PicPath { get; set; }
        public DateTime Manufactured { get; set; }

        private double _consumption;
        public double Consumption
        {
            get
            {
                if (_ready)
                    _consumption = Engine / 2000;
                return _consumption;
            }
        }
        public override string ToString()
        {
            return $"Model-{ModelName} Engine-{Engine / 1000} Manufactured-{Manufactured.ToShortDateString()}";
        }
    }
}
