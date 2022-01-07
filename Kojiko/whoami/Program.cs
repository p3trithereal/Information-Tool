using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace whoami
{
    class Program
    {

        static async Task Main(string[] args)
        {
            string version = "2.1";

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("");
            Console.WriteLine(" Connecting...");
            ping();


            WebClient check = new WebClient();
            string downloadlatestversion = check.DownloadString("here put version link");
            if (downloadlatestversion == version)
            {
                Console.Clear();
                goto start;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("INFO: Program is Outdated (v" + version + "), Update Found ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Downloading Update...     (v" + downloadlatestversion + ")");

                WebClient getlinkbypastebin = new WebClient();
                string getlink = getlinkbypastebin.DownloadString("here put download link");

                WebClient downloadnewprogram = new WebClient();
                string newprogram = Environment.CurrentDirectory + "\\kojiko" + downloadlatestversion + ".exe";
                downloadnewprogram.DownloadFile(getlink, newprogram);
                MessageBox.Show("The Update has been saved in\n" + newprogram,"Kojiko Update" + downloadlatestversion,MessageBoxButton.OK,MessageBoxImage.Information);
                Environment.Exit(0);

            }



        start:
            Console.Title = "Kojiko";
            Title();
            Console.WriteLine("Kojiko Information Tool made by p3tri");
            Console.WriteLine("For Help with Commands type /help");
            Console.Write("For Softaim and other things visit Our Discord ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("https://discord.gg/EJd4J4aDsF");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");
            string choice = Console.ReadLine();
            if (choice == "/help")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Commands:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/name ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer Name");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/domain ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer Domain Name");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/machinename ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer Machine Name");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/osversion ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer OS Version");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/version ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer Version");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/ipv4 ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your IPV4 Address");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/ip ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer Local IP Address");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/host ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer Host Name");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/mac ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer MAC Address");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/owner ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer Owner Name");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/hwid ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": your Computer HWID");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/cpuserial ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": CPU Serial Number");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/discord ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": Discord Invite Link");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/all ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(": All your Computer Infos");

                Console.ReadKey();
                Console.Clear();
                goto start;
            }
            if (choice == "/name")
            {                
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Username:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.UserName);
                Console.ReadKey();
                Console.Clear();
                goto start;
                
            }

            if (choice == "/domain")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Domain:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.UserDomainName);
                Console.ReadKey();
                Console.Clear();
                goto start;

            }

            if (choice == "/machinename")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer MachineName:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.MachineName);
                Console.ReadKey();
                Console.Clear();
                goto start;
            }

            if (choice == "/osversion")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer OS Version:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.OSVersion);
                Console.ReadKey();
                Console.Clear();
                goto start;
            }

            if (choice == "/version")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer Version:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.Version);
                Console.ReadKey();
                Console.Clear();
                goto start;

            }

            if (choice == "/ipv4")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer Ipv4:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Program.GetIP());
                Console.ReadKey();
                Console.Clear();
                goto start;
            }

            if (choice == "/ip")
            {
                Console.Clear();
                Title();
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Local IP Address:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(ip.ToString());
                        Console.ReadKey();
                        Console.Clear();
                        goto start;
                    }
                }

            }

            if (choice == "/host")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer HostName:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Dns.GetHostName());
                Console.ReadKey();
                Console.Clear();
                goto start;
            }

            if (choice == "/mac")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("MAC Address:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(GetMacAddress());
                Console.ReadKey();
                Console.Clear();
                goto start;
            }

            if (choice == "/owner")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer Owner:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(WindowsIdentity.GetCurrent().Owner);
                Console.ReadKey();
                Console.Clear();
                goto start;
            }
            if (choice == "/hwid")
            {
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("HWID:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(WindowsIdentity.GetCurrent().User.Value);
                Console.ReadKey();
                Console.Clear();
                goto start;
            }
            if(choice == "/cpuserial")
            {
                Console.Clear();
                Title();
                ManagementObjectSearcher moSearcher = new
                ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                ArrayList hardDriveDetails = new ArrayList();
                foreach (ManagementObject wmi_HD in moSearcher.Get())
                {

                    HardDrive hd = new HardDrive();  // User Defined Class
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("CPU Serial Number:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(hd.SerialNo);
                    Console.ReadKey();
                    Console.Clear();
                    goto start;
                }
            }
            

                if (choice == "/discord")
            {
                Process.Start("https://discord.gg/EJd4J4aDsF");
            }


            if (choice == "/all")
            {
                Console.Clear();
                //Title();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Username:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.UserName);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Domain:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.UserDomainName);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer MachineName:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.MachineName);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer OS Version:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.OSVersion);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer Version:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.Version);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer Ipv4:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Program.GetIP());
                Console.WriteLine("");
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Local IP Address:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(ip.ToString());
                        Console.WriteLine("");

                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer HostName:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Dns.GetHostName());
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("MAC Address:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(GetMacAddress());
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Computer Owner:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(WindowsIdentity.GetCurrent().Owner);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("HWID:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(WindowsIdentity.GetCurrent().User.Value);
                Console.WriteLine("");

                ManagementObjectSearcher moSearcher = new
                ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                ArrayList hardDriveDetails = new ArrayList();
                foreach (ManagementObject wmi_HD in moSearcher.Get())
                {

                    HardDrive hd = new HardDrive();  // User Defined Class
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("CPU Serial Number:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(hd.SerialNo);

                    Console.ReadKey();
                    Console.Clear();
                    goto start;
                }
             }

            else
            {
                MessageBox.Show(choice + " is not a correct Command!", "p3tri",MessageBoxButton.OK,MessageBoxImage.Error);
                Console.Clear();
                goto start;
            }

            
        }


        public static void Title()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("                                                                                                             p3tri#8466");
          Console.WriteLine("");
          Console.WriteLine("██╗  ██╗ ██████╗      ██╗██╗██╗  ██╗ ██████╗ ");
          Console.WriteLine("██║ ██╔╝██╔═══██╗     ██║██║██║ ██╔╝██╔═══██╗");
          Console.WriteLine("█████╔╝ ██║   ██║     ██║██║█████╔╝ ██║   ██║");
          Console.WriteLine("██╔═██╗ ██║   ██║██   ██║██║██╔═██╗ ██║   ██║");
          Console.WriteLine("██║  ██╗╚██████╔╝╚█████╔╝██║██║  ██╗╚██████╔╝");
          Console.WriteLine("╚═╝  ╚═╝ ╚═════╝  ╚════╝ ╚═╝╚═╝  ╚═╝ ╚═════╝ ");
          Console.WriteLine("");
          Console.WriteLine("");
          Console.ForegroundColor = ConsoleColor.White;


        }

        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }
        public static async void ping()
        {
            
            Ping pingSender = new System.Net.NetworkInformation.Ping();
            try
            {
                PingReply reply = pingSender.Send("www.google.com");
                if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                {

                }
            }
            catch
            {
                MessageBox.Show("You're not Connected to Internet,\n Impossible to Enstablish a Connection", "Kojiko Tool", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.Clear();
                Title();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Title = "Kojiko Repair Tool";
                Console.WriteLine("  Kojiko Repair Tool");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Waiting For Internet Connection...");
                Console.WriteLine("");
                Console.WriteLine("If the Application will crash try to fix it by yourself");
                await Task.Delay(1500);
                pinglooptest();
            }


            void pinglooptest()
            {
                Ping ps = new System.Net.NetworkInformation.Ping();
                PingReply ry = ps.Send("www.google.com");
                if (ry.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    MessageBox.Show("Succesfully Connected","Kojiko Success",MessageBoxButton.OK,MessageBoxImage.Information);
                }
                else
                {
                    pinglooptest();
                }
            }
        }
        private static string GetIP()
        {
            string result = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    Task<HttpResponseMessage> async = httpClient.GetAsync("https://ip4.seeip.org");
                    Task<string> task = async.Result.Content.ReadAsStringAsync();
                    result = task.Result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return result;
        }
    }
}
