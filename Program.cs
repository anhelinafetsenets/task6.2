using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace task6._2
{
    public enum WeekDays { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday};
    class IP
    {
        private string ip;
        private List<TimeSpan> time { get; set; }
        private List<WeekDays> day;


        public IP( TimeSpan time, WeekDays day)
        {
            this.time.Add(time);
            this.day.Add(day);
        }
        public IP(string ip, TimeSpan time, WeekDays day):this( time, day)
        {
            this.ip = ip;
        }

        public void Add(IP a)
        {
            this.time.Add(a.time[0]);
            this.day.Add(a.day[0]);
        }
        public static  bool operator ==(IP a, IP b)
        {
            return a.ip == b.ip ? true : false;
        }
        public static bool operator !=(IP a, IP b)
        {
            return a.ip == b.ip ? false : true;
        }

        public static IP Parse(string str)
        {
            string[] subs = str.Split(" ");
            string aIp = subs[0];
            TimeSpan atime = TimeSpan.Parse(subs[1]);
            WeekDays aday;
            switch (subs[2])
            {
                case "sunday":
                    {
                        aday = WeekDays.Sunday;
                        break;
                    }
                case "monday":
                    {
                        aday = WeekDays.Monday;
                        break;
                    }
                case "tuesday":
                    {
                        aday = WeekDays.Tuesday;
                        break;
                    }
                case "wednesday":
                    {
                        aday = WeekDays.Wednesday;
                        break;
                    }
                case "thursday":
                    {
                        aday = WeekDays.Thursday;
                        break;
                    }
                case "friday":
                    {
                        aday = WeekDays.Friday;
                        break;
                    }
                case "saturday":
                    {
                        aday = WeekDays.Saturday;
                        break;
                    }
                default:
                    aday = WeekDays.Saturday;
                    break;
            }
            return new IP(aIp, atime, aday);
        }
       
        public int Count()
        {
            int count;
            for(count=0;count<time.Count; count++)
            foreach(TimeSpan a in time)
            {
                
            }
            return count;

        }
        public static int FindMostPop(int[] counter)
        {
             int max = counter[0];
            int maxindex = 0;
            for(int i=0;i<counter.Length;++i)
            {
                if (counter[i] > max)
                {
                    max = counter[i];
                    maxindex = i;
                }
            }
            return maxindex;
        }
        public WeekDays FindMostPopDay()
        {
            int[] dayscounter = new int[7];
           for(int i = 0; i < 7; ++i)
            {
                dayscounter[i] = 0;
            }
           foreach(WeekDays d in day)
            {
                dayscounter[(int)d]++;
            }

           
            return (WeekDays)FindMostPop(dayscounter);
        }
        public void Timeforeach(int[] hourcount)
        {
            foreach (TimeSpan t in this.time)
            {
                hourcount[t.Hours]++;
            }
        }
        public TimeSpan FindMostPopHour()
        {
            int[] hourcount = new int[24];
            for (int i = 0; i < 24; ++i)
            {
                hourcount[i] = 0;
            }
            Timeforeach(hourcount);
            return new TimeSpan(FindMostPop(hourcount), 0, 0);
        }

    }

    class SiteData
    {
        List<IP> arr;
        
        public void ReadFromFile(string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);
            arr.Add(IP.Parse(lines[0]));
            foreach(string s in lines)
            {
               IP a = IP.Parse(s);
                foreach (IP b in arr)
                {
                    if (b == a)
                    {
                        b.Add(a);
                    }
                }

            }
        }
        public TimeSpan FindMostPopHour()
        {
            int[] hourcount = new int[24];
            for (int i = 0; i < 24; ++i)
            {
                hourcount[i] = 0;
            }
            foreach(IP a in arr)
            {
                a.Timeforeach(hourcount);
            }
            return  new TimeSpan(IP.FindMostPop(hourcount), 0, 0);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
