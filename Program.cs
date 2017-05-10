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
        public Door door = new Door();
        //don't have it set to static, otherwise it can't be called
        public void Display ()
        {
            description.Print();
        }
    }
    public class Description
    {
        public String start = "start";
        public Item item1 = null;
        public String join = null;
        public Item item2 = null;
        public String end = "end";
        public void Print (Location location)
        {
            if()
        }
    }
    public class Item
    {
        public String name = null;
        public String description = null;
        public String location = null;
    }
    public class Door
    {
        public String pre = null;
        public String position = null;
    }
    public class Location
    {
        public Boolean hasVisit = false;
        public String name = null;
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
                Kitchen.description.start = "a dilapated kitchen";
                Kitchen.item1.name = "bottle";
                Kitchen.item1.location = "on the table";
                Kitchen.door.position = "in front of you";
                Console.WriteLine("welcome!");
                Console.WriteLine("I hope that this works!");
                String KeyIn = Input.getInput();
                if (KeyIn.Equals("potatoes"))
                {
                    Console.WriteLine("Time to have fun!");
                    Kitchen.Display();
                }
                else
                {
                    Console.WriteLine("Good luck!");
                    Kitchen.Display();
                }
            }
        }
    }
}

///use parser to track down the allocated word
///intergrate it into the class system
///you take the " + item1 + "."