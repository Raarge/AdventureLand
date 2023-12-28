using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLand
{
    partial class Game
    {
        Dictionary<string, WT> vocab = new Dictionary<string, WT>();

        private void InitVocab()
        {
            vocab.Add("acorn", WT.NOUN);
            vocab.Add("bed", WT.NOUN);
            vocab.Add("bin", WT.NOUN);
            vocab.Add("sausage", WT.NOUN);
            vocab.Add("statue", WT.NOUN);
            vocab.Add("sword", WT.NOUN);
            vocab.Add("tree", WT.NOUN);
            vocab.Add("i", WT.VERB);
            vocab.Add("inventory", WT.VERB);
            vocab.Add("take", WT.VERB);
            vocab.Add("drop", WT.VERB);
            vocab.Add("look", WT.VERB);
            vocab.Add("n", WT.VERB);
            vocab.Add("s", WT.VERB);
            vocab.Add("w", WT.VERB);
            vocab.Add("e", WT.VERB);
            vocab.Add("q", WT.VERB);
            vocab.Add("quit", WT.VERB);
            vocab.Add("the", WT.ARTICLE);
            vocab.Add("a", WT.ARTICLE);

        }

        private string ProcessCommand(List<WordAndType> command)
        {
            string s = "";
            if (command.Count == 0)
            {
                s = "You must write a command!";
            }
            else if (command.Count > 2)
            {
                s = "That command is too long!";
            }
            else
            {
                s = "About to process command";
                switch (command.Count)
                {

                    case 1:
                        s = ProcessVerb(command);
                        break;
                    case 2:
                        s = ProcessVerbNoun(command);
                        break;
                    default:
                        s = "Unable to process command";
                        break;
                }
            }
            return s;
        }

        private string ParseCommand(List<string> wordlist)
        {
            List<WordAndType> command = new List<WordAndType>();
            WT wordtype;
            string errmsg = "";
            string s = "";

            foreach (string k in wordlist)
            {
                // Check to see if Key, s,
                // exists. If not, set WordType to ERROR
                if (vocab.ContainsKey(k))
                {
                    wordtype = vocab[k];
                    if (wordtype == WT.ARTICLE)
                    {  // ignorearticles such as "the or "a" 
                    }
                    else
                    {
                        command.Add(new WordAndType(k, wordtype));
                    }
                }
                else // if word isn't found in vocab
                {
                    command.Add(new WordAndType(k, WT.ERROR));
                    errmsg = $"Sorry, I don't understand '{k}'";
                }
            }

            if (errmsg != "")
            {
                s = errmsg;
            }
            else
            {
                s = ProcessCommand(command);
            }
            return s;
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

                    s = ParseCommand(strlist);
                }
            return s;
        }

        private string ProcessVerbNoun(List<WordAndType> command)
        {
            WordAndType wt = command[0];
            WordAndType wt2 = command[1];
            string s = "";
            if (wt.Type != WT.VERB)
            {
                s = $"Can't do this because '{wt.Word}' is not a command!";
            }
            else if (wt2.Type != WT.NOUN)
            {
                s = $"Can't do this because '{wt2.Word}' is not an object!";
            }
            else
            {
                switch (wt.Word)
                {
                    case "take":
                        s = TakeOb(wt2.Word);
                        break;
                    case "drop":
                        s = DropOb(wt2.Word);
                        break;
                    default:
                        s = $"I don't know how to {wt.Word} a {wt2.Word}!";
                        break;
                }
            }
            return s;
        }

        private string ProcessVerb(List<WordAndType> command)
        {
            WordAndType wt = command[0];
            string s = "";

            if (wt.Type != WT.VERB)
            {
                Console.WriteLine($"Can't do this because '{wt.Word}' is not a command!");
            }
            else
            {
                switch (wt.Word)
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
                        Console.WriteLine(wt.Word + " not understood");
                        break;
                }

            }
            return s;

        }

        private string TakeOb(string wt)
        {
            string s = "";
            s = $"You take {wt}";
            return s;
        }

        private string DropOb(string wt)
        {
            string s = "";
            s = $"You drop {wt}";
            return s;
        }
    }

}
