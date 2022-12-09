// Rod.cs
// CPSC1500 Class
// April 2021
// Purpose: this is a class for the rod object.

using System;
namespace Project_3_CPSC_1500
{
    public class Rod
    {
        //-------Data Members-------//
        private bool hasRod;           // This is a boolean that keeps track of if user has the bird.


        //-------Constructor-------//
        public Rod()
        {
            hasRod = false; // the user does not have the rod to start.
        }

        //------- Getters and Setters (We only want getters in this game.) -------//
        public bool HasRod
        {
            get { return hasRod; }
            set { hasRod = value; }
        }

        //------- Other Methods -------//


    }
}

