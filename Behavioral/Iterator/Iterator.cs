using System;
using System.Collections.Generic;
			
namespace ArijitDatta.DesignPatterns.Behavioral.Iterator
{
	// A collection item
	public class PurchaseOrder
    {
        string _poNumber;
        public PurchaseOrder(string poNumber)
        {
            _poNumber = poNumber;
        }
        public void ProcessOrder()
        {
            Console.WriteLine(string.Format("Process Order # {0} is being processed. Items will be shipped.", _poNumber));
        }
    }
	
	// The 'Aggregate' interface
    public interface IPurchaseOrderList
    {
        IIterator CreateIterator();
    }
	
	// The 'Concrete Aggregate' class
    public class PurchaseOrderList : IPurchaseOrderList
    {
		public List<PurchaseOrder> Items = new List<PurchaseOrder>();
        public IIterator CreateIterator()
        {
            return new PurchaseOrderIterator(this);
        }
		public void Add(PurchaseOrder po)
		{
			Items.Add(po);
		}
    }
	
	// The 'Iterator' interface
    public interface IIterator
    {
        PurchaseOrder Next();
    }
    
	// The 'Concrete Iterator' class
    public class PurchaseOrderIterator : IIterator
    {
        PurchaseOrderList collection;
        int current = 0;
        public PurchaseOrderIterator(PurchaseOrderList collection)
        {
            this.collection = collection;
        }
        public PurchaseOrder Next()
        {
            if (collection.Items.Count > current)
				return collection.Items[current++];
			else
                return null;
        }       
    }
	
	public class Program
	{
		// Client Code
		public static void Main()
		{
			var poList = new PurchaseOrderList();
			poList.Add(new PurchaseOrder("PO-1"));
			poList.Add(new PurchaseOrder("PO-2"));
			poList.Add(new PurchaseOrder("PO-3"));
			poList.Add(new PurchaseOrder("PO-4"));
			poList.Add(new PurchaseOrder("PO-5"));
			
			var iterator = poList.CreateIterator();
			PurchaseOrder order;
			order = iterator.Next();
			while (order != null)
			{
				order.ProcessOrder();
				order = iterator.Next();
			} 
			
		}
	}
}