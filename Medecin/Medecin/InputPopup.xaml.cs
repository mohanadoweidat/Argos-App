using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Medecin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InputPopup : StackLayout
	{
        
        string date;
        Page page;
        public static Random r = new Random();

		public InputPopup (string date, Page page)
		{
            this.page = page;
            this.date = date;
			InitializeComponent ();
            
           
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            if(ent.Text != null)
            {
                var _x = ent.Text;
                var time = tm.Time;
                Add(_x, time);
                
            } else
            {
                new Popup(new ErrorMessage(), page).Show();
                
            }
        }

        public void Add(string text, TimeSpan time)
        {
            //ERROr HERE !!
            int rn = r.Next(50000);
            bool __ = false;
            if (!App.Current.Properties.ContainsKey("Notes"))
            {
                __ = true;
            } else
            {
                var x = App.Current.Properties["Notes"] as string;
                __ = x == null || x == "";
            }
            if (__)
            {
                App.Current.Properties["Notes"] = rn + "$" + text + "$" + time.ToString() + "$" + date.ToString();
            } else
            {
                App.Current.Properties["Notes"] += "#" + rn + "$" + text + "$" + time.ToString() + "$" + date.ToString();
            }

            App.Current.SavePropertiesAsync();
            var _ = new LItem { Text = text, Time = time.ToString(), Date=date,
            Rnd=rn};
            Startsidan2._Notes.Add(_);
            Navigation.PopPopupAsync();
        }

        public static void Remove(int rnd)
        {
            for(int z = 0; z < Startsidan2._Notes.Count; z++)
            {
                if(Startsidan2._Notes[z].Rnd == rnd)
                {
                    Startsidan2._Notes.RemoveAt(z);
                }
            }
            var x = (App.Current.Properties["Notes"] as string).Split('#');
            string notes = "";
            foreach (string s in x)
            {
                var _ = s.Split('$');
                int rn = int.Parse(_[0]);
                if(rnd != rn)
                {
                    if(notes != "")
                    {
                        notes += ";";
                    }
                    notes += s;
                }
            }
            App.Current.Properties["Notes"] = notes;
            App.Current.SavePropertiesAsync();
        }

    }
}