using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPrograms
{
    public class Vehicle
    {
        //base class vehicle --> has one method run as virtual.
        public virtual void run()
        {
            Console.WriteLine("Vehicle is running.");
        }
    }

    public class Bike : Vehicle
    {
        //derive class bike overrides the defination of run method from base class.
        public override void run()
        {
            //base.run();//this will run base class code.
            Console.WriteLine("Bike is runing");
        }
    }

    public class Car: Vehicle
    {
        //derive class Car creates a new defination of run method of base class.
        public new void run()
        {
            Console.WriteLine("Car is running");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle vObj = new Vehicle();
            vObj.run();//calling base class run method.

            Bike bObj = new Bike();
            bObj.run();//calling derive class Bike's run method.

            var v1Obj = (Vehicle)bObj;//casting bike obj to base vehicle obj.
            v1Obj.run();//calling base run method again but output is overridden.

            Car cobj = new Car();
            cobj.run();//calling derive class Car' run method..

            var v2obj = (Vehicle)cobj;//casting car obj to base obj.
            v2obj.run();//calling base run method. result in actual base run method output.
        }
    }
}
