using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingMock.Logic
{
    public class Bar
    {
        private IFoo foo;

        public Bar(IFoo foo)
        {
            this.foo = foo;
        }

        public string StringMethod(int value)
        {
            return foo.StringMethod(value);
        }

        public bool DoSomething(string value)
        {
            return foo.DoSomething(value);
        }

        public string Name => foo.Name;


    }
}
