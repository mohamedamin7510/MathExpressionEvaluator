using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionEvaluator.Helper;

 internal static class App
{
    public static void Run(string[] args )
    {
        while (true) 
        {
            Console.WriteLine("Please Enter Your Expression: ");
            var input = Console.ReadLine();
            var result = ExpressionParser.Parse(input);

            Console.WriteLine($"LeftSide = {result.LeftSideOperation}   ,, Operation = {result.Operation}" +
                $"  ,, RightSide = {result.RightSideOperation}");

            Console.WriteLine($"{input} = {compilling(result)}");

        }

    }

    private static object compilling(MathExpression result)
    {
        if (result.Operation == MathOperation.Addtion)
            return (result.LeftSideOperation + result.RightSideOperation);

        else if (result.Operation == MathOperation.Substraction)
            return (result.LeftSideOperation - result.RightSideOperation);

        else if (result.Operation == MathOperation.Multplication)
            return (result.LeftSideOperation * result.RightSideOperation);

        else if (result.Operation == MathOperation.Division)
            return result.LeftSideOperation / result.RightSideOperation;

        else if (result.Operation == MathOperation.Modulus)
            return result.LeftSideOperation % result.RightSideOperation;

        else if (result.Operation == MathOperation.Power)
            return Math.Pow(result.LeftSideOperation, result.RightSideOperation);

        else if (result.Operation == MathOperation.Sin)
            return Math.Sin(result.RightSideOperation);

        else if (result.Operation == MathOperation.Cos)
            return Math.Cos(result.RightSideOperation);

        else if (result.Operation == MathOperation.Tan)
            return Math.Tan(result.RightSideOperation);
        else
            return 0;
    }
}
