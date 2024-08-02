# Design Patterns using C#

## What is a Design Pattern
The design patterns is communicating objects and classes that are customized to solve a general design problem in a particular context.
Design patterns are solutions to software design problems we find again and again in real-world application development. Patterns are about reusable designs and interactions of objects.
Using a pattern is intended to leverage an existing concept rather than re-inventing it.

## Types of Design Patterns
There are three types of Design Patterns,

1. Creational Design Pattern
2. Structural Design Pattern
3. Behavioral Design Pattern

## Creational Design Pattern
Creational Design Pattern abstract the instantiation process. They help in making a system independent of how its objects are created, composed and represented.

|||
| -------- | ------- |
|[Abstract Factory](Creational/AbstractFactory/README.md) | Creates an instance of several families of classes |
|[Builder](Creational/Builder/README.md) | Separates object construction from its representation |
|[Factory Method](Creational/FactoryMethod/README.md) | Creates an instance of several derived classes |
|[Prototype](Creational/Prototype/README.md) | A fully initialized instance to be copied or cloned |
|[Singleton](Creational/Singleton/README.md) | A class of which only a single instance can exist |

## Structural Design Patterns
Structural patterns are concerned with how classes and objects are composed to form larger structures. Structural class patterns use inheritance to compose interfaces or implementations.

|||
| -------- | ------- |
|[Adapter](Structural/Adapter/README.md) |	Match interfaces of different classes |
|[Bridge](Structural/Bridge/README.md) |	Separates an object’s interface from its implementation |
|[Composite](Structural/Composite/README.md) |	A tree structure of simple and composite objects |
|[Decorator](Structural/Decorator/README.md) |	Add responsibilities to objects dynamically |
|[Facade](Structural/Facade/README.md) |	A single class that represents an entire subsystem |
|[Flyweight](Structural/Flyweight/README.md) |	A fine-grained instance used for efficient sharing |
|[Proxy](Structural/Proxy/README.md) |	An object representing another object |

## Behavioral Design Pattern
Behavioral patterns are concerned with algorithms and the assignment of responsibilities between objects. Behavioral patterns describe not just patterns of objects or classes but also the patterns of communication between them.

|||
| -------- | ------- |
|[Chain of Responsibility](Behavioral/ChainOfResponsibility/README.md) |	A way of passing a request between a chain of objects |
|[Command](Behavioral/Command/README.md) |	Encapsulate a command request as an object |
|[Interpreter](Behavioral/Interpreter/README.md) |	A way to include language elements in a program |
|[Iterator](Behavioral/Iterator/README.md) |	Sequentially access the elements of a collection |
|[Mediator](Behavioral/Mediator/README.md) |	Defines simplified communication between classes |
|[Memento](Behavioral/Memento/README.md) |	Capture and restore an object's internal state |
|[Observer](Behavioral/Observer/README.md) |	A way of notifying change to a number of classes |
|[State](Behavioral/State/README.md) | Alter an object's behavior when its state changes |
|[Strategy](Behavioral/Strategy/README.md) |	Encapsulates an algorithm inside a class |
|[Template Method](Behavioral/TemplateMethod/README.md) |	Defer the exact steps of an algorithm to a subclass |
|[Visitor](Behavioral/Visitor/README.md) |	Defines a new operation to a class without change |