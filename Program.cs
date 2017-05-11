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
        //don't have it set to static, otherwise it can't be called
        public void Display (Room room, Player player)
        {
            Console.WriteLine(room.name);
            room.isIn = true;
            if (hasVisit != true)
            {
                Console.WriteLine("You enter " + room.description.start + "There is " + room.item1.description + room.item1.location + room.description.join + room.item2.description + room.item2.location + room.description.join + room.item3.description + room.item3.location + room.description.join + room.door.position);
            }
            room.hasVisit = true;
            String keyIn = Input.getInput();
            String parsed = Input.Parser(keyIn);
            if (keyIn.Contains(room.item1.name))
            {
                room.item1.playerHas = true;
                Console.WriteLine("You pick up the " + room.item1.name);
            }
            else if (keyIn.Contains(room.item2.name))
            {
                room.item2.playerHas = true;
                Console.WriteLine("You pick up the " + room.item2.name);
            }
            else if (keyIn.Contains(room.item3.name))
            {
                room.item3.playerHas = true;
                Console.WriteLine("You pick up the " + room.item3.name);
            }
            else if (parsed.Equals(room.door.CmdDir))
            {
                room.isIn = false;
                room.forward.Display(room.forward, player);
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
                player.PrintInv();
            }
            else
            {
                Console.WriteLine("err, not understood");
            }
        }
    }
    public class Description
    {
        public String start = "start";
        public String join = null;
        public String end = "end";
        public void Print (Room room)
        {
            if (room.hasVisit)
            {
                if (room.isIn)
                {
                    Console.WriteLine("You are in " + room.description.start + "There is " + room.item1.description + room.item1.location + room.description.join + room.item2.description + room.item2.location + room.description.join + room.item3.description + room.item3.location + room.description.join + room.door.position);
                }
                else
                {
                    Console.WriteLine("You enter " + room.description.start + "There is " + room.item1.description + room.item1.location + room.description.join + room.item2.description + room.item2.location + room.description.join + room.item3.description + room.item3.location + room.description.join + room.door.position);
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
        public int = Random(50);
        public String name = Random(100);
        public String description = "";
        public String location = "";
        //if the player has the object
        public Boolean playerHas = false;
    }
    public class Door
    {
        public String position = null;
        public String CmdDir = null;
    }
    public class Player
    {
        public String name;
        public int hp;
        public void PrintInv()
        {
            //something that scans through all the rooms or items, and reports if a player has it or not
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
                Kitchen.item1.location = "on the table ";
                Kitchen.door.position = "a door in front of you.";
                Kitchen.door.CmdDir = "forward";
            }
            Room Bedroom = new Room();
            {
                Bedroom.name = "BEDROOM";
                Bedroom.description.start = "a dark and nearly empty bedroom with a table in the middle and a bed pushed to the side.";
                Bedroom.item1.name = "wool sack";

            }
            Kitchen.forward = Bedroom;


            //player generation
            Player player = new Player()
            {
                hp = 100
            };
            Console.WriteLine("welcome!");
            Console.WriteLine("I hope that this works!");
            Console.WriteLine("press any key and then enter");
            String KeyIn = Input.getInput();
            Console.WriteLine("Time to have fun!");
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