using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RozliczeniaXamarin
{
	public partial class MainPage : ContentPage
	{
		public static MainPageViewModel BindingContextDummyInstance => null;

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnCalculateButtonClick(object sender, EventArgs e)
		{
			var vm = (MainPageViewModel) BindingContext;
			Navigation.PushModalAsync(new TransfersResultPage
			{
				BindingContext = vm.ProvideViewModelForCalculatedTransfers()
			});
		}
	}
}
