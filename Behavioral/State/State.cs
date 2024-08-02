using System;
			
namespace ArijitDatta.DesignPatterns.Behavioral.State
{
	// The 'State' interface
	public interface IOrderState
	{
		void SetNextState(PurchaseOrder po);
		void SetPrevState(PurchaseOrder po);
	}
	
	// The 'Concrete State' class
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
	
	// The 'Concrete State' class
	public class ProcessOrder : IOrderState
	{
		public void SetNextState(PurchaseOrder po)
		{
			po.State = new ShipOrder();
		}
		
		public void SetPrevState(PurchaseOrder po)
		{
			po.State = new NewOrder();
		}
	}
	
	// The 'Concrete State' class
	public class ShipOrder : IOrderState
	{
		public void SetNextState(PurchaseOrder po)
		{
			po.State = new CompleteOrder();
		}
		
		public void SetPrevState(PurchaseOrder po)
		{
			po.State = new ProcessOrder();
		}
	}
	
	// The 'Concrete State' class
	public class CompleteOrder : IOrderState
	{
		public void SetNextState(PurchaseOrder po)
		{
			po.State = this;
		}
		
		public void SetPrevState(PurchaseOrder po)
		{
			po.State = new ShipOrder();
		}
	}
	
	// The 'Context' class
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
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			PurchaseOrder order = new PurchaseOrder("PO-000001");
			order.Next();
			order.Next();
			order.Next();
			order.Previous();
			Console.WriteLine("---------------------------------------------------");
			
		}
	}
}