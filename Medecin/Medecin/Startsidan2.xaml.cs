using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Controls;

namespace Medecin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Startsidan2 :TabbedPage
	{
        public static ObservableCollection<LItem> _Notes { get; set; }


        public Startsidan2 ()
		{
			InitializeComponent ();

            _Notes = new ObservableCollection<LItem>();
            lst.ItemsSource = _Notes;

            calender3.SelectedDate = DateTime.Now;
            calender3.StartDay = DayOfWeek.Sunday;
            calender3.DateClicked += (s, e) =>
            {
                var a = e.DateTime.ToString().Split(' ')[0];
                new Popup(new InputPopup(a, this), this).Show();
                return;
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            var x = b.BindingContext as LItem;
            InputPopup.Remove(x.Rnd);
        }
    }
}