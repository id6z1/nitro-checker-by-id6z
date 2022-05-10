using System;
using System.Linq;
using System.Threading;
using System.Net;
using System.IO;
namespace DISCORD_NITRO_CHECKER
{
    class Program
    {
        static int i = 0;
        static string currentcheck;
        static Random random = new Random();
        static bool s;
        static int sleep;
        static int i1 = 0;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Title = "NITRO CHECKER BY IG: @_jdo4 (id6z)";
            Console.Write(" _____  ____    ____  _____ " + "\n" + "|_   _||  _ \\  / ___||__   |" + "\n" + "  | |  | | | || |__     / / " + "\n" + "  | |  | | | ||  _ \\   / / " + "\n" + "  | |  | | | || | | | / / " + "\n" + " _| |_ | |_| || |_| || /___" + "\n" + "|_____||____/  \\___/ |_____|" + "\n");
            Console.WriteLine("type youre sleep (3000 is good / 1000 = 1 sec) : "); sleep = Convert.ToInt32(Console.ReadLine());


            
            check();
            Console.ReadKey();
        }
        public static void check()
        {
            while (i == 0)
            {
                Thread.Sleep(sleep);
                try
                {

                    string randomkey = RandomString(16);
                    currentcheck = "https://discord.gift/" + randomkey;

                    string uri = "https://discord.com/api/v9/entitlements/gift-codes/" + randomkey + "?country_code=US&with_application=true&with_subscription_plan=true";
                    
                    WebRequest wrq = (HttpWebRequest)WebRequest.Create(uri);
                    wrq.Method = "GET";
                    wrq.ContentType = "application/json";
                    string respoonse = wrq.GetResponse().GetResponseStream().ToString();


                }
                catch (WebException ex)
                {
                    string ahhhhhh = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    if (ahhhhhh.Contains("{\"message\": \"Unknown Gift Code\", \"code\": 10038}"))
                    {
                        if (s == true) {
                            s = false;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine( "[ID6Z]  [-] " + currentcheck + "\n");

                    }
                    else if (ahhhhhh.Contains("limited")) 
                    {
                        i1 += 1;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (s == false)
                        {
                            Console.WriteLine("[ID6Z]  [-] Blocked [The Block might stay for 30 secs the console is attmting ]");
                            s = true;
                        }
                        if (i1 == 200) {
                            i = 1;
                            Console.WriteLine("The console atemmted for 40 times but its still blocked here is the block log : " + "\n" + ahhhhhh);
                        }
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("[ID6Z]  [+]" + currentcheck + "\n" +"CODE: " + ahhhhhh);


                    }
                }

            }
        
            


        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghigklmnopqrstuvwxyz0123456789";
            return new string(System.Linq.Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void tr1y()
        {
            
            Thread th = new Thread(new ThreadStart(check));
            th.Start();
        }
    }
    }

