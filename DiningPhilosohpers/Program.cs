using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosohpers
{
     class Program
     {
          static void Main(string[] args)
          {
               int num_philosohers = 5;
               Thread[] t = new Thread[num_philosohers];
               Semaphore[] s = new Semaphore[num_philosohers];
               for (int i = 0; i < num_philosohers; i++)
               {
                    s[i] = new Semaphore(1, 1);
               }
               DiningPhilosohpers.Program phill = new Program();
               for (int i = 0; i < num_philosohers; i++)
               {
                    t[i] = new Thread(phill.start);
                    t[i].Start(new Philospher(i, new Random().Next(500), s, num_philosohers));
               }
               Thread.Sleep(10000);
               Console.WriteLine("done");
               Console.Read();
          }
          private void start(object args)
          {
               Philospher philospher = (Philospher)args;
               while (true)
               {
                    think(philospher);
                    bool acquireR = acquireChopstick(right(philospher.Id, philospher), philospher,"right");
                    bool acquireL = acquireChopstick(left(philospher.Id, philospher), philospher, "left");
                    //Thread.Sleep(500);
                    //if (philospher.ChopSticksInHand == 1)
                    //{
                    //     

                    //}
                    //else
                    //{
                    //    releaseChopstick(right(philospher.Id, philospher), philospher, "right");
                    //}
                    if (acquireL && acquireR)
                    {
                         eat(philospher);
                    }
                    else
                    {
                         if (!acquireL)
                         {
                              releaseChopstick(right(philospher.Id, philospher), philospher, "right");
                         }
                         if ((acquireL&&!acquireR))
                         {
                              //releaseChopstick(right(philospher.Id, philospher), philospher, "right");
                              releaseChopstick(left(philospher.Id, philospher), philospher, "left");
                         }
                    }
                    releaseChopstick(right(philospher.Id, philospher), philospher, "right");
                    releaseChopstick(left(philospher.Id, philospher), philospher, "left");
               }
          }
          private bool acquireChopstick(int i,Philospher phil,string hand)
          {
               bool x =phil.chopsticks[i].WaitOne();
               Console.WriteLine("Philosopher " + phil.Id + " is picking up chopstick " + i+ " on "+hand+" hand");
               phil.ChopSticksInHand = phil.ChopSticksInHand + 1;
               return x;
          }
          private void releaseChopstick(int i,Philospher phill,string hand)
          {
               phill.chopsticks[i].Release();
               Console.WriteLine("Philospher " + phill.Id + " is putting down chopstick " + i + " on " + hand + " hand");
               phill.ChopSticksInHand = phill.ChopSticksInHand - 1;
          }
          private void eat(Philospher phill)
          {
               int time = new Random().Next(phill.sleep);
               Console.WriteLine("Philosoher " + phill.Id + " is eating for "+time+"ms");
               Thread.Sleep(500);
          }
          private void think(Philospher phill)
          {
               int time = new Random().Next(phill.sleep);
               Console.WriteLine("Philosopher " + phill.Id + " is thinking for " + time + "ms");
               Thread.Sleep(300);
               Console.WriteLine("Philosopher " + phill.Id + " is ready to eat again");
          }
          private int right(int i, Philospher phill)
          {
               return (i++) % phill.numOfphils;
          }
          private int left(int i,Philospher phill)
          {
               return (phill.numOfphils + i - 1) % phill.numOfphils;
          }

     }
     class Philospher
     {
          public int Id { get; set; }
          public int sleep { get; set; }
          public Semaphore[] chopsticks { get; set; }
          public int numOfphils { get; set; }
          public int ChopSticksInHand { get; set; }
          public Philospher(int id, int sleep,Semaphore[] chopsticks,int numofphils)
          {
               this.Id = id;
               this.sleep = sleep;
               this.chopsticks = chopsticks;
               this.numOfphils = numofphils;
          }
     }
     class Fork
     {
          public Fork(int id)
          {
               this.id = id;
               inUse = false;
               whichPhilosopher = null;
          }
          public int id { get; private set; }
          public bool inUse { get; set; }
          public object whichPhilosopher { get; set; }
     }

}
