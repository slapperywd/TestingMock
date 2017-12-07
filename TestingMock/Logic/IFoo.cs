using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingMock.Logic
{
    public interface IFoo
    {
        string Name { get; set; }
        string StringMethod(int x);
        bool DoSomething(string value);
    }
}
