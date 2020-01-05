using System;

namespace Utils
{
    public  class Singleton<T> where T:class, new() 
    {
        public static T t;

        public static T Instance
        {
            get {
                if (t == null)
                {
                    t = new T();
                }

                return t;
            }
          
        }
      
    }
}
