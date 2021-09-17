 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
 

namespace Medecin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class Startsidan1 : ContentPage
	{
       

        DateTime Time = DateTime.Today;

        public int count = 14400;

        public Timer T;




        public Startsidan1()
        {
            InitializeComponent();

            copyR.Text = "NTI-Gymnasiet© " + "Helsingborg " + Time.ToString("yyy") + "\nSkapades av: ©Osama Och Mohanad";
            Timer();


        }

        public  void Timer()
        {
              T = new Timer();
            T.Interval = 1000;
            T.Elapsed += T_Elapsed;
            T.Start();
             
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime dt = new DateTime();
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                tid.Text = dt.AddSeconds(count).ToString("HH:mm:ss");
                count--;
                if (count == 0)
                {
                    App.PlaySound("success");
                    DisplayAlert("Info", "Nu är det dags", "Okej");
                    count = 14400;
                    T.Start();
                }
                
            });
           
        }

 
         private void Calenderbtn_Clicked(object sender, EventArgs e)
        {
              Navigation.PushAsync( new Startsidan2());
        }

        private void Weatherbtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Startsidan3());
        }
    }
}