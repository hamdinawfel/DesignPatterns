﻿using DesignPatterns.CharpTopics._1_Reflexion;
using DesignPatterns.Factories;
using DesignPatterns.Utils;
using System.Collections.Generic;

var pointFactroyDemo = new PointFactroyDemo();
var trackingThemeFactoryDemo = new TrackingThemeFactoryDemo();
var hotDrinkMachineDemo = new HotDrinkMachineDemo();
var personFactoryDemo = new PersonFactoryDemo();
var creditCardDemo = new CreditCardDemo();

var demos = new List<IDisplayDemo>()
{
    pointFactroyDemo,
    trackingThemeFactoryDemo,
    hotDrinkMachineDemo,
    personFactoryDemo,
    creditCardDemo
};


//var demo = new DisplayDemo(demos);
//demo.Display();


var executebledemo = new ReflectionDemo();

var executableDemo = new ExecuteDemo(executebledemo);
executableDemo.Execute();