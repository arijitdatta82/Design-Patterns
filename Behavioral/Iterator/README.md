# Iterator Design Pattern

## Definition
The iterator design pattern provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation.

## Structure
![ScreenShot](/Assets/Images/Iterator_UML.jpg)

## Real-Time Code Example
In this real-world example of iterator design pattern, we are creating a list of purchase order. The program allows us to iterate through each purchase order item and work with it.
[source code](Iterator.cs)

<b>Iterator</b> defines an interface for accessing and traversing elements.
```
    public interface IIterator
    {
        PurchaseOrder Next();
    }
```

<b>ConcreteIterator</b> implements the Iterator interface and keeps track of the current position in the traversal of the aggregate.
```
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
```

<b>Aggregate</b> defines an interface for creating an Iterator object
```
    public interface IPurchaseOrderList
    {
        IIterator CreateIterator();
    }
```

<b>ConcreteAggregate</b> implements the Iterator creation interface to return an instance of the proper ConcreteIterator
```
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
```

<b>Client Code:</b>
```
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
```

<b>Output:</b>
```
Process Order # PO-1 is being processed. Items will be shipped.
Process Order # PO-2 is being processed. Items will be shipped.
Process Order # PO-3 is being processed. Items will be shipped.
Process Order # PO-4 is being processed. Items will be shipped.
Process Order # PO-5 is being processed. Items will be shipped.    
```