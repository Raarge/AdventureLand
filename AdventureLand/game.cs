using AdventureLand.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLand
{
    internal class game
    {
        /*
         * Troll Room -- Forest
         *     |
         * Cave  ------- Dungeon
         * */

        Room room0;
        Room room1;
        Room room2;
        Room room3;

        Room[] map;

        private Actor _player;

        public game()
        {
            InitGame();
            StartGame();
        }

        private void InitGame()
        {
            room0 = new Room("Troll Room", "a dank, dark room that smells of troll", -1, 2, -1, 1);
            room1 = new Room("Forrest", "a light, airy forest shimmering with sunlight", -1, -1, 0, -1);
            room2 = new Room("Cave", "a vast cave with walls covered by luminous moss", 0, -1, -1, 3);
            room3 = new Room("Dungeon", "a gloomydungeon, Rats scurry across it's floor", -1, -1, 2, -1);

            map = new Room[4];

            map[0] = room0;
            map[1] = room1;
            map[2] = room2;
            map[3] = room3;

            _player = new Actor("You", "The Player", room0);
        }
        
        private void StartGame()
        {
            string s;
            string input = "";
            string output = "";

            s = $"Welcome to the Great Adventure!\r\nYou are in the {_player.Location.Name}. It is {_player.Location.Description}.\r\n" +
                "Where do you want to go now?\r\n" +
                "Enter: N, S, W or E.\r\n";
            Console.WriteLine(s);

            do
            {
                Console.Write(">");
                input = Console.ReadLine();
                output = RunCommand(input);
                Console.WriteLine(output);
            } while (input != "q");
        }

        //private static void ParseCommand(List<string> wordlist)  two words used
        //{
        //    string verb;
        //    string noun;
        //    List<string> commands = new List<string> { "take", "drop" };
        //    List<string> objects = new List<string> { "sword", "ring", "snake" };

        //    if (wordlist.Count != 2)
        //    {
        //        Console.WriteLine("Only 2 word commands allowed!");

        //    } else
        //    {
        //        verb = wordlist[0];
        //        noun = wordlist[1];
        //        if (!commands.Contains(verb))
        //        {
        //            Console.WriteLine(verb + " is not a known verb!");
        //        }
        //        if (!objects.Contains(noun))
        //        {
        //            Console.WriteLine(noun + " is not a known noun!");
        //        }
        //    }
        //}

        private void ParseCommand(List<string> wordlist)
        {
            String verb;
            List<string> commands = new List<string> { "n", "s", "w", "e", "look" };

            verb = wordlist[0];

            if (!commands.Contains(verb))
            {
                Console.WriteLine(verb + " is not known!");
            }
            else
            {
                switch (verb)
                {
                    case "n":
                        MovePlayer(_player.Location.N);
                        break;
                    case "s":
                        MovePlayer(_player.Location.S);
                        break;
                    case "w":
                        MovePlayer(_player.Location.W);
                        break;
                    case "e":
                        MovePlayer(_player.Location.E); 
                        break;
                    case "look":
                        Look();
                        break;
                    default:
                        Console.WriteLine(verb + " not understood");
                        break;
                }
            }
        }

        public string RunCommand(string inputstr)
        {
            char[] delims = { ' ', '.' };
            List<string> strlist;
            string s = "ok";
            string lowstr = inputstr.Trim().ToLower();

            if (lowstr != "q")
                if (lowstr == "")
                {
                    s = "You must enter a command";
                }
                else
                {
                    strlist = new List<string>(lowstr.Split(delims, StringSplitOptions.RemoveEmptyEntries));
                    
                    ParseCommand(strlist);
                }
            return s;
        }

        private void Look()
        {
            Console.WriteLine($"You are in the {_player.Location.Name}. It is {_player.Location.Description}\r\n");
        }

        private void MovePlayer(int newpos)
        {
            if (newpos == -1)
            {
                Console.WriteLine("There is no exit in that direction.");
            } else
            {
                _player.Location = map[newpos];
                Console.WriteLine($"You are now in the {_player.Location.Name}.");
            }
        }
    }
}

