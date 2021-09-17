using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Medecin
{
    public partial class App : Application
    {
        public static Dictionary<string, ISimpleAudioPlayer> sounds = new Dictionary<string, ISimpleAudioPlayer>();
        private const string PATH = "Medecin";
        public App()
        {
            InitializeComponent();
            RegisterSound("success", "scan_success.wav");
            MainPage = new NavigationPage(new Startsidan1());
        }

        public static void Start()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), ()=> {
                DateTime v = DateTime.Now;
                string x1 = v.ToString();
                TimeSpan t = v.TimeOfDay;
                string x2 = t.ToString();
                for(int x = 0; x < MainView._Notes.Count; x++)
                {
                    var _ = MainView._Notes[x];
                    if(_.Time == x2 && _.Date == x1)
                    {
                        PlaySound("success");
                        InputPopup.Remove(_.Rnd);
                    }
                }
                return true;
            });


        }


        public static void PlaySound(string key)
        {
            sounds[key].Play();
        }

        private static void RegisterSound(string key, string path)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.
               GetManifestResourceStream(PATH + ".sounds." + path);
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);
             sounds.Add(key, player);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
