using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    /// <summary>
    /// An interface representing a Random Number Generator
    /// </summary>
    public interface IRandomProvider
    {
        int Next(int maxValue);
    }
}
