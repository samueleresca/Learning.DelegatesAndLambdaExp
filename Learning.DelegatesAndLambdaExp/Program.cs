using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Learning.DelegatesAndLambdaExp
{
    class Program
    {
        private delegate string GetAString();
        delegate double DoubleOp(double x);

        static void Main()
        {
            int x = 40;
            GetAString firstStringMethod = new GetAString(x.ToString);
            Console.WriteLine("String is {0}", firstStringMethod());
            //With firstStringMethod initialized to x.ToString
            //the above steatment is equavilent to say:
            //Console.WriteLine("String is {0}", x.ToString());

            Currency balance = new Currency(34, 50);
            
            //firstStringMethod references an instance method
            firstStringMethod = balance.ToString;
            Console.WriteLine("String is {0}", firstStringMethod());

            //firstStringMethod references a static method
            firstStringMethod = new GetAString(Currency.GetCurrencyUnit);
            Console.WriteLine("String is {0}", firstStringMethod());

            /*______________________________________________________________*/
            //You can use delegates as an array
            DoubleOp[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };

            for (int i = 0; i < operations.Length; i++) {
                Console.WriteLine("Using operations[{0}]:", i);
                ProcessAndDisplayNumber(operations[i], 2.0);
                ProcessAndDisplayNumber(operations[i], 7.94);
                ProcessAndDisplayNumber(operations[i], 1.414);
                Console.WriteLine();
            }
            
            /*______________________________________________________________*/

            Employee[] employees = 
            {
                new Employee("Bugs Bunny", 20000),
                new Employee("Elmer Fudd", 10000),
                new Employee("Daffy Duck", 25000),
                new Employee("Willie Coyote", 10000.38m)
            };

            BubbleSorter.Sort<Employee>(employees, Employee.CompareSalary);
            foreach (var employee in employees) Console.WriteLine(employee);
            
            Console.ReadLine();
        }

        static void ProcessAndDisplayNumber(DoubleOp action, double value) {
            double result = action(value);
            Console.WriteLine("Value is {0}, result of operation is {1}", value, result);

        }
    }
}
