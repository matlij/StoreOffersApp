using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLocator.Helpers
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPagerView : ContentPage
	{
		public MasterPagerView ()
		{
			InitializeComponent ();
		}
	}
}