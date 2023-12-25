using AdventureLand.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLand
{
    public class Game
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

        private RoomList _map;

        private Actor _player;

        public Game()
        {
            InitGame();
            StartGame();
        }

        private void InitGame()
        {

            room0 = new Room("Troll Room", "a dank, dark room that smells of troll", Rm.NOEXIT, Rm.Cave, Rm.NOEXIT, Rm.Forest);
            room1 = new Room("Forest Room", "a light, airy forest shimmering with sunlight", Rm.NOEXIT, Rm.NOEXIT, Rm.TrollRoom, Rm.NOEXIT);
            room2 = new Room("Cave Room", "a vast cave with walls covered by luminous moss", Rm.TrollRoom, Rm.NOEXIT, Rm.NOEXIT, Rm.Dungeon);
            room3 = new Room("Dungeon Room", "a gloomydungeon, Rats scurry across it's floor", Rm.NOEXIT, Rm.NOEXIT, Rm.Cave, Rm.NOEXIT);

            _map = new RoomList();

            _map.Add(Rm.TrollRoom, room0);
            _map.Add(Rm.Forest, room1 );
            _map.Add(Rm.Cave, room2 );
            _map.Add(Rm.Dungeon, room3 );   

            _player = new Actor("You", "The Player", room0);
        }
        
        private void StartGame()
        {
            string s;
            string input = "";
            string output = "";

            s = $"Welcome to the Great Adventure!\r\nYou are in the {_map[Rm.TrollRoom]}. It is {_player.Location.Description}.\r\n" +
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

        private void Debug()
        {
            Console.WriteLine(_map.Describe());
        }

        private void ParseCommand(List<string> wordlist)
        {
            String verb;
            List<string> commands = new List<string> { "n", "s", "w", "e", "look", "debug" };

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
                    case "debug":
                        Debug();
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

        private void MovePlayer(Rm newpos)
        {
            if (newpos == Rm.NOEXIT)
            {
                Console.WriteLine("There is no exit in that direction.");
            } else
            {
                _player.Location = _map.RoomAt(newpos);
                Console.WriteLine($"You are now in the {_player.Location.Name}.");
            }
        }
    }
}

