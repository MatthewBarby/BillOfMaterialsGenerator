using BillOfMaterialsGenerator.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Reflection;

namespace BillOfMaterialsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                .InNamespace("BillOfMaterialsGenerator")
                .WithServiceAllInterfaces());

            container.Register(
                Classes.FromAssemblyNamed("Utilities")
                .InNamespace("Utilities")
                .WithServiceAllInterfaces());

            var billOfMaterialsGenertor = container.Resolve<IBillOfMaterialsGenerator>();
            billOfMaterialsGenertor.ProccessNextBill();
        }
    }
}
