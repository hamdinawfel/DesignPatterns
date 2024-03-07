using DesignPatterns.Bridge;
using DesignPatterns.Builder;
using DesignPatterns.CharpTopics._1_Reflexion;
using DesignPatterns.CharpTopics._2_BaseKeyword;
using DesignPatterns.CharpTopics._3_Event;
using DesignPatterns.CharpTopics._4_ConversionOperator;
using DesignPatterns.CharpTopics._5_DefaultInterfaceMembers;
using DesignPatterns.CharpTopics._6_ParallelProgramming;
using DesignPatterns.CharpTopics.AdvancedTopics.InParameters;
using DesignPatterns.CharpTopics.InterviewQuestions;
using DesignPatterns.CharpTopics.Performance;
using DesignPatterns.Composite;
using DesignPatterns.Decorator;
using DesignPatterns.Decorator.Exercice;
using DesignPatterns.Decorator.MultipleDecoratorResolver;
using DesignPatterns.Decorator.StaticDecorator;
using DesignPatterns.Factories;
using DesignPatterns.InterviewQuestions;
using DesignPatterns.Mediator;
using DesignPatterns.NullObject;
using DesignPatterns.Prototype;
using DesignPatterns.Prototype.CopyConstrator;
using DesignPatterns.Prototype.DeepCopyInterface;
using DesignPatterns.Prototype.PrototypeInheritance;
using DesignPatterns.Singleton;
using DesignPatterns.TemplateMethod;
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

var mediatRDemo = new MediatRDemo();
var mediatorCodingExercise = new MediatorCodingExercise();
var nullObjectDemo = new NullObjectDemo();
var nullObjectCodingExercise = new NullObjectCodingExercise();

var templateMethodDemo = new TemplateMethodDemo();
var functionalTemplateMethodDemo = new FunctionalTemplateMethodDemo();
var templateMethodExercice = new TemplateMethodExercice();

var bridgeDemo = new BridgeDemo();
var bridgeExcerice = new BridgeExcerice();

var geometricShapes = new GeometricShapes();
var neuralNetworks = new NeuralNetworks();



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

    myStringBuilderDemo,
    multipleInheritanceDemo,
    multipleInheritanceWithDefaultInterfaceMemberDemo,
    dynamicDecoratorCompositionDemo,
    staticDecoratorCompositionDemo,
    decoratorInDIDemo,
    decoratorCodingExercice,

    builderDemo,
    fluentBuilderInheritanceWithRecusrsiveGenericsDemo,
    stepWiseBuilderDemo,
    builderCodingExercise,

    mediatRDemo,
    mediatorCodingExercise,

    nullObjectDemo,
    nullObjectCodingExercise,

    templateMethodDemo,
    functionalTemplateMethodDemo,
    templateMethodExercice,

    bridgeDemo,
    bridgeExcerice,

    geometricShapes,
    neuralNetworks,
};


//var demo = new DisplayDemo(demos);
//demo.Display();


//var executebledemo = new ReflectionDemo();
//var executebledemo = new BaseKeywordDemo();
//var executebledemo = new EventDemo(); //TODO
//var executebledemo = new ConversionOperatorDemo();
//var executebledemo = new Demo();
//var executebledemo = new RecusriveDemo();
//var executebledemo = new ReverseString();
//var executebledemo = new ArrayWithDeffirentTypes();
//var executebledemo = new GenericListWithDifferentListTypes();
//var executebledemo = new JaggedArray();
//var executebledemo = new ExceptionDemo();
//var executebledemo = new AbtructClassAndVirtuelMethodDemo();
//var executebledemo = new FindSumPairDemo();
//var executebledemo = new LocateUniverseFormilaDemo(); //TODO
//var executebledemo = new InParametresDemo();
//var executebledemo = new PreventBoxingAndUnbosing();

// ---------------- Performance DEMOS ----------------//
//var executebledemo = new ReplaceDigits();
//var executebledemo = new MatrixMultiplication();

// ---------------- Parallel Programming DEMOS ----------------//
//var executebledemo = new CreateAndStartTasks();
//var executebledemo = new CancelTask();
var executebledemo = new WaitingTask();

var executableDemo = new ExecuteDemo(executebledemo);
executableDemo.Execute();
