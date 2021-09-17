using System;
using System.Collections.Generic;
using System.Text;

namespace Medecin
{
    public class LItem
    {
        public int Rnd { get; set; }
        public string Text { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }


        //public LItem( string text, string time, string date)
        //{
        //    Text = text;
        //    Time = time;
        //    Date = date;
        //}

        public override string ToString()
        {
            return Text;
        }
    }
}
