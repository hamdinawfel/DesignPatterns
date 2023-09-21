using DesignPatterns.Factories;
using DesignPatterns.Utils;
using static DesignPatterns.Factories.HotDrinkMachine;

var pointFactroyDemo = new PointFactroyDemo();
var trackingThemeFactoryDemo = new TrackingThemeFactoryDemo();
var hotDrinkMachineDemo = new HotDrinkMachineDemo();

var demos = new List<IDemo>()
{
    pointFactroyDemo,
    trackingThemeFactoryDemo,
    hotDrinkMachineDemo
};


var demo = new Demo(demos);
demo.Display();



