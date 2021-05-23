using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class BoolViewModel
    {
        public static BoolViewModel FromResult(bool v) => new CorrectResultViewModel() { Value = v };
        public static BoolViewModel FromError(String s) => new ErrorResultViewModel() { Error = s };
        public sealed class CorrectResultViewModel : BoolViewModel
        {
            public bool Value { get; internal set; }
            public override string ToString()
            {
                if (Value)
                    return "True";
                else
                    return "False";
            }
        }
        public sealed class ErrorResultViewModel : BoolViewModel
        {
            public string Error { get; internal set; }
            public override string ToString()
            {
                return Error;
            }
        }
    }
}
