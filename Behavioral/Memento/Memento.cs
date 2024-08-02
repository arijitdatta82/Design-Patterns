using System;
using System.Collections.Generic;
			
namespace ArijitDatta.DesignPatterns.Behavioral.Memento
{
	// The 'Memento' class
	public class PurchaserOrderMemento
	{
		public string Item { get; set; }
		public double Amount { get; set; }
	}
	
	// The 'Caretaker' class
	public class PurchaseHistory {
    	private List<PurchaserOrderMemento> _history;

		public PurchaseHistory() {
			_history = new List<PurchaserOrderMemento>();
		}

		public void AddPurchase(PurchaserOrderMemento po) {
			_history.Add(po);
		}
		
		public PurchaserOrderMemento GetLastPurchase() {
        	return _history[_history.Count - 1];
    	}
		
		public void ShowHistory()
		{
			foreach (var po in _history)
			{
				Console.WriteLine(string.Format("Item: ${0} - Price:${1}", po.Item, po.Amount));
			}
		}
	}
	
	// The 'Originator' class
	public class PurchaserOrder {
		string _item;
		double _amount { get; set; }

		public PurchaserOrder(string item, double amount) {
			_item = item;
			_amount = amount;
		}

		public void SetPrice(double amount) {
			_amount = amount;
		}
		
		public PurchaserOrderMemento CreateMemento() {
			return new PurchaserOrderMemento { Item = _item, Amount = _amount };
		}

		public void RestoreFromMemento(PurchaserOrderMemento memento) {
			_item = memento.Item;
			_amount = memento.Amount;
		}
	}
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			PurchaseHistory history = new PurchaseHistory();
			
			PurchaserOrder purchareOrder1 = new PurchaserOrder("Book", 12.99);
			purchareOrder1.SetPrice(10.99);
        	history.AddPurchase(purchareOrder1.CreateMemento());
			
			PurchaserOrder purchareOrder2 = new PurchaserOrder("CD", 15.99);			
			history.AddPurchase(purchareOrder2.CreateMemento());
			purchareOrder2.SetPrice(10.99);
        	purchareOrder2.RestoreFromMemento(history.GetLastPurchase());
			
			history.ShowHistory();
		}
	}
}