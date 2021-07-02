using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace _2020_01_05
{
    public class _202005 : Singleton<_202005>
    {
        //父类传值给子类
        public static TChild AutoCopy<TParent, TChild>(TParent parent) where TChild : TParent
        {
            TChild child = Activator.CreateInstance<TChild>();

            System.Reflection.PropertyInfo[] propertyInfos = parent.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.CanRead && propertyInfo.CanWrite)
                {
                    propertyInfo.SetValue(child, propertyInfo.GetValue(parent, null), null);

                }
            }
            return child;
        }

        public static List<TChild> AutoListCopy<TParent, TChild>(List<TParent> parentList) where TChild : TParent, new()
        {
            return parentList.Select(AutoCopy<TParent, TChild>).ToList();
        }

        private class Person
        {
            public Person(string name)
            {
                Name = name;
            }

            public Person()
            {
            }

            public string Name { get; set; }
        }

        private class Male : Person
        {
            public Male(string name, string kill) : base(name)
            {
                Kill = kill;
            }

            public Male()
            {
            }



            public string Kill { get; set; }
            public override string ToString()
            {
                return "Name:" + Name + "***" + "Kill" + Kill;
            }
        }

        public static void Display()
        {
            List<Person> persons = new List<Person>()
            {
                new Person("小明"),
                new Person("小s")
            };
            List<Male> autoListCopy = AutoListCopy<Person, Male>(persons);
            AutoListCopy<Person, Male>(persons).ForEach(Console.WriteLine);
        }

    }
}