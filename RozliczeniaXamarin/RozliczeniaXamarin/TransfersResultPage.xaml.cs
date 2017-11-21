using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RozliczeniaXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RozliczeniaXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TransfersResultPage : ContentPage
	{
		public static TransfersResultViewModel BindingContextDummyInstance => null;

		public TransfersResultPage ()
		{
			InitializeComponent ();
		}
	}
}