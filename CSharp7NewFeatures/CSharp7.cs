using System;

namespace CSharpVersionsFeatures
{
    public class CSharp7
    {
        public static void MoreReadableFeatures() {
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
    }
}
