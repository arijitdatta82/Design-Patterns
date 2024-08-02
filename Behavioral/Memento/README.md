# Memento Design Pattern

## Definition
The Memento design pattern is a behavioral pattern that allows you to save and restore an object's previous state without revealing implementation details. It's useful for implementing features like undo/redo, versioning, or checkpoints.

## Structure
![ScreenShot](/Assets/Images/Memento_UML.jpg)

## Real-Time Code Example
In this real time example, we are using memento design pattern to maintain purchase history. It helps to save a purchase order and restore its state from a previous purchase order.
[source code](Memento.cs)

<b>Memento</b> stores internal state of the Originator object. The memento may store as much or as little of the originator's internal state as necessary at its originator's discretion.
```
	public class PurchaserOrderMemento
	{
		public string Item { get; set; }
		public double Amount { get; set; }
	}
```

<b>Originator</b> creates a memento containing a snapshot of its current internal state. It uses the memento to restore its internal state.
```
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
```

<b>Caretaker</b> is responsible for the memento's safekeeping, It never operates on or examines the contents of a memento.
```
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
```

<b>Client Code:</b>
```
    PurchaseHistory history = new PurchaseHistory();
    
    PurchaserOrder purchareOrder1 = new PurchaserOrder("Book", 12.99);
    purchareOrder1.SetPrice(10.99);
    history.AddPurchase(purchareOrder1.CreateMemento());
    
    PurchaserOrder purchareOrder2 = new PurchaserOrder("CD", 15.99);			
    history.AddPurchase(purchareOrder2.CreateMemento());
    purchareOrder2.SetPrice(10.99);
    purchareOrder2.RestoreFromMemento(history.GetLastPurchase());
    
    history.ShowHistory();
```

<b>Output:</b>
```
Item: $Book - Price:$10.99
Item: $CD - Price:$15.99    
```