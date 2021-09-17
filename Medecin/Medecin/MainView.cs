using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Medecin
{
     public class MainView
    {
        public static ObservableCollection<LItem> _Notes { get; set; }

        public static ObservableCollection<LItem> Notes
        {

            get { return Notes; }
            set
            {

                _Notes = value;
            }

        }
        public MainView()
        {
            _Notes = new ObservableCollection<LItem>();
        }
    }
}
