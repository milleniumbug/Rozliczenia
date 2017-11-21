using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using RozliczeniaXamarin.Models;
using RozliczeniaXamarin.ViewModels;
using Xamarin.Forms;

namespace RozliczeniaXamarin
{
	public class MainPageViewModel
	{
		public ObservableCollection<PaymentViewModel> Payments { get; } = new ObservableCollection<PaymentViewModel>();

		public ICommand Remove { get; }

		public ICommand Add { get; }

		public MainPageViewModel() :
			this(Enumerable.Empty<Payment>())
		{

		}

		public MainPageViewModel(IEnumerable<Payment> payments)
		{
			foreach(var payment in payments)
			{
				Payments.Add(new PaymentViewModel(payment));
			}
			Remove = new Command<PaymentViewModel>(payment =>
			{
				Payments.Remove(payment);
			});
			Add = new Command(() =>
			{
				Payments.Insert(0, new PaymentViewModel());
			});
		}

		public TransfersResultViewModel ProvideViewModelForCalculatedTransfers()
		{
			return new TransfersResultViewModel(
				Calculator.DistributeCosts(Payments.Select(paymentVm => paymentVm.Build()).Where(payment => payment != null).ToList()));
		}
	}
}
