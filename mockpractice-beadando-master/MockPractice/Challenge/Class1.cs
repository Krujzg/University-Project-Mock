using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockPractice.Challenge
{
    public static class Class1
    {
        public static int a()
        { return 0; }
    }

    class Class2
    {
        public IWrapper Wrapper { get; }
        public Class2(IWrapper wrapper)
        {
            Wrapper = wrapper;
        }

        public int b()
        {
            var x = Wrapper.a();
            return x;
        }
    }

    interface IWrapper
    {
        int a();
    }

    //class WrapperClass : IWrapper
    //{
    //    public int a()
    //    {
    //        return Class1.a();
    //    }
    //}
}
