using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RozliczeniaXamarin.Models;

namespace RozliczeniaXamarin.ViewModels
{
	public class TransfersResultViewModel
	{
		public ObservableCollection<TransferViewModel> Transfers { get; } = new ObservableCollection<TransferViewModel>();

		public TransfersResultViewModel() :
			this(Enumerable.Empty<Transfer>())
		{

		}

		public TransfersResultViewModel(IEnumerable<Transfer> transfers)
		{
			foreach(var transfer in transfers)
			{
				Transfers.Add(new TransferViewModel(transfer));
			}
		}
	}
}
