using DesignPatterns.Builder;
using DesignPatterns.CharpTopics._1_Reflexion;
using DesignPatterns.CharpTopics._2_BaseKeyword;
using DesignPatterns.CharpTopics._3_Event;
using DesignPatterns.CharpTopics._4_ConversionOperator;
using DesignPatterns.CharpTopics._5_DefaultInterfaceMembers;
using DesignPatterns.Decorator;
using DesignPatterns.Decorator.Exercice;
using DesignPatterns.Decorator.MultipleDecoratorResolver;
using DesignPatterns.Decorator.StaticDecorator;
using DesignPatterns.Factories;
using DesignPatterns.InterviewQuestions;
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

var myStringBuilderDemo = new MyStringBuilderDemo();
var multipleInheritanceDemo = new MultipleInheritanceDemo();
var multipleInheritanceWithDefaultInterfaceMemberDemo = new MultipleInheritanceWithDefaultInterfaceMemberDemo();
var dynamicDecoratorCompositionDemo = new DetectingDecoratorCyclesDemo();
var staticDecoratorCompositionDemo = new StaticDecoratorCompositionDemo();
var decoratorInDIDemo = new DecoratorInDIDemo();
var decoratorCodingExercice = new DecoratorCodingExercice();

var builderDemo = new BuilderDemo();
var fluentBuilderInheritanceWithRecusrsiveGenericsDemo = new FluentBuilderInheritanceWithRecusrsiveGenericsDemo();
var stepWiseBuilderDemo = new StepWiseBuilderDemo();
var builderCodingExercise = new BuilderCodingExercise();



var demos = new List<IDisplayDemo>()
{
    //pointFactroyDemo,
    //trackingThemeFactoryDemo,
    //hotDrinkMachineDemo,
    //personFactoryDemo,
    //creditCardDemo,

    //prototypeCopyConstratorDemo,
    //prototypeWithDeepCopyInterfaceDemo,
    //prototypeInheritanceDemo,
    //prototypeExecrice,

    //singletionDemo,
    //singletonMonostateDemo,
    //perThreadSingletonDemo,
    //ambientContextDemo,

    //myStringBuilderDemo,
    //multipleInheritanceDemo,
    //multipleInheritanceWithDefaultInterfaceMemberDemo,
    //dynamicDecoratorCompositionDemo,
    //staticDecoratorCompositionDemo,
    //decoratorInDIDemo,
    //decoratorCodingExercice,

    builderDemo,
    fluentBuilderInheritanceWithRecusrsiveGenericsDemo,
    stepWiseBuilderDemo,
    builderCodingExercise
};


var demo = new DisplayDemo(demos);
demo.Display();


//var executebledemo = new ReflectionDemo();
//var executebledemo = new BaseKeywordDemo();
//var executebledemo = new EventDemo();
//var executebledemo = new ConversionOperatorDemo();
//var executebledemo = new Demo();
var executebledemo = new RecusriveDemo();

//var executableDemo = new ExecuteDemo(executebledemo);
//executableDemo.Execute();
