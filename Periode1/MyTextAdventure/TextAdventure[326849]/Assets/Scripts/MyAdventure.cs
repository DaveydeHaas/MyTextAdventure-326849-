using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using UnityEngine;

public class MyAdventure : MonoBehaviour
{
    private enum States
    {
        start,
        room1,
            window1,
                climb,
                    burningroom,
                    opposite,
                            tree1,
                door1,
                    tree2,
                    climb2,
                door2,
                stairs,
                    jump,
                        glass1,
                        door3,
                    run,
                        glass2,
                        door4,
    }
    
    private States currentState = States.start;
    // Start is called before the first frame update
    void Start()
    {
        Terminal.ClearScreen();
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnUserInput(string input)
    {
        input = input.ToLower();
        if (currentState == States.start)
        {
            if (input == "start")
            {
                currentState = States.room1; 
                room1();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *start* to begin...");
            }
        }
        else if (currentState == States.room1)
        {
            if (input == "window")
            {
                currentState = States.window1;
                window1();
            }
            else if (input == "door")
            {
                currentState = States.door1;
                door1_1();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *window* to use the window");
                Terminal.WriteLine("Type *door* to use the door");
            }
        }
        else if (currentState == States.door1)
        {
            if (input == "next")
            {
                door1_2();
            }
            else if (input == "fire")
            {
                currentState = States.stairs;
                stairs();
            }
            else if (input == "door")
            {
                currentState = States.door2;
                door2();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *door* to get in the room");
                Terminal.WriteLine("Type *fire* to go through the fire");
            }
                
        }
        else if (currentState == States.stairs)
        {
            if (input == "jump")
            {
                currentState = States.jump;
                jump();
            }
            else if (input == "stairs")
            {
                currentState = States.run;
                run();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *jump* to jump downstairs");
                Terminal.WriteLine("Type *stairs* to run downstairs");
            }
        }
        else if (currentState == States.run)
        {
            if (input == "run")
            {
                currentState = States.door4;
                door4();
            }
            else if (input == "jump")
            {
                currentState = States.glass2;
                glass2();
            }
        }
        else if (currentState == States.jump)
        {
            if (input == "run")
            {
                currentState = States.door3;
                door3();
            }
            else if (input == "jump")
            {
                currentState = States.glass1;
                glass1();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *jump* to jump through the window");
                Terminal.WriteLine("Type *run* to run for the door");
            }
        }       
        else if (currentState == States.door3)
        {
            if (input == "restart")
            {
                Terminal.ClearScreen();
                currentState = States.start;
                Start();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *restart* to restart the game");
            }
        }
        else if (currentState == States.glass1)
        {
            if (input == "restart")
            {
                Terminal.ClearScreen();
                currentState = States.start;
                Start();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *restart* to restart the game");
            }
        }
        else if (currentState == States.door4)
        {
            if (input == "restart")
            {
                Terminal.ClearScreen();
                currentState = States.start;
                Start();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *restart* to restart the game");
            }
        }
        else if (currentState == States.glass1)
        {
            if (input == "restart")
            {
                Terminal.ClearScreen();
                currentState = States.start;
                Start();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *restart* to restart the game");
            }
        }
        else if (currentState == States.glass2)
        {
            if (input == "restart")
            {
                Terminal.ClearScreen();
                currentState = States.start;
                Start();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *restart* to restart the game");
            }
        }
        else if (currentState == States.window1)
        {
            if (input == "back")
            {
                currentState = States.door1;
                door1_1();
            }
            else if (input == "climb")
            {
                currentState = States.climb;
                climb();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *back* to go back inside");
                Terminal.WriteLine("Type *climb* to climb on the roof");
            }
        }
        else if (currentState == States.climb)
        {
            if (input == "right")
            {
                currentState = States.burningroom;
                burningroom();
            }
            else if (input == "look")
            {
                currentState = States.opposite;
                opposite();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *right* to get over the smoking room");
                Terminal.WriteLine("Type *look* to look for an other way");
            }
        }
        else if (currentState == States.burningroom)
        {
            if (input == "restart")
            {
                currentState = States.start;
                Start();
            }
        }
        else if (currentState == States.opposite)
        {
            if (input == "jump")
            {
                currentState = States.tree1;
                tree1();
            }
            else if (input == "look")
            {
                currentState = States.burningroom;
                burningroom();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *jump* to go for the tree");
                Terminal.WriteLine("Type *look* to look for another way");
            }
        }
        else if (currentState == States.tree1)
        {
            if (input == "restart")
            {
                currentState = States.start;
                Start();
            }
        }
        else if (currentState == States.door2)
        {
            if (input == "jump")
            {
                currentState = States.tree2;
                tree2();
            }
            else if (input == "climb")
            {
                currentState = States.opposite;
                opposite2();
            }
        }
        else if (currentState == States.tree2)
        {
            if (input == "restart")
            {
                currentState = States.start;
                Start();
            }
            else
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Type *restart* to restart the game");
            }
        }
    }

