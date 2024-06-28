using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathExpressionEvaluator.Helper
{
    internal static class ExpressionParser
    {
        private const string MathSymbols = "+*/%^";
        public static MathExpression Parse(string input) 
        {
            input = input.Trim();
            string token = "";
            bool IntalizedLeftSide = false;// 1234+  25456
            MathExpression expr = new MathExpression();
            for (var i=0;i <input.Length;i++)
            {
                var CurrentChar=input[i];
                if (char.IsDigit(CurrentChar))
                {
                    token += CurrentChar;
                    if (i == input.Length - 1 && IntalizedLeftSide) 
                    {
                        expr.RightSideOperation = double.Parse(token);
                        break;
                    }

                }
                else if (char.IsLetter(CurrentChar))
                {
                    IntalizedLeftSide=true;
                    token += CurrentChar;

                }
                else if ((MathSymbols.Contains(CurrentChar)))
                {
                    if (!IntalizedLeftSide)
                    {
                        expr.LeftSideOperation = double.Parse(token);
                        IntalizedLeftSide = true;
                    }
                    token = "";
                    expr.Operation = InvertorOperand(CurrentChar.ToString());
                }
                else if (CurrentChar == '-' && i > 0)
                {
                    if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = MathOperation.Substraction;
                        expr.LeftSideOperation = double.Parse(token);
                        IntalizedLeftSide = true;
                        token = "";
                    }
                    else 
                        token += CurrentChar;

                }
                else if (CurrentChar == ' ')
                {
                    if (!IntalizedLeftSide)
                    {
                        expr.LeftSideOperation = double.Parse(token);
                        IntalizedLeftSide = true;
                        token = "";
                    }
                    else if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = InvertorOperand(token);
                        token = "";
                    }

                }
                else
                    token += CurrentChar;
            }
             
               
            return expr ;
        }

        private static MathOperation InvertorOperand(string operators)
        {
            switch (operators.ToLower()) 
            {
                case "+":
                    return MathOperation.Addtion;
                case "-":
                    return MathOperation.Substraction;
                case "*":
                    return MathOperation.Multplication;
                case "/":
                    return MathOperation.Division;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "tan":
                    return MathOperation.Tan;
                case "cos":
                    return MathOperation.Cos;
                default:
                    return MathOperation.None;

            
            }



        }
    }
}
