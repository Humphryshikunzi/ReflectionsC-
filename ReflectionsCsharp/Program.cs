using System;
using System.Reflection;

namespace ReflectionsCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
         // Type T=Type.GetType("ReflectionsCsharp.Customer");
       //  Type T = typeof(Customer);
       Customer C1=new Customer();
       Type T = C1.GetType();
          Console.WriteLine("Full name "+T.FullName);
          Console.WriteLine("Just name "+T.Name);
          Console.WriteLine("Namespace Name "+T.Namespace);
          PropertyInfo[] properties = T.GetProperties();
          foreach (var property in  properties)
          {
              Console.WriteLine(property.PropertyType.Name+" "+ property.Name);
          }

          Console.WriteLine();
          Console.WriteLine("About methods");
          MethodInfo[] methods = T.GetMethods();
          foreach (var method in methods)
          {
              Console.WriteLine(method.ReturnType.Name+" "+method.Name);
          }

          Console.WriteLine();
          Console.WriteLine("About constructors");
          ConstructorInfo[] constructors = T.GetConstructors();
          foreach (var constructor in constructors)
          {
              Console.WriteLine(constructor.ToString());
          }

          RemindDelegate remind=new RemindDelegate();
          remind.WriteNumbers(Mymethod);
        }

        static void Mymethod(int marktime,string message)
        {
            Console.WriteLine("At {0} the message is {1} ",marktime,message);
        }
    }

    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(int id,string name)
        {
            this.Id = id;
            this.Name = name;

        }

        public Customer()
        {
            this.Id = -1;
            this.Name=String.Empty;
        }

        public void PrintId()
        {
            Console.WriteLine("Id  {0}:",this.Id);
        }
        public void PrintName()
        {
            Console.WriteLine("Name  {0}:", this.Name);
        }
    }
   
    class RemindDelegate
    {
        public delegate void MyDelegate(int i,string message);

        public string Message=" \"The value ? Its here\"";
        public void WriteNumbers(MyDelegate i)
        {
            for (int j = 0; j < 200; j++)
            {
                if (j == 100) i(j, Message);


            }
        }
    }
}
