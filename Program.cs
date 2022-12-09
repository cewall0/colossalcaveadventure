// Program.cs
// CPSC1500 Class
// April 2021
// Purpose: to similate the game "Colossal Cave Adventure".

using System;

namespace Project_3_CPSC_1500
{
    class Program
    {

        // This function instantiates the rooms and puts them into an array called roomList
        static Room[] MakeRooms()
        {
            int numRooms = 12;
            Room[] roomList = new Room[numRooms]; // Set up an array to hold our rooms
            // instantiate (build) each room into its roomList array location.
            // The room uses the paramaterized Room constructor passing in the parameters
            // (name, description, N, S, E, W)
            // Complex room has parameters (name, description, N, S, E, W, in, out, up, down)

            roomList[0] = new ComplexRoom("end of road", "You are standing at the end of a road before a small brick building. \nAround you is a forest. \nA small stream flows out of the building and down a gully.", -1, 1, -1, -1, 11, -1, -1, -1); // end of road
            roomList[1] = new Room("valley", "You are in a valley in the forest beside a stream tumbling along a rocky bed.", 0, 2, -1, -1);   // valley
            roomList[2] = new Room("slit in streambed", "At your feet all the water of the stream splashes into a 2-inch slit in the rock. \nDownstream the streambed is bare rock.", 1, 3, -1, -1); // slit in streambed
            roomList[3] = new ComplexRoom("outside grate", "You are in a 20-foot depression floored with bare dirt. Set into the dirt is a strong steel grate mounted in concrete. \nA dry streambed leads into the depression. The grate is locked. \nIF THIS GAME HAD ITEMS, YOU WOULD USE A KEY TO UNLOCK THE GRATE. \nThe grate is unlocked.", 2, -1, -1, -1, -1, -1, -1, 4);
            roomList[4] = new ComplexRoom("cobble crawl", "You are in a small chamber beneath a 3x3 steel grate to the surface. A low crawl over cobbles leads inward to the west. The grate is open.", -1, -1, -1, 5, -1, -1, 3, -1);
            roomList[5] = new Room("debris room", "It is now pitch dark. If you proceed you will likely fall into a pit. \nIF THIS GAME HAD ITEMS, YOU WOULD USE THE LAMP YOU PICKED UP IN THE BUILDING \nYour lamp is now on. You are in a debris room filled with stuff washed in from the surface. A low wide passage with cobbles becomes plugged \nwith mud and debris here, but an awkward canyon leads upward and west. A note on the wall says \"Magic word XYZZY\". A three foot black rod \nwith a rusty star on an end lies nearby.", -1, -1, 4, 6);
            roomList[5].RodHere = true; // The debris room has a rod to start out.
            roomList[6] = new Room("awkward sloping E/W canyon", "You are in an awkward sloping east/west canyon.", -1, -1, 5, 7);
            roomList[7] = new Room("bird chamber", "You are in a splendid chamber thirty feet high. The walls are frozen rivers of orange stone. An awkward canyon and a good passage exit from east and west sides of the \nchamber. A cheerful little bird is sitting here singing.\nThe bird is scared by the rod. You must drop the rod in order to get the bird. Otherwise, the bird will fly away.", -1, -1, 6, 8);
            roomList[7].BirdHere = true; // There is a bird in the bird chamber to start.
            roomList[8] = new ComplexRoom("top of small pit", "At your feet is a small pit breathing traces of white mist. An east passage ends here except for a small crack leading on. Rough stone steps lead down the pit.", -1, -1, 7, -1, -1, -1, -1, 9);
            roomList[9] = new ComplexRoom("hall of mists", "You are at one end of a vast hall stretching forward out of sight to the west. There are openings to either side. \nNearby, a wide stone staircase leads downward. The hall is filled with wisps of white mist swaying to and fro almost as if alive. \nA cold wind blows up the staircase. There is a passage at the top of a dome behind you. \nRough stone steps lead up the dome.", -1, 10, -1, -1, -1, -1, 8, -1);
            roomList[10] = new Room("nugget of gold room", "This is a low room with a crude note on the wall. The note says, \"You will not get it up the steps\". \nThere is a large sparkling nugget of gold here!\nYou will not be able to take the gold up the stairs in the dome. There is another way out of the cave, which you will see later.", 9, -1, -1, 11);
            roomList[11] = new ComplexRoom("building", "You are inside a building, a well house for a large spring. There are some keys on the ground here. There is a shiny brass lamp nearby. There is food here. There is a bottle of water here.", -1, -1, -1, -1, -1, 0, -1, -1);
            return roomList;
        }

