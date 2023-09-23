# DesignPatterns

## Factory Design Pattern: TO update

> https://dotnettutorials.net/lesson/factory-design-pattern-csharp/#google_vignette

A factory is an object used for creating other objects,
Factory is a class with a method. That method will create and return different objects based on the received input parameter.

if we have a superclass and n number of subclasses, and based on the data provided, if we have to create and return the object of one of the subclasses, then we need to use the Factory Design Pattern in

Factory Design Pattern. A factory is class will create and deliver  objects based on the incoming parameters.

## Prototype 

> Prototype : A partially or fully initialized object that you copy (clone) and make use of

When it's easier to copy an existing object to fully initialize a new one
usage :

* Complicted objects aren't designed from scratch

* An existing (partially or fully) constructed design is a prototype
* We make a copy (clone) the prototype and customize it require deep copy support
* We make the cloning convenient ( via Factory)

To implement a prototype partially construct an object and store it somewhere
Clone the prototype
Implement your own deep copy functionality ; or
Serialize and deserialize
Customize the resulting instance
