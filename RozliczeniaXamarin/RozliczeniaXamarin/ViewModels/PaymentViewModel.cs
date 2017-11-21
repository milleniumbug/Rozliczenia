using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RozliczeniaXamarin.Annotations;
using RozliczeniaXamarin.Models;
using Xamarin.Forms;

namespace RozliczeniaXamarin
{
	public class PaymentViewModel : INotifyPropertyChanged
	{
		private string who;
		private string moneyAmount;

		public string MoneyAmount
		{
			get { return moneyAmount; }
			set
			{
				if(value == moneyAmount) return;
				moneyAmount = value;
				OnPropertyChanged();
			}
		}

		public string Who
		{
			get { return who; }
			set
			{
				if(value == who) return;
				who = value;
				OnPropertyChanged();
			}
		}

		public PaymentViewModel()
		{
			
		}

		public PaymentViewModel(Payment payment)
		{
			Who = payment.Who.Name;
			MoneyAmount = payment.MoneyAmount.ToString("C");
		}

		public Payment Build()
		{
			if(string.IsNullOrWhiteSpace(Who) || string.IsNullOrWhiteSpace(MoneyAmount))
				return null;
			return new Payment(new Person(Who), decimal.Parse(MoneyAmount));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}