        static void MakeObjects()
        {
            Rod rod = new Rod();
            Bird bird = new Bird();
        }

        // This function welcomes the user.
        static void WelcomeText()
        {
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("\tWelcome to Colossal Cave Adventure.");
            Console.WriteLine("\tOptions are: north, south, east, west, up, down, in, out, quit, look.");
            Console.WriteLine("\tFirst letters also suffice: n, s, e, w, u, d, i, o, q, l.");
            Console.WriteLine("\tYou can also use commands like: get(object) and drop(object).");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("");
        }

        // This function gets input from the user.
        static string GetInput()
        {
            string input = "";          // initialize the input string.
            Console.Write("Input--> "); // ask for input
            input = Console.ReadLine(); // get input
            return input;               // return the input to Main
        }

        // This funciton checks if it is the first visit to this room.
        static void CheckFirstVisit(Room[] roomList, int currentRoom)
        {
            if (roomList[currentRoom].FirstVisit == true)
            {
                // Print room description.
                Console.WriteLine(roomList[currentRoom].Description);
            }
            else
            {
                // Print current room location.
                Console.WriteLine("You are at " + roomList[currentRoom].Name + " again.");
            }
        }


        static void Main(string[] args)
        {
            // Initialize some variables
            int numRooms = 12;       // The number of  rooms in the game.
            string input = "";      // initialize the input string
            int currentRoom = 0;    // initialize the current room to index 0.
            Room[] roomList = new Room[numRooms]; // Set up an array to hold our rooms

            // Instantiate all of the rooms for the game.
            roomList = MakeRooms();

            // Instantiate all of the game object.
            Bird bird = new Bird();
            Rod rod = new Rod();

            // Welcome to the game.
            WelcomeText();

            // We need to keep running the program until they enter 'quit'
            while (input != "quit" && input != "q")
            {
                // Call the function to deal with if it is a vist visit or not - to print
                // out the description of the room or not.
                CheckFirstVisit(roomList, currentRoom);

                // Set the current room FirstTimeVisit to false since we've been to this room before.
                roomList[currentRoom].FirstVisit = false;

                // Get input and make sure it is valid to continue.
                input = GetInput();

                // Deal with the input.
                if (input == "quit" || input == "q")
                {
                    Console.WriteLine("Thank you for playing this game.");
                    return;
                }
                else if (input == "look" || input == "l")
                {
                    Console.WriteLine(roomList[currentRoom].Description);
                }
                else if (input == "xyzzy")
                {
                    if (currentRoom == 5)  // if in the debris room
                    {
                        currentRoom = 11;  // make current room the building
                    }
                }
                else if (input == "north" || input == "n")
                {
                    if (roomList[currentRoom].NDoor == -1)
                    {
                        Console.WriteLine("You cannot move that direction.");
                    }
                    else
                    {
                        currentRoom = roomList[currentRoom].GoNorth();
                    }
                }
                else if (input == "south" || input == "s")
                {
                    if (roomList[currentRoom].SDoor == -1)
                    {
                        Console.WriteLine("You cannot move that direction.");
                    }
                    else
                    {
                        currentRoom = roomList[currentRoom].GoSouth();
                    }
                }
                else if (input == "east" || input == "e")
                {
                    if (roomList[currentRoom].EDoor == -1)
                    {
                        Console.WriteLine("You cannot move that direction.");
                    }
                    else
                    {
                        currentRoom = roomList[currentRoom].GoEast();
                    }
                }
                else if (input == "west" || input == "w")
                {
                    if (roomList[currentRoom].WDoor == -1)
                    {
                        Console.WriteLine("You cannot move that direction.");
                    }
                    else
                    {
                        currentRoom = roomList[currentRoom].GoWest();
                    }
                }
                else if (input == "up" || input == "u")
                {
                    if (roomList[currentRoom].GetType() == typeof(ComplexRoom))
                    {
                        if (((ComplexRoom)roomList[currentRoom]).UpDoor == -1)
                        {
                            Console.WriteLine("You cannot move that direction.");
                        }
                        else
                        {
                            currentRoom = ((ComplexRoom)roomList[currentRoom]).GoUp();
                        }
                    }
                }
                else if (input == "down" || input == "d")
                {
                    if (roomList[currentRoom].GetType() == typeof(ComplexRoom))
                    {
                        if (((ComplexRoom)roomList[currentRoom]).DownDoor == -1)
                        {
                            Console.WriteLine("You cannot move that direction.");
                        }
                        else
                        {
                            currentRoom = ((ComplexRoom)roomList[currentRoom]).GoDown();
                        }
                    }
                }
                else if (input == "in" || input == "i")
                {
                    if (roomList[currentRoom].GetType() == typeof(ComplexRoom))
                    {
                        if (((ComplexRoom)roomList[currentRoom]).InDoor == -1)
                        {
                            Console.WriteLine("You cannot move that direction.");
                        }
                        else
                        {
                            currentRoom = ((ComplexRoom)roomList[currentRoom]).GoIn();
                        }
                    }
                }
                else if (input == "out" || input == "o")
                {
                    if (roomList[currentRoom].GetType() == typeof(ComplexRoom))
                    {
                        if (((ComplexRoom)roomList[currentRoom]).OutDoor == -1)
                        {
                            Console.WriteLine("You cannot move that direction.");
                        }
                        else
                        {
                            currentRoom = ((ComplexRoom)roomList[currentRoom]).GoOut();
                        }
                    }
                }
                else if (input == "up" || input == "u")
                {
                    if (roomList[currentRoom].GetType() == typeof(ComplexRoom))
                    {
                        if (((ComplexRoom)roomList[currentRoom]).UpDoor == -1)
                        {
                            Console.WriteLine("You cannot move that direction.");
                        }
                        else
                        {
                            currentRoom = ((ComplexRoom)roomList[currentRoom]).GoUp();
                        }
                    }
                }
                else if (input == "down" || input == "d")
                {
                    if (roomList[currentRoom].GetType() == typeof(ComplexRoom))
                    {
                        if (((ComplexRoom)roomList[currentRoom]).DownDoor == -1)
                        {
                            Console.WriteLine("You cannot move that direction.");
                        }
                        else
                        {
                            currentRoom = ((ComplexRoom)roomList[currentRoom]).GoDown();
                        }
                    }
                }
                else if (input == "get rod")
                {
                    if (roomList[currentRoom].RodHere == true) // Must have the rod in the room to pick it up.
                    {
                        rod.HasRod = true; // user picked up the rod
                        Console.WriteLine("picked up rod");
                        roomList[currentRoom].RodHere = false; // user cannot pick up the rod in this room unless one is put back here.
                        Console.WriteLine("rod on floor? : " + roomList[currentRoom].RodHere);
                        Console.WriteLine("user has rod? : " + rod.HasRod);
                        Console.WriteLine("OK");
                    }
                }
                else if (input == "drop rod")
                {
                    if (rod.HasRod == true) // user must have a rod to drop it
                    {
                        if (roomList[currentRoom].BirdHere) // must be a bird in the chamber to stun the bird.
                        {
                            roomList[currentRoom].CanGetBirdHere = true; // the bird is stunned and is gettable
                            roomList[currentRoom].BirdHere = false; // the bird is scared on the grown and not flying around.
                            Console.WriteLine("canGetBirdHere = " + roomList[currentRoom].CanGetBirdHere);
                            Console.WriteLine("Bird is flying/ungettable? = " + roomList[currentRoom].BirdHere);
                        }
                        rod.HasRod = false; // Use has dropped the rod.
                        roomList[currentRoom].RodHere = true;  // The rod is on the ground of this room.
                        Console.WriteLine("user has Rod? = " + rod.HasRod);
                        Console.WriteLine("rod on floor? =  " + roomList[currentRoom].RodHere);
                        Console.WriteLine("OK");
                    }
                }
                else if (input == "get bird")
                {
                    if (roomList[currentRoom].CanGetBirdHere == true) // must be a gettable bird in the room to pick it up
                    {
                        bird.GetBird(); // grab the bird
                        roomList[currentRoom].CanGetBirdHere = false; // cannot grab the bird again b/c user already has it.

                        Console.WriteLine("Getting bird.  User has bird? = " + bird.HasBird);
                        Console.WriteLine("bird in room? =  " + roomList[currentRoom].BirdHere);
                        Console.WriteLine("Gettable bird in room? = " + roomList[currentRoom].CanGetBirdHere);
                        Console.WriteLine("OK");
                    }
                }
            } // end while not 'quit'
        } // end Main()
    } // end Class Program
} // end NameSpace
