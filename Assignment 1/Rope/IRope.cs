using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Rope
{
    public interface IRope
    {
        int Length { get; }

        char Index(int i);

        IRope Concatenate(IRope r);

        IRope Split(int i);

        IRope Insert(int i, String s);

        RopeNode Root { get; }
    }
}
