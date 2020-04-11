using System;

namespace Problem_01
{
    class Program
    {
        static void Main()
        {
            string activationKey = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {

                string[] commadInfo = input.Split(">>>");
                string cmd = commadInfo[0];

                if (cmd == "Contains")
                {
                    string substr = commadInfo[1];
                    if (activationKey.Contains(substr))
                    {
                        Console.WriteLine($"{activationKey} contains {substr}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }

                else if (cmd == "Flip")
                {
                    string type = commadInfo[1];
                    int startIndex = int.Parse(commadInfo[2]);
                    int endIndex = int.Parse(commadInfo[3]);

                    int count = endIndex - startIndex;
                    string substringChange = activationKey.Substring(startIndex, count);
                    if (type == "Upper")
                    {
                        substringChange = substringChange.ToUpper();
                    }
                    else if (type == "Lower")
                    {
                        substringChange = substringChange.ToLower();
                    }
                    activationKey = activationKey.Remove(startIndex, count);
                    activationKey = activationKey.Insert(startIndex, substringChange);
                    Console.WriteLine(activationKey);
                }

                else if (cmd == "Slice")
                {
                    int startIndex = int.Parse(commadInfo[1]);
                    int endIndex = int.Parse(commadInfo[2]);
                    int count = endIndex - startIndex;
                    activationKey = activationKey.Remove(startIndex, count);
                    Console.WriteLine(activationKey);
                }

            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
