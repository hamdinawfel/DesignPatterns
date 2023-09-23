using DesignPatterns.Utils;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatterns.CharpTopics._1_Reflexion
{
    /// <summary>
    /// Reflection is the ability of inspecting an assemplie's metadata at runtime
    /// it used to find in assembly and/ or dynamically invoke methods in an assembly.
    /// Uses:
    /// 1.When we drag and drop an Button from win form the property window use refection
    /// to show all the properties of the button class.
    /// 
    /// 2. Late binding can be achevid by using reflection, you can use reflection to dynamically 
    /// create an instnce of the type, about witch we don't have any information at compile time
    /// so reflection enable code that not available at compile time
    /// 3. if we have two alternate implementation of an interface, and want 
    /// to allow client to pig one of them based on an interraction or configuration
    /// with reflection you can read the name of the class and instantiate an instance (factor pattern)
    /// 
    /// 4. Grap DisplayName value to map it inside an excell file header using refelction
    /// 5 . loukup in properties methods interfaces inside a namespace
    /// ...
    /// </summary>

    public class Customer
    {
        [DisplayName("Custom Id Field")]
        public int Id { get; set; }
        [DisplayName("Custom Name Field")]
        public string Name { get; set; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Customer()
        {
            this.Id = 0;
            this.Name = String.Empty;
        }

        public void PringId()
        {
            Console.WriteLine($"Customer id : {Id}");
        }
        public void PringName()
        {
            Console.WriteLine($"Customer Name : {Name}");
        }

    }
    public class ReflectionDemo : IExecuteDemo
    {

        public void Execute()
        {
            Type type = Type.GetType("DesignPatterns.CharpTopics._1_Reflexion.Customer");

            PropertyInfo[] propertyInfos = type.GetTypeInfo().GetProperties();

            foreach(var propertyInfo in propertyInfos)
            {

                var customAttributes = propertyInfo.CustomAttributes;
                foreach(var customAttribute in customAttributes)
                {
                    var attribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                    .Cast<DisplayNameAttribute>().Single();
                    string displayName = attribute.DisplayName;
                    Console.WriteLine(displayName);
                }
            }
        }
    }
}
