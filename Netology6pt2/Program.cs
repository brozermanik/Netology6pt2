using System;
using System.Reflection;

namespace Netology6pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cl = new TestClass();
            var type = cl.GetType();
            type = typeof(TestClass);
            
            var fields = type.GetFields();
            //8:57
            var field = type.GetField("FieldInt", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(cl, (short)12345);

            Console.WriteLine(field.GetValue(cl));
            
            var someProperties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            var someProperty = type.GetProperty("PropertyString", BindingFlags.NonPublic | BindingFlags.Instance);
            someProperty.SetValue(cl, "new");
            
            Console.WriteLine(someProperty.GetValue(cl));
        }
    }

    public class TestClass
    {
        private int FieldInt;
        protected short FieldShort;
        public long FieldLong;
        
        private char PropertyChar { get; set; }
        protected string PropertyString { get; set; }
        public DateTime PropertyDateTime { get; set; }
        
        private void SetInt(int i) {}
        protected object GetObject() => null;
        public TimeSpan GetTimeSpan() => TimeSpan.MaxValue;
    }
    

}