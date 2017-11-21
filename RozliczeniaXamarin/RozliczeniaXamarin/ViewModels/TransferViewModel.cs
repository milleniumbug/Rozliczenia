using System.ComponentModel;
using System.Runtime.CompilerServices;
using RozliczeniaXamarin.Annotations;
using RozliczeniaXamarin.Models;

namespace RozliczeniaXamarin
{
	public class TransferViewModel : INotifyPropertyChanged
	{
		private Transfer transfer;

		public Transfer Transfer
		{
			get => transfer;
			set
			{
				if(transfer == value) return;
				transfer = value;
				OnPropertyChanged();
				OnPropertyChanged(nameof(From));
				OnPropertyChanged(nameof(To));
				OnPropertyChanged(nameof(MoneyAmount));
			}
		}

		public string From => Transfer.From.Name;

		public string To => Transfer.To.Name;

		public decimal MoneyAmount => Transfer.MoneyAmount;

		public TransferViewModel(Transfer transfer)
		{
			Transfer = transfer;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}