using System;
using System.Collections.Generic;
using System.Text;

namespace Bim494_Hw1
{
    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
}
