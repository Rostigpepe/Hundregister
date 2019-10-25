/*
 Author: Robin Stenskytt
 Course: PRRPRR02
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundregister
{
    class Weinerdog : Doggo
    {
        public Weinerdog(string name,
            bool sex,
            int age,
            int length,
            int withers,
            double weight)
            :
            base(name,
                sex,
                age,
                length,
                withers,
                weight)
        { }

        //Math to decide what length the tail is
        public override double TailLength()
        {
            return length / 4;
        }
    }
}
