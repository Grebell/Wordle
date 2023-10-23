using System;
using System.Collections;
using System.IO;
using System.Linq;
namespace wordle
{
    internal abstract class wordle
    {
        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("word_list.txt");
            var iterations= lines.Count();
            float one = 0;
            float two = 0;
            float three = 0;
            float four = 0;
            float five = 0;
            float six = 0;
            float wins = 0;
            var input = args[0];
            input = input.ToLower();
            if (input is "help" or "?" or "-h")
            {
                Console.WriteLine("how to use program:" +
                                  "" +
                                  "SELECTION STRATEGY:" +
                                  "Complete a series of rounds using the specified selection strategy to select guess words:" +
                                  "./Project2folder RANDOM" +
                                  "./Project2folder FIRSTWORD" +
                                  "./Project2folder MIDDLEWORD" +
                                  "./Project2folder ALGORITHM" +
                                  "" +
                                  "POWER WORD:" +
                                  "Complete a series of rounds using the same first word:" +
                                  "./Project2folder POWER" +
                                  "" +
                                  "HELP:" +
                                  "./Project2folder help" +
                                  "./Project2folder ?" +
                                  "./Project2folder -h");
                Environment.Exit(1);
            }

            if (input == "random" | input == "firstword" | input == "middleword" | input == "algorithm")
            {
                var rand = new Random();
                var loop = 0;
                Console.WriteLine("Strategy chose: " + input);
                nextword:
                for ( ;loop < iterations; loop++)
                {
                    
                    lines = File.ReadAllLines("word_list.txt");
                    var secretword = lines[loop];
                    //Console.WriteLine("secret word is: " + secretword);
                    var tests = 0;
                    while (true)
                    {
                        tests++;
                        var testword = "!!!!!";
                        switch (input)
                        {
                            case "random":
                            {
                                while (testword == "!!!!!")
                                {
                                    var tw = rand.Next(lines.Length);
                                    testword = lines[tw];
                                }

                                break;
                            }
                            case "firstword":
                                var ddadssad = 0;
                                while (testword == "!!!!!")
                                {
                                    testword = lines[ddadssad];
                                    ddadssad++;

                                }

                                break;
                            case "middleword":
                                var workingwords = new ArrayList();
                                foreach (string line in lines)
                                {
                                    if (line != "!!!!!")
                                    {
                                        workingwords.Add(line);
                                    }
                                }
                                testword = workingwords[workingwords.Count/2].ToString();
                                break;
                            case "algorithm":
                                //start testing powerwords
                                if (lines.Contains("TRULY"))
                                {
                                    testword = "TRULY";
                                } else if (lines.Contains("SOLID"))
                                {
                                    testword = "SOLID";
                                } else if (lines.Contains("SCOLD"))
                                {
                                    testword = "SCOLD";
                                } else if (lines.Contains("CLOUT"))
                                {
                                    testword = "CLOUT";
                                } else if (lines.Contains("SURLY"))
                                {
                                    testword = "SURLY";
                                } else if (lines.Contains("LOUSY"))
                                {
                                    testword = "LOUSY";
                                } else if (lines.Contains("SPOIL"))
                                {
                                    testword = "SPOIL";
                                } else if (lines.Contains("SONIC"))
                                {
                                    testword = "SONIC";
                                } else if (lines.Contains("COUNT"))
                                {
                                    testword = "COUNT";
                                } else if (lines.Contains("SOUND"))
                                {
                                    testword = "SOUND";
                                }
                                else
                                {
                                    while (testword == "!!!!!")
                                    {
                                        var tw = rand.Next(lines.Length);
                                        testword = lines[tw];
                                    }
                                }

                                break;
                        }

                        if (testword == secretword || tests > 6)
                        {
                            if (tests < 7)
                            {
                                wins++;
                                switch (tests)
                                {
                                    case 1:
                                        one++;
                                        break;
                                    case 2:
                                        two++;
                                        break;
                                    case 3:
                                        three++;
                                        break;
                                    case 4:
                                        four++;
                                        break;
                                    case 5:
                                        five++;
                                        break;
                                    case 6:
                                        six++;
                                        break;
                                }
                            }

                            loop++;
                            goto nextword;
                        }

                        var secretwordchars = secretword.ToCharArray();
                        var testwordchars = testword.ToCharArray();
                        //s
                        for (var i = 0; i < 5; i++)
                        {
                            //green
                            if (secretwordchars[i] == testwordchars[i])
                            {
                                int wordcount = 0;
                                foreach (var word in lines)
                                {
                                    var tempword = word.ToCharArray();
                                    if(tempword[i] != secretword[i])
                                    {
                                        lines[wordcount] = "!!!!!";
                                    }
                                    wordcount++;
                                }
                            }
                            for (var j = 0; j < 5; j++)
                            {
                                //yellow
                                if (secretwordchars[i] == testwordchars[j])
                                {
                                    var wordcount = 0;
                                    foreach (var word in lines)
                                    {
                                        if(!word.Contains(secretwordchars[i]))
                                        {
                                            lines[wordcount] = "!!!!!";
                                        }
                                        wordcount++;
                                    }
                                }
                                //black
                                else if(!secretword.Contains(testwordchars[j]))
                                {
                                    var wordcount = 0;
                                    foreach (var word in lines)
                                    {
                                        if (word.Contains(testwordchars[j]))
                                        {
                                            lines[wordcount] = "!!!!!";
                                        }
                                        wordcount++;
                                    }
                                }
                            }
                        }

                        //Console.WriteLine("\ntest #"+tests);
                        //Console.WriteLine("the testing word is: " + testword);
                        foreach (var line in lines)
                        {
                            if (line != "!!!!!")
                            {
                                //Console.WriteLine(line);
                            }
                        }
                    }
                }

                if (wins == 0)
                {
                    Console.WriteLine("Win/Lose percentage: %0");
                    Console.WriteLine("1st %0");
                    Console.WriteLine("2st %0");
                    Console.WriteLine("3st %0");
                    Console.WriteLine("4st %0");
                    Console.WriteLine("5st %0");
                    Console.WriteLine("6st %0");
                }
                else
                {
                    
                    Console.WriteLine("Win/Lose percentage: %" + wins/iterations*100);
                    Console.WriteLine("1st %" + one/wins*100);
                    Console.WriteLine("2st %" + two/wins*100);
                    Console.WriteLine("3st %" + three/wins*100);
                    Console.WriteLine("4st %" + four/wins*100);
                    Console.WriteLine("5st %" + five/wins*100);
                    Console.WriteLine("6st %" + six/wins*100);
                }

                
            }