    void ShowMainMenu()
    {
        Terminal.WriteLine("Welcome to the Burning house.");
        Terminal.WriteLine("");
        Terminal.WriteLine("This game is a Text Adventure,");
        Terminal.WriteLine("that means you have to make choices");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *start* to begin...");
    }

    
    void room1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You wake up from a loud sound.");
        Terminal.WriteLine("It's the fire alarm");
        Terminal.WriteLine("What are you going to do?");
        Terminal.WriteLine("Type *window* to use the window");
        Terminal.WriteLine("Type *door* to use the door");
    }

    void window1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You decide to open the window.");
        Terminal.WriteLine("You look outside the window");
        Terminal.WriteLine("You are seeing a lot of smoke coming   from the room next door.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *back* to get back inside");
        Terminal.WriteLine("Type *climb* to get on the roof");
    }

    void door1_1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You decide to go for the door");
        Terminal.WriteLine("You pick up a shirt from the ground and start wrapping it around your hand");
        Terminal.WriteLine("You are opening the door with your hand you feel the heat coming through the shirt that is wrapped around your hand.");
        Terminal.WriteLine("You get in the hallway upstairs.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *next* to continue");
    }

    void door1_2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Flames are bursting through the right  side of the hallway,");
        Terminal.WriteLine("behind the flames are the stairs and in front of you is another room");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *door* to get in the room");
        Terminal.WriteLine("Type *fire* to go through the fire");
    }

    void stairs()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are running through the fire you get past the big flames,");
        Terminal.WriteLine("but when you reach the stairs they are on fire.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *jump* to jump downstairs");
        Terminal.WriteLine("Type *stairs* to run downstairs");
        
        
    }

    void door2()
    {
       Terminal.ClearScreen();
       Terminal.WriteLine("You are getting inside the room,");
       Terminal.WriteLine("and you are going for the window.");
       Terminal.WriteLine("There is a tree outside of the window.");
       Terminal.WriteLine("you open the window");
       Terminal.WriteLine("");
       Terminal.WriteLine("Type *jump* to go for the tree");
       Terminal.WriteLine("Type *climb* to get on the roof");
    }

    void jump()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are jumping off the railing,");
        Terminal.WriteLine("but hurt your ankle when you got down.");
        Terminal.WriteLine("The pain of the fall is unbearable.");
        Terminal.WriteLine("But you managed to get downstairs");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *jump* to jump through the window");
        Terminal.WriteLine("Type *run* to run for the door");
    }

    void run()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You start running through  the fire on the stairs.");
        Terminal.WriteLine("The pain of the burnings are unbearable.");
        Terminal.WriteLine("But you managed to get downstairs");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *jump* to jump through the window");
        Terminal.WriteLine("Type *run* to run for the door");
    }

    void door3()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are going for the door but the ceiling started dropping down.");
        Terminal.WriteLine("You got buried under the dropped ceiling.");
        Terminal.WriteLine("");
        Terminal.WriteLine("You died");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *restart* to try again");
    }

    void glass1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are going for the glass window.");
        Terminal.WriteLine("When you jump through the glass,");
        Terminal.WriteLine("the ceiling downstairs started falling down");
        Terminal.WriteLine("");
        Terminal.WriteLine("Good job you got outside.");
        Terminal.WriteLine("You survived.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *restart* to try a different outcome");
    }
    
    void door4()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are going for the door but the ceiling started dropping down.");
        Terminal.WriteLine("You barely passed the falling ceiling.");
        Terminal.WriteLine("You open the door and run outside.");
        Terminal.WriteLine("");
        Terminal.WriteLine("You survived");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *restart* to try a different outcome");
    }

    void glass2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are going for the glass window.");
        Terminal.WriteLine(" you jump through the glass, but");
        Terminal.WriteLine(" the glass slices through your flesh and you die of injuries.");
        Terminal.WriteLine("");
        Terminal.WriteLine("You died.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *restart* to try a different outcome");
    }

    void climb()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are starting to climb on the roof");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *right* to walk over the room with smoke");
        Terminal.WriteLine("Type *look* to look for another way");
    }

    void burningroom()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("you decided to go above the room with smoke to look for a way off the roof.");
        Terminal.WriteLine("But when you are where walking above the smoking room the roof started to fall.");
        Terminal.WriteLine("You fall down with the roof and you are stuck");
        Terminal.WriteLine("");
        Terminal.WriteLine("you died");
        Terminal.WriteLine("Type *restart* to find a way out");
    }

    void opposite()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("There is a tree 3 meters away from the house.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *jump* to go for the tree");
        Terminal.WriteLine("Type *look* to look for another way");
    }

    void tree1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You decided to go for the tree");
        Terminal.WriteLine("You jump and reach the tree,");
        Terminal.WriteLine("but you are to heavy and the branch breaks");
        Terminal.WriteLine("You hit the ground and your shoulder is broken");
        Terminal.WriteLine("");
        Terminal.WriteLine("Congratulations");
        Terminal.WriteLine("You escaped the burning house");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *restart* To find a different outcome");
    }

    void tree2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are jumping towards the tree,");
        Terminal.WriteLine("but you couldn't reach the tree.");
        Terminal.WriteLine("You are falling on your back and you break your ribs");
        Terminal.WriteLine("Those ribs spiced through your lungs and you cannot breathe");
        Terminal.WriteLine("");
        Terminal.WriteLine("You died");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *restart* to restart the game");
    }

    void opposite2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You got on the roof.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Type *jump* to go for the tree");
        Terminal.WriteLine("Type *look* to look for another way");

    }
    
    
}



