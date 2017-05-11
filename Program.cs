using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatusStuff;

namespace ZorkClass
{
    public class Room
    {
        //should this be = null;, or = new ____();???
        public String name = null;
        public Room forward = null;
        public Room back = null;
        public Room left = null;
        public Room right = null;
        //object generation
        public Description description = new Description();
        public Item item1 = new Item();
        public Item item2 = new Item();
        public Item item3 = new Item();
        //if the player has been to the room before
        public Boolean hasVisit = false;
        //if the player is currently in the room
        public Boolean isIn = false;
        public Door door = new Door();
        public Door door2 = new Door();
        //don't have it set to static, otherwise it can't be called
        public void Display (Room room, Player player)
        {
            while (RunStat.IsRunning && player.hp > 0)
            {
                Console.WriteLine(room.name);
                room.isIn = true;
                if (hasVisit != true)
                {
                    Console.WriteLine("You enter " + room.description.start + "There is " + room.item1.description + room.item1.location + room.item2.description + room.item2.location + room.item3.description + room.item3.location + room.door.position);
                }
                room.hasVisit = true;
                String keyIn = Input.getInput();
                String parsed = Input.Parser(keyIn);
                if (keyIn.Contains(room.item1.name))
                {
                    room.item1.playerHas = true;
                    Console.WriteLine("You pick up the " + room.item1.name);
                    room.item1.description = "";
                    room.item1.location = "";
                }
                else if (keyIn.Contains(room.item2.name))
                {
                    room.item2.playerHas = true;
                    Console.WriteLine("You pick up the " + room.item2.name);
                    room.item2.description = "";
                    room.item2.location = "";
                }
                else if (keyIn.Contains(room.item3.name))
                {
                    room.item3.playerHas = true;
                    Console.WriteLine("You pick up the " + room.item3.name);
                    room.item3.description = "";
                    room.item3.location = "";
                }
                else if (keyIn.Contains(room.door.CmdDir))
                {
                    room.isIn = false;
                    if (keyIn.Contains("left"))
                    {
                        room.left.Display(room.left, player);
                    }
                    if (keyIn.Contains("right"))
                    {
                        room.right.Display(room.right, player);
                    }
                    if (keyIn.Contains("forward"))
                    {
                        room.forward.Display(room.forward, player);
                    }
                    if (keyIn.Contains("back"))
                    {
                        room.back.Display(room.back, player);
                    }
                }
                else if (parsed.Equals("look"))
                {
                    //not executing this code when run
                    room.description.Print(room);
                }
                else if (parsed.Equals("quit"))
                {
                    RunStat.IsRunning = false;
                }
                else if (parsed.Equals("inv"))
                {
                    player.PrintInv(room, player);
                }
                else if (parsed.Equals("clr"))
                {
                    Console.Clear();
                    GC.Collect();
                }
                else
                {
                    Console.WriteLine("err, not understood");
                }
            }
        }
    }
    public class Description
    {
        public String start = "start";
        public String end = "end";
        public void Print (Room room)
        {
            if (room.hasVisit)
            {
                if (room.isIn)
                {
                    Console.WriteLine("You are in " + room.description.start + "There is " + room.item1.description + room.item1.location + room.item2.description + room.item2.location + room.item3.description + room.item3.location + room.door.position);
                }
                else
                {
                    Console.WriteLine("You enter " + room.description.start + "There is " + room.item1.description + room.item1.location + room.item2.description + room.item2.location + room.item3.description + room.item3.location + room.door.position);
                }
            }
            else
            {
                Console.WriteLine("You enter " + room.description.start + "There is " + room.item1.description + room.item1.location + room.door.position);
            }
        }
    }
    public class Item
    {
        //really big random number to prevent null pointer exception
        public String name = "2345678767381749172341234723";
        public String description = "";
        public String location = "";
        //if the player has the object
        public Boolean playerHas = false;
    }
    public class Door
    {
        //really big random number to prevent null pointer exception
        public String position = "1234567892312412343345209";
        public String CmdDir = "2345671902384127349891234";
    }
    public class Player
    {
        public String name;
        public int hp;
        public void PrintInv(Room start, Player player)
        {
            //something that scans through all the rooms or items, and reports if a player has it or not
            Console.WriteLine(start.name + "duh!");
            Boolean isRunning = true;
            while (isRunning)
            {
                while (start.forward != null && start.forward.hasVisit)
                {
                    if (start.forward.item1.playerHas)
                    {
                        Console.WriteLine(start.forward.item1.name);
                    }
                    if (start.forward.item2.playerHas)
                    {
                        Console.WriteLine(start.forward.item2.name);
                    }
                    if (start.forward.item3.playerHas)
                    {
                        Console.WriteLine(start.forward.item3.name);
                    }
                    player.PrintInv(start.forward, player);
                }
                while (start.left != null && start.left.hasVisit)
                {
                    if (start.left.item1.playerHas)
                    {
                        Console.WriteLine(start.left.item1.name);
                    }
                    if (start.left.item2.playerHas)
                    {
                        Console.WriteLine(start.left.item2.name);
                    }
                    if (start.left.item3.playerHas)
                    {
                        Console.WriteLine(start.left.item3.name);
                    }
                    player.PrintInv(start.left, player);
                }
                while(start.right != null && start.right.hasVisit)
                {
                    if (start.right.item1.playerHas)
                    {
                        Console.WriteLine(start.right.item1.name);
                    }
                    if (start.right.item2.playerHas)
                    {
                        Console.WriteLine(start.right.item2.name);
                    }
                    if (start.right.item3.playerHas)
                    {
                        Console.WriteLine(start.right.item3.name);
                    }
                    player.PrintInv(start.right, player);
                }
                while(start.back != null && start.back.hasVisit)
                {
                    if (start.back.item1.playerHas)
                    {
                        Console.WriteLine(start.back.item1.name);
                    }
                    if (start.back.item2.playerHas)
                    {
                        Console.WriteLine(start.back.item2.name);
                    }
                    if (start.back.item3.playerHas)
                    {
                        Console.WriteLine(start.back.item3.name);
                    }
                    player.PrintInv(start.back, player);
                }
            }
        }
        public void PrintHis(Room start, Player player)
        {
            //something that scans through all the rooms, and reports if a player has been there or not
            //start has to have been visited
            Console.WriteLine(start.name + "duh!");
            Boolean isRunning = true;
            while (isRunning)
            {
                while (start.forward != null && start.forward.hasVisit)
                {
                    Console.WriteLine(start.forward.name);
                    player.PrintHis(start.forward, player);
                }
                while(start.left != null && start.left.hasVisit)
                {
                    Console.WriteLine(start.left.name);
                    player.PrintHis(start.left, player);
                }
                while(start.right != null && start.right.hasVisit)
                {
                    Console.WriteLine(start.right.name);
                    player.PrintHis(start.right, player);
                }
                while(start.back != null && start.back.hasVisit)
                {
                    Console.WriteLine(start.back.name);
                    player.PrintHis(start.back, player);
                }
            }
        }
    }
    class Program
    {
        static void Main (string[] args)
        {

            //kitchen generation
            //you enter an old dilapated kitchen. There is a bottle on the table and a door in front of you
            Room Kitchen = new Room();
            {
                //Kitchen.prev is null
                Kitchen.name = "KITCHEN";
                Kitchen.description.start = "an old dilapated kitchen. ";
                Kitchen.item1.name = "bottle";
                Kitchen.item1.description = "a bottle ";
                Kitchen.item1.location = "on the table and ";
                Kitchen.door.position = "a door in front of you.";
                Kitchen.door.CmdDir = "forward";
            }
            Room Bedroom = new Room();
            {
                Bedroom.name = "BEDROOM";
                Bedroom.description.start = "a dark and nearly empty bedroom with a table in the middle and a bed pushed to the side. ";
                Bedroom.item1.name = "sack";
                Bedroom.item1.description = "a wool sack ";
                Bedroom.item1.location = "on the table ";
                Bedroom.door.position = "a door to your left.";
                Bedroom.door.CmdDir = "left";
            }
            Room Closet = new Room();
            {
                Closet.name = "CLOSET";
                Closet.description.start = "a dimly lit closet .";
                Closet.item1.name = "flashlight";
                Closet.item1.description = "a flashlight ";
                Closet.item1.location = "on the floor ";
                Closet.door.position = "a trapdoor in the floor.";
                Closet.door.CmdDir = "below";
            }

            Kitchen.forward = Bedroom;
            Bedroom.left = Closet;
            //player generation
            Player player = new Player()
            {
                hp = 100
            };
            Console.WriteLine("welcome!");
            Console.WriteLine("I hope that this works!");
            //Console.WriteLine("before you can get started, what is your name?");
            //String KeyIn = Input.getInput();
            //KeyIn = player.name;
            //Console.WriteLine("OK, your name is " + player.name + "?");
            Console.WriteLine("Oh! I almost forgot! All the commands that you will need to know to win!");
            Console.WriteLine("Type 'quit' at any time to quit.");
            Console.WriteLine("Type 'inventory' at any time to see what items you possess.");
            Console.WriteLine("Type 'look around' at any time to see what is around you.");
            Console.WriteLine("Type 'has been' to at any time to see where you have been so far.");
            Console.WriteLine("Type 'back' to return to the previous room (if you can)");
            Console.WriteLine("Type 'clear' to clear the console.");
            Console.WriteLine("Good luck!");
            while (RunStat.IsRunning)
            {
                Kitchen.Display(Kitchen, player);
            }
        }
    }
}

///use parser to track down the allocated word
///intergrate it into the class system
///you take the " + item1 + "."