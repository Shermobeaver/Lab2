using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_2
{
    // Methods delegate
    public delegate Complex Fv2Complex(Vector2 v2);

    // Static class full of Methods
    static class FuncV2Complex
    {
        public static Complex FuncV2Complex_1(Vector2 v2)
        {
            Random randObj = new Random();
            Complex res = new(v2.X * v2.Y * 0.00001 * (double)randObj.Next(), 2);
            return res;
        }
    }
}
