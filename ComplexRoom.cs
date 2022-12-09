// ComplexRoom.cs
// CPSC1500 Class
// April 2021
// Purpose: to create a class for a more complex room (with in, out, up, down)

using System;

namespace Project_3_CPSC_1500
{
    public class ComplexRoom : Room
    {
        //-------Data Members-------//
        private int inDoor;     // an integer to say which index in the array for room "in" takes you to.
        private int outDoor;    // an integer to say which index in the array for room "out" takes you to.
        private int upDoor;     // an integer to say which index in the array for room "up" takes you to.
        private int downDoor;   // an integer to say which index in the array for room "down" takes you to.

        //-------Constructor-------//

        public ComplexRoom(string name, string description,
            int nDoor, int sDoor, int eDoor, int wDoor,
            int newInDoor, int newOutDoor, int newUpDoor, int newDownDoor)
            : base(name, description, nDoor, sDoor, eDoor, wDoor)
        {
            inDoor = newInDoor;
            outDoor = newOutDoor;
            upDoor = newUpDoor;
            downDoor =  newDownDoor;
        }


        //------- Getters and Setters (We only want getters in this game.) -------//

        public int InDoor
        {
            get { return inDoor; }
        }

        public int OutDoor
        {
            get { return outDoor; }
        }

        public int UpDoor
        {
            get { return upDoor; }
        }

        public int DownDoor
        {
            get { return downDoor; }
        }

        //------- Other Methods -------//
        // Method to go up.
        public int GoUp()
        {
            return upDoor;
        }

        // Method to go down.
        public int GoDown()
        {
            return downDoor;
        }

        // Method to go in.
        public int GoIn()
        {
            return inDoor;
        }

        // Method to go out.
        public int GoOut()
        {
            return outDoor;
        }
    }
}
