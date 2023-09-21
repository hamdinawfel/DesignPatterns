using DesignPatterns.Factories;
using DesignPatterns.Utils;

var factoroyDemo = new FactoryDemo();
var trackingThemeFactoryDemo = new TrackingThemeFactoryDemo();

var demos = new List<IDemo>()
{
	factoroyDemo,
    trackingThemeFactoryDemo,
};


var demo = new Demo(demos);
demo.Display();



