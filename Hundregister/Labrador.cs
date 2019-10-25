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
    class Labrador : Doggo
    {

        public Labrador(string name,
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
            if (sex == true)
            {
                return length + 2 - withers;
            }
            else
            {
                return length - withers;
            }
        }

    }
}
