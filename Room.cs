// Room.cs
// CPSC1500 Class
// April 2021
// Purpose: this is a room class.

using System;

namespace Project_3_CPSC_1500
{
    public class Room
    {
        //-------Data Members-------//
        private const int noDoor = -1;  // We use a negative number for no door that direction since we will use an array with index of 0+ for all rooms.
        private string name;            // the name of the room
        private string description;     // the description of the room
        private int nDoor;              // an integer to say which index in the array for room the north door takes you to.
        private int sDoor;              // an integer to say which index in the array for room the south door takes you to.
        private int eDoor;              // an integer to say which index in the array for room the east door takes you to.
        private int wDoor;              // an integer to say which index in the array for room the west door takes you to.
        private bool firstVisit;        // This is a boolean that keeps track on if it's the first visit to a room.
                                        // if true, print out long description of room
                                        // if false, do not print out long description or room
        private bool rodHere;           // Boolean to keep track of if a rod is in the room.
        private bool birdHere;
        private bool canGetBirdHere;


        //-------Constructor-------//
        public Room(string newName, string newDescription, int newNDoor, int newSDoor, int newEDoor, int newWDoor)
        {
            name = newName;                 // Set the name of the room to the newName parameter.
            description = newDescription;   // Set the room description to the newDescription parameter.
            nDoor = newNDoor;               // Set the north door integer to the newNDoor parameter
            sDoor = newSDoor;               // Set the south door integer to the newSDoor parameter
            eDoor = newEDoor;               // Set the east door integer to the newEDoor parameter
            wDoor = newWDoor;               // Set the west door integer to the newWDoor parameter
            firstVisit = true;              // initalize the firstVisit boolean to true.
            rodHere = false;
            birdHere = false;
            canGetBirdHere = false;
        }

        //------- Getters and Setters (We only want getters in this game.) -------//
        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public int NDoor
        {
            get { return nDoor; }
        }

        public int SDoor
        {
            get { return sDoor; }
        }

        public int EDoor
        {
            get { return eDoor; }
        }

        public int WDoor
        {
            get { return wDoor; }
        }

        public bool FirstVisit
        {
            get { return firstVisit; }
            set { firstVisit = value; }
        }

        public bool RodHere
        {
            get { return rodHere; }
            set { rodHere = value; }
        }

        public bool BirdHere
        {
            get { return birdHere; }
            set { birdHere = value; }
        }

        public bool CanGetBirdHere
        {
            get { return canGetBirdHere; }
            set { canGetBirdHere = value; }
        }

        //------- Other Methods -------//
        // Method to go North.
        public int GoNorth()
        {
            return nDoor;
        }

        // Method to go south.
        public int GoSouth()
        {
            return sDoor;
        }

        // method to go east.
        public int GoEast()
        {
            return eDoor;
        }

        // method to go west.
        public int GoWest()
        {
            return wDoor;
        }

    } // end Public Class Room
} // end Namespace
