using DesignPatterns.CharpTopics._1_Reflexion;
using DesignPatterns.Factories;
using DesignPatterns.Prototype;
using DesignPatterns.Prototype.CopyConstrator;
using DesignPatterns.Prototype.DeepCopyInterface;
using DesignPatterns.Prototype.PrototypeInheritance;
using DesignPatterns.Singleton;
using DesignPatterns.Utils;
using NUnit.Framework;
using System.Collections.Generic;

var pointFactroyDemo = new PointFactroyDemo();
var trackingThemeFactoryDemo = new TrackingThemeFactoryDemo();
var hotDrinkMachineDemo = new HotDrinkMachineDemo();
var personFactoryDemo = new PersonFactoryDemo();
var creditCardDemo = new CreditCardDemo();

var prototypeCopyConstratorDemo = new PrototypeCopyConstratorDemo();
var prototypeWithDeepCopyInterfaceDemo = new PrototypeWithDeepCopyInterfaceDemo();
var prototypeInheritanceDemo = new PrototypeInheritanceDemo();
var prototypeExecrice = new PrototypeExecrice();

var singletionDemo = new SingletonDemo();
var singletonMonostateDemo = new SingletonMonostateDemo();
var perThreadSingletonDemo = new PerThreadSingletonDemo();
var ambientContextDemo = new AmbientContextDemo();

var demos = new List<IDisplayDemo>()
{
    pointFactroyDemo,
    trackingThemeFactoryDemo,
    hotDrinkMachineDemo,
    personFactoryDemo,
    creditCardDemo,

    prototypeCopyConstratorDemo,
    prototypeWithDeepCopyInterfaceDemo,
    prototypeInheritanceDemo,
    prototypeExecrice,

    singletionDemo,
    singletonMonostateDemo,
    perThreadSingletonDemo,
    ambientContextDemo,
};


var demo = new DisplayDemo(demos);
demo.Display();


//var executebledemo = new ReflectionDemo();

//var executableDemo = new ExecuteDemo(executebledemo);
//executableDemo.Execute();