            if (input != "power") return;
            {
                var powerlist = new ArrayList { "0:#####" };
                //basically the testing portion but testing everyword as the testword and seeinf what has the smallest "working words" list at the end
                var loop = 0;

                for (; loop < iterations; loop++)
                {
                    float wcounter = 0;
                    lines = File.ReadAllLines("word_list.txt");
                    var secretword = lines[loop];
                    //Console.WriteLine("secret word is: " + secretword);
                    foreach (var tword in lines)
                    {
                        lines = File.ReadAllLines("word_list.txt");
                        var testword = tword;

                        var secretwordchars = secretword.ToCharArray();
                        var testwordchars = testword.ToCharArray();
                        //s
                        for (var i = 0; i < 5; i++)
                        {
                            //green
                            if (secretwordchars[i] == testwordchars[i])
                            {
                                var wordcount = 0;
                                foreach (var word in lines)
                                {
                                    var tempword = word.ToCharArray();
                                    if (tempword[i] != secretword[i])
                                    {
                                        lines[wordcount] = "!!!!!";
                                    }

                                    wordcount++;
                                }
                            }

                            for (var j = 0; j < 5; j++)
                            {
                                //yellow
                                if (secretwordchars[i] == testwordchars[j])
                                {
                                    var wordcount = 0;
                                    foreach (var word in lines)
                                    {
                                        if (!word.Contains(secretwordchars[i]))
                                        {
                                            lines[wordcount] = "!!!!!";
                                        }

                                        wordcount++;
                                    }
                                }
                                //black
                                else if (!secretword.Contains(testwordchars[j]))
                                {
                                    var wordcount = 0;
                                    foreach (var word in lines)
                                    {
                                        if (word.Contains(testwordchars[j]))
                                        {
                                            lines[wordcount] = "!!!!!";
                                        }

                                        wordcount++;
                                    }
                                }
                            }
                        }

                        //Console.WriteLine("\ntest #"+tests);
                        //Console.WriteLine("the testing word is: " + testword);
                        foreach (var line in lines)
                        {
                            if (line != "!!!!!")
                            {
                                wcounter++;
                                //Console.WriteLine(line);
                            }
                        }
                    }

                    for (var a=0 ; a <= powerlist.Count ; a ++)
                    {
                        var pword = (string)powerlist[a];
                        var psplit = pword.Split(Convert.ToChar(":"));
                        var pnum = psplit[0];
                        var pint = float.Parse(pnum);
                        if (!(wcounter / iterations > pint)) continue;
                        powerlist.Insert(a, wcounter / iterations + ":" + lines[loop]);
                        break;
                    }

                }
                powerlist.Remove("0:#####");
                powerlist.Reverse();
                for (var l = 0; l < 10; l++)
                {
                    Console.WriteLine(powerlist[l]);
                }
            }

        }
    }
}
