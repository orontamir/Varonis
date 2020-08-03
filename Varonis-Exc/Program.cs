using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Varonic.Utilities;

namespace Varonis_Exc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert Type from where to run");
            var type = Console.ReadLine();
            Console.WriteLine("Insert ID");
            var id = Console.ReadLine();
            try
            {
                if (type != null)
                {
                    var classType = Type.GetType("Varonis_Exc." + type);
                    if (classType != null)
                    {
                        var constructor = classType.GetConstructor(Type.EmptyTypes);
                        if (constructor != null)
                        {
                            var classObject = constructor.Invoke(new object[] { });
                            var method = classType.GetMethod("Action");
                            if (method != null)
                            {
                                var value = method.Invoke(classObject, new object[] { id });
                                Console.WriteLine(value);
                            }
                        }
                        else
                        {
                            Console.Write("Constractor not exist");
                        }
                    }
                    else
                    {
                        Console.Write("Class Type not exist");
                    }
                }
                else
                {
                    Console.WriteLine("Type not exist");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           
          




        }
    }
}
