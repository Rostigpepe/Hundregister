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
    abstract class Doggo : IComparable
    {

        //To make the sort function work
        public int CompareTo(object obj)
        {
            Doggo doggo = obj as Doggo;

            return String.Compare(name, doggo.name);
        }

        //Declaring variables
        protected string name;
        protected bool sex; //True = Male, False = Female
        protected int age; //Years
        protected int length; //Cm
        protected int withers; //Cm
        protected double weight; //Kg
        public abstract double TailLength(); //Tail length here so that it's created together with the other stuff

        #region Getters and Setters

        public string Name
        {
            get { return name; }
            set
            {
                name = value.ToUpper();
            }
        }


        public bool Sex
        {
            get { return sex; }
            set
            {
                sex = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
            }
        }

        public int Length
        {
            get { return length; }
            set
            {
                length = value;
            }
        }

        public int Withers
        {
            get { return withers; }
            set
            {
                withers = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
            }
        }

        #endregion

        #region Constructor

        public Doggo(string aName,
            bool aSex,
            int aAge,
            int aLength,
            int aWithers,
            double aWeight)
        {

            Name = aName;
            Sex = aSex;
            Age = aAge;
            Length = aLength;
            Withers = aWithers;
            Weight = aWeight;


        }

        #endregion

        #region Print function

        public void PrintDoggo()
        {
            Console.WriteLine("\nName: " + FormatName()
                + "\nBreed: " + GetType().Name
                + "\nSex: " + (sex ? "Male" : "Female")
                + "\nAge: " + age
                + "\nLength: " + length + " Cm"
                + "\nWithers: " + withers + " Cm"
                + "\nWeight: " + weight + " Kgs"
                + "\nTail length: " + TailLength() + " Cm");
            name = name.ToUpper(); 
            /*
             * Robin:
             * Jag hade nog satt den sista raden här någon
             * annanstans, typ i konstruktorn. Känns onödigt
             * att göra det varje gång man kör print.
             */
        }

        #endregion

        #region Name format

        //Formats the name to start with an uppercase and rest be lower case
        public override string ToString()
        {
            return name;
        }


        public string FormatName()
        {
            name = name.ToLower();
            string[] names = name.Split(' ');
            string newName = "";
            foreach (string s in names)
            {
                newName += s.First().ToString().ToUpper() + s.Substring(1);
            }
            return newName;

        }
        #endregion

        #region Equality check
        /*
         * Robin:
         * Snygg Equals.
         */
        //Equality check
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Doggo doggo = (Doggo)obj;
            return (Name == doggo.Name
                && Age == doggo.Age
                && Length == doggo.Length
                && Withers == doggo.Withers
                && Weight == doggo.Weight
                && Sex == doggo.Sex) ? true : false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
