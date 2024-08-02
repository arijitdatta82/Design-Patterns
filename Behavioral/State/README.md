# State Design Pattern

## Definition
The state design pattern is a behavioral software design pattern that allows an object to alter its behavior when its internal state changes. It achieves this by encapsulating the object’s behavior within different state objects, and the object itself dynamically switches between these state objects depending on its current state.

## Structure
![ScreenShot](/Assets/Images/State_UML.jpg)

## Real-Time Code Example
In this real time example, we are using state design pattern to maintain the state of a purchase order. Based on the current state of an order it can determine its next or previous state.
[source code](State.cs)

<b>State</b> defines an interface for encapsulating the behavior associated with a particular state of the Context.
```
    public interface IOrderState
	{
		void SetNextState(PurchaseOrder po);
		void SetPrevState(PurchaseOrder po);
	}
```

<b>ConcreteState</b> implements a behavior associated with a state of Context
```
	public class NewOrder : IOrderState
	{
		public void SetNextState(PurchaseOrder po)
		{
			po.State = new ProcessOrder();
		}
		
		public void SetPrevState(PurchaseOrder po)
		{
			po.State = this;
		}
	}
```

<b>Context</b> defines the interface of interest to clients and maintains an instance of a ConcreteState subclass that defines the current state.
```
	public class PurchaseOrder
	{
		IOrderState _currentState;
		string _orderNum;
		public PurchaseOrder(string orderNum)
		{
			_currentState = new NewOrder();
			_orderNum = orderNum;
			Console.WriteLine(string.Format("Purchase order {0} is creted with state: {1}", _orderNum, _currentState.GetType().Name));
		}
		public IOrderState State
        {
            get { return _currentState; }
            set
            {
                _currentState = value;
                Console.WriteLine(string.Format("State of {0} is set to: {1}", _orderNum, _currentState.GetType().Name));
            }
        }
		public void Next()
		{
			_currentState.SetNextState(this);
		}
		public void Previous()
		{
			_currentState.SetPrevState(this);
		}
	}
```

<b>Client Code:</b>
```
    PurchaseOrder order = new PurchaseOrder("PO-000001");
    order.Next();
    order.Next();
    order.Next();
    order.Previous();
    Console.WriteLine("---------------------------------------------------");
```

<b>Output:</b>
```
Purchase order PO-000001 is creted with state: NewOrder
State of PO-000001 is set to: ProcessOrder
State of PO-000001 is set to: ShipOrder
State of PO-000001 is set to: CompleteOrder
State of PO-000001 is set to: ShipOrder
---------------------------------------------------    
```