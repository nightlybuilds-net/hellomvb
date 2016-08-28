using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloMvb.ModelBinders;

namespace HelloMvb.App.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Mvb.Core.Mvb.NullInit();
            var binder = new HelloWorldModelBinder();

            binder.Binder.AddAction<HelloWorldModelBinder>(b => b.OutPut, () =>
            {
                System.Console.WriteLine(binder.OutPut);
            });

            System.Console.WriteLine("Welcome to HelloMvb Console Example");
            System.Console.WriteLine("Insert your name and press enter");
            var name = System.Console.ReadLine();
            binder.SayHelloto(name);
            System.Console.ReadLine();
        }
    }
}
