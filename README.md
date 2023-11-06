# DesignPatterns

## Builder 
Builder : When piecewise object construction is complicated provide an API for doing it succintly

- Some objects are simple and can be created in a single constrictor call
- Other objects require a lot of ceremony to create 
- Having an object with 10 conscructor parametres is not productive
- Insead , opt for piecewise construction
- To make builder fluent return this


## Factory
> Factory Design Pattern. A factory is class will create and deliver objects based on the incoming parameters.

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

## Singletion 

> Singletion : a component which is instantiated only once

Usage:
- For some components is only make sinse to have one in the system
 * Database repository
 * Object Factory

- A constructor call is expensive
  We only do it once
  We provide every consumer creating additional copies
- Need to take care of lazy instantiationand thread saifty

## Decorator 

Decorator : Adding behavior without altering the class isself

	• A decorator keeps the reference to decorated objects
	• May or may not proxy over calls
           Use R# Genarate Delegated Members

	• Exists in a static variation 
           X<Y<Foo>>
          Very limited to inability to inhetit from type parameters (Not recomended in c#)


## Mediator 

> Mediator : facilitates communication between others components
> withou them necessarilly being aware of each other or having direct (reference)
> access to each other

Motivation:

* components may go in and out of the system at any time
  -Eg: Chatroom
  - Players

* It makes no sens for them to have direct references to one another 
  Those references may go dead

Solution:

* have then all refer to some central components that facilatates
cmmunication

* Create the mediator and have each object in the system refer to it
Eg in a field

* Mediator engages in bidirectional communication
with its connected components

* Mediator has functions the components can call
* Components have functions the mediator can call
  Event processing (Rx) library make communication easier to implement


  ## Null Object 
> A no-op object that conforms to the required interface,
> satisfying a dependency requirement of some other object.

Motivation:

* When component A uses component B, it typically assumes
that B is non-null
   - you inject B, not B? or some Option<B>
   - You do not check for null (?.) on every call

* There is on option of telling A not to use an instance of B 
   - its use is hard-coded

* Thus , we build a no-op, non functionning inheritor of B and pass it into A
so :
*Implement the required interface
*Rewrite the methods with empty bodies
  - If method is non void, return default(T)
  - if these values are ever used, you are in trouble
* Supploy an instance of null object in place of actual object
* Dynamic construction possible
   - With associated performance implications

  ## Template Method
  
  > allows us to define the skeleton of the algorithm with concrete implementation defined in subclasses

Motivation: 
* Algorithm can be decomposed into common parts + specifics
* Strategy pattern does this throught composition
  High-level algorithm uses an interface
  Concrete implementations implement the interface
* Template method does the same thing through inheritance
  Overall algorithm makes use of abstruct member.
  Inheritors override the abstract members

so:
Define an algorithm at a gigh level

Define constituent parts as abstract methods/properties

Inherit the algorithm class, providing necessary overrides


## Bridge :

> Connecting compnents togher through abstructions

Decpiple abstruction from implementaton

Both can exist as herarcchies

A stronger from of ancapsulation


