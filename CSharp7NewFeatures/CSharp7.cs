using System;

namespace CSharpVersionsFeatures
{
    public class CSharp7
    {
        public static void MoreReadableFeatures()
        {
            // usage of _ to make it more readable for numerics 
            int moreReadableNumber = 1_000_00;
            // can use 0b for binary values
            var moreReadableBinary = 0b1001_011010;
            var x = moreReadableBinary * moreReadableNumber;
        }
        #region changes to out keyword
        public static void WorkWithOptionalOutParams(out int a, out int b)
        {
            a = 10;
            b = 15;
        }

        public static void CallOptionalOutParamsFunction()
        {
            var x = 10;
            WorkWithOptionalOutParams(out _, out x);
            Console.WriteLine(x);
        }

        // defining the variable on the same line as where out is used
        public static void FunctionUsingOutVariableInLineWithVariableDeclaration()
        {
            string integerAsString = "12";
            bool isInteger = int.TryParse(integerAsString, out int integerAsInteger);
            if (isInteger)
            {
                Console.WriteLine(integerAsInteger * 10);
            }
        }
        #endregion

        #region using switch case
        public static void TestSwitchCase()
        {
            object[] arrayOfObjects = new object[] { 1, "string1", 1.01d, new { Name = "my name" } };
            foreach (var obj in arrayOfObjects)
            {
                Console.WriteLine(obj.GetType());
                switch (obj)
                {
                    case int a when a == 1:
                        Console.WriteLine($"my value is {obj}");
                        break;
                    case string a when a == "string1":
                        Console.WriteLine($"my value is {obj}");
                        break;
                    case double a when a == 1.01d:
                        Console.WriteLine($"my value is {obj}");
                        break;
                    default:
                        Console.WriteLine("type unknown");
                        break;
                }
            }

        }
        #endregion

        #region using gagged array
        public static void TestGaggedArray()
        {
            int[][] gaggedArray = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                gaggedArray[i] = new int[i % 5];
            }

            for (int i = 0; i < gaggedArray.Length; i++)
            {
                for (int j = 0; j < (gaggedArray[i].Length); j++)
                {
                    gaggedArray[i][j] = j;
                }
            }

            for (int i = 0; i < gaggedArray.Length; i++)
            {
                for (int j = 0; j < (gaggedArray[i].Length); j++)
                {
                    Console.Write($"{gaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
