using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class AvgViewModel
    {
        public static AvgViewModel FromResult(double v) => new CorrectResultViewModel() { Value = v };
        public static AvgViewModel FromError(String s) => new ErrorResultViewModel() { Error = s };
        public sealed class CorrectResultViewModel : AvgViewModel
        {
            public double Value { get; internal set; }
            public override string ToString()
            {
                return $"Avg: {Value};";
            }
        }
        public sealed class ErrorResultViewModel : AvgViewModel
        {
            public string Error { get; internal set; }
            public override string ToString()
            {
                return $"Avg error: {Error};";
            }
        }
    }
}
