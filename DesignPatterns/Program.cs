using DesignPatterns.Factories;
using DesignPatterns.Utils;

var pointFactroyDemo = new PointFactroyDemo();
var trackingThemeFactoryDemo = new TrackingThemeFactoryDemo();
var hotDrinkMachineDemo = new HotDrinkMachineDemo();
var personFactoryDemo = new PersonFactoryDemo();
var creditCardDemo = new CreditCardDemo();

var demos = new List<IDemo>()
{
    pointFactroyDemo,
    trackingThemeFactoryDemo,
    hotDrinkMachineDemo,
    personFactoryDemo,
    creditCardDemo
};


var demo = new Demo(demos);
demo.Display();



