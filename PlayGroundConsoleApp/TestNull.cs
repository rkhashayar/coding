using System;
using System.Collections.Generic;
using System.Text;

namespace PlayGroundConsoleApp
{
    class MyTestClass
    {
        public string TestString { get; set; }
    }
    public class TestNull
    {
        public static string SingleNullCheckWithBool()
        {
            MyTestClass testItem = new MyTestClass();
            bool boolTest = testItem?.TestString?.Length > 0;
            return $"this is the boolian value to bested for nullable object =====> {boolTest}";   
        }
    }
}
