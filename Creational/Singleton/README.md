# Singleton Design Pattern

## Definition
The singleton pattern is a software design pattern that restricts the instantiation of a class to a singular instance.

## Structure
![ScreenShot](/Assets/Images/Singleton_UML.svg)

## Real-Time Code Example
In this real-time example we are using singleton design pattern to create logger class. Only one instance of logger class is allowed in the entire program. 
[source code](Singleton.cs)

<b>A static member</b> within the class needs to be declared with same type as the class itself. This static member ensures that memory is allocated only once, preserving the single instance of the Singleton class.
```
    // Static readonly member to hold the single instance
    private static readonly Logger _loggerInstance = new Logger();
```

<b>A private constructor</b> serves as a barricade against external attempts to create instances of the Singleton class. This ensures that the class has control over its instantiation process.
```
    // Private Constructor
    private Logger()
    {
    }
```

<b>The static factory method</b> acts as a gateway, providing a global point of access to the Singleton object.
```
    // Static method for global access
    public static Logger GetInstance()
    {
        // Return the same instance
        return _loggerInstance;
    }
```

<b>Client Code:</b>
```
    var singletonLoggerInstance = Logger.GetInstance();
    
    singletonLoggerInstance.WriteLog("Writing log using Singleton Design Pattern");
```

<b>Output:</b>
```
Writing log using Singleton Design Pattern    
```
