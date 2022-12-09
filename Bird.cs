// Bird.cs
// CPSC1500 Class
// April 2021
// Purpose: this is a class for the bird object.

using System;
namespace Project_3_CPSC_1500
{
    public class Bird
    {
        //-------Data Members-------//
        private bool hasBird;           // This is a boolean that keeps track of if user has the bird.
                                        

        //-------Constructor-------//
        public Bird()
        {
            hasBird = false; // the user does not have the bird to start.
        }

        //------- Getters and Setters (We only want getters in this game.) -------//
        public bool HasBird
        {
            get { return hasBird; }
            set { hasBird = value; }
        }


        //------- Other Methods -------//

        public void GetBird()
        {
            hasBird = true;
        }
       
    }
}

