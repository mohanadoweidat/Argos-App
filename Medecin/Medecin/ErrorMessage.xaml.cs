using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Medecin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ErrorMessage : StackLayout
	{
		public ErrorMessage ()
		{
			InitializeComponent ();
		}
	}
}