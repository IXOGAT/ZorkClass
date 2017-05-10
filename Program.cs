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
        public Room next = null;
        public Room prev = null;
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
        public void Display (Room room, Item item1, Item item2, Item item3)
        {
            room.description.Print(room);
            String keyIn = Input.getInput();
            String parsed = Input.Parser(keyIn);
            if (keyIn.Equals(item1.name))
            {
                item1.playerHas = true;
                Console.WriteLine("You pick up the " + item1.name);
            }
            if (keyIn.Equals(item2.name))
            {
                item2.playerHas = true;
                Console.WriteLine("You pick up the " + item2.name);
            }
            if (keyIn.Equals(item3.name))
            {
                item3.playerHas = true;
                Console.WriteLine("You pick up the " + item3.name);
            }
            if (keyIn.Equals(room.door.CmdDir))
            {
                room.next.Display();
            }
            if (parsed.Equals("look"))
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
                    String print = "You are in " + room.description.start + "There is " + room.item1.name + room.item1.location + room.description.join + room.item2.name + room.item2.location + room.description.join + room.item3.name + room.item3.location + room.description.join + room.door.position;
                }
            }
            else
            {
                Console.WriteLine("You enter " + room.description.start + "There is " + room.item1.name + room.item1.location + room.door.position);
            }
        }
    }
    public class Item
    {
        public String name = "";
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
        public int dmg;
    }
    class Program
    {
        static void Main (string[] args)
        {
            while (RunStat.IsRunning && Inventory.Php > 0)
            {
                //kitchen generation
                //you enter an old dilapated kitchen. There is a bottle on the table and a door in front of you
                Room Kitchen = new Room();
                Room Bedroom = new Room();
                //Item BedroomBottle = new Item();
                //Door KitchenBedroom = new Door();
                //assigning objects
                Kitchen.next = Bedroom;
                //Kitchen.Item1 = BedroomBottle;
                //Kitchen.door = KitchenBedroom;
                //Kitchen.prev is null
                Kitchen.description.start = "an old dilapated kitchen. ";
                Kitchen.item1.name = "a bottle ";
                Kitchen.item1.location = "on the table ";
                Kitchen.door.position = "a door in front of you.";
                Kitchen.door.CmdDir = "forward";
                Console.WriteLine("welcome!");
                Console.WriteLine("I hope that this works!");
                String KeyIn = Input.getInput();
                if (KeyIn.Equals("potatoes"))
                {
                    Console.WriteLine("Time to have fun!");
                    Kitchen.Display(Kitchen);
                }
                else
                {
                    Console.WriteLine("Good luck!");
                    Kitchen.Display(Kitchen);
                }
            }
        }
    }
}

///use parser to track down the allocated word
///intergrate it into the class system
///you take the " + item1 + "."