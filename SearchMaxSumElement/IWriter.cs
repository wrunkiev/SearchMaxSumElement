using System;
using System.Collections.Generic;
using System.Text;

namespace SearchMaxSumElement
{
    interface IWriter
    {
        void Write(object message);
        void WriteLine(object message);
        string ReadLine();
    }
}
