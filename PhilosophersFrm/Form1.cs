using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PhilosophersFrm
{
     public partial class Form1 : Form
     {
          //best case is to let nuber of threads be one less than number of philosohers and semaphores(chopsticks)
         static int num_philosohers = 5;
          Thread[] t;
          Semaphore[] s;
          public Form1()
          {
               InitializeComponent();
          }

          private void Form1_Load(object sender, EventArgs e)
          {
               num_philosohers = panel1.Controls.Count;
               t = new Thread[num_philosohers];
               s = new Semaphore[num_philosohers];
               foreach (Control x in panel1.Controls)
               {
                    x.Text = "Philosopher " + panel1.Controls.IndexOf(x);
               }
          }
          //public void Load()
          //{
          //     num_philosohers = panel1.Controls.Count;
          //     t = new Thread[num_philosohers];
          //     s = new Semaphore[num_philosohers];
          //     foreach (Control x in panel1.Controls)
          //     {
          //          x.Text = "Philosopher " + panel1.Controls.IndexOf(x);
          //     }
          //}
          private void Start()
          {
               for (int i = 0; i < num_philosohers; i++)
               {
                    s[i] = new Semaphore(1, 1);
               }
               DiningPhilosopher phill = new DiningPhilosopher();
               for (int i = 0; i < num_philosohers; i++)
               {
                    t[i] = new Thread(phill.start);
                    t[i].Start(new Philospher(i, new Random().Next(500), s, num_philosohers,panel1.Controls[i]));
               }
          }
          private void Stop()
          {
               for (int i = 0; i < num_philosohers; i++)
               {
                    t[i].Abort();
                    panel1.Controls[i].BackColor = SystemColors.Control;
               }
          }

          private void btn_start_Click(object sender, EventArgs e)
          {
               btn_start.Enabled = false;
               btnadd.Enabled = false;
               txtnum.ReadOnly = true;
               Start();
               
          }

          private void btn_stop_Click(object sender, EventArgs e)
          {
               Stop();
               btn_start.Enabled = true;
               btnadd.Enabled = true;
               txtnum.ReadOnly = false;
          }

          private void btnadd_Click(object sender, EventArgs e)
          {
               int k;
               if (int.TryParse(txtnum.Text,out k))
               {
                    btnadd.Enabled = false;
                    txtnum.ReadOnly = true;
                    panel1.Controls.Clear();
                    for (int i = 0; i < int.Parse(txtnum.Text); i++)
                    {
                         Button btn = new Button();
                         btn.Size = new Size(107, 34);
                         btn.Location = new Point(200 + i, 50 * i);
                         btn.ForeColor = Color.DarkOrange;
                         btn.FlatStyle = FlatStyle.Standard;
                         panel1.Controls.Add(btn);
                         //btn.Text = "Philosopher " + i;
                    }
                    num_philosohers = panel1.Controls.Count;
                    t = new Thread[num_philosohers];
                    s = new Semaphore[num_philosohers];
                    foreach (Control x in panel1.Controls)
                    {
                         x.Text = "Philosopher " + panel1.Controls.IndexOf(x);
                    }
               }
               else
               {
                    MessageBox.Show("bad input");
               }
               
               
          }
     }
     class Philospher
     {
          public int Id { get; set; }
          public int sleep { get; set; }
          public Semaphore[] chopsticks { get; set; }
          public int numOfphils { get; set; }
          public int ChopSticksInHand { get; set; }
          public Control guiPhilosopher { get; private set; }
          public PhilosopherStates state { get; set; }
          public Philospher(int id, int sleep, Semaphore[] chopsticks, int numofphils,Control ui)
          {
               this.Id = id;
               this.sleep = sleep;
               this.chopsticks = chopsticks;
               this.numOfphils = numofphils;
               guiPhilosopher = ui;
               guiPhilosopher.Click += (object sender, EventArgs e) =>
               {
                    MessageBox.Show("philosopher " + this.Id + " is " + state.ToString());
               };
          }
     }
     enum PhilosopherStates
     {
          Thinking,
          Hungry,
          Waiting,
          Eating,
     }
     class DiningPhilosopher
     {
          public void start(object args)
          {
               Philospher philospher = (Philospher)args;
               while (true)
               {
                    think(philospher);
                    if ((philospher.Id + 1) % 2 == 0)
                    {
                         acquireChopstick(right(philospher.Id, philospher), philospher, "right");
                         acquireChopstick(left(philospher.Id, philospher), philospher, "left");
                         eat(philospher);
                         releaseChopstick(right(philospher.Id, philospher), philospher, "right");
                         releaseChopstick(left(philospher.Id, philospher), philospher, "left");
                    }
                    else
                    {
                         acquireChopstick(left(philospher.Id, philospher), philospher, "left");
                         acquireChopstick(right(philospher.Id, philospher), philospher, "right");
                         eat(philospher);
                         releaseChopstick(left(philospher.Id, philospher), philospher, "left");
                         releaseChopstick(right(philospher.Id, philospher), philospher, "right");
                    }
               }
          }
          private void acquireChopstick(int i, Philospher phil, string hand)
          {
               phil.guiPhilosopher.BackColor = Color.Blue;
               phil.state = PhilosopherStates.Waiting;
               bool x = phil.chopsticks[i].WaitOne();
               Console.WriteLine("Philosopher " + phil.Id + " is picking up chopstick " + i + " on " + hand + " hand");
               phil.ChopSticksInHand = phil.ChopSticksInHand + 1;
          }
          private void releaseChopstick(int i, Philospher phill, string hand)
          {
               phill.chopsticks[i].Release();
               Console.WriteLine("Philospher " + phill.Id + " is putting down chopstick " + i + " on " + hand + " hand");
               phill.ChopSticksInHand = phill.ChopSticksInHand - 1;
          }
          private void eat(Philospher phill)
          {
               int time = new Random().Next(phill.sleep);
               phill.state = PhilosopherStates.Eating;
               Console.WriteLine("Philosoher " + phill.Id + " is eating for " + time + "ms");
               phill.guiPhilosopher.BackColor = Color.Green;
               Thread.Sleep(350);
          }
          private void think(Philospher phill)
          {
               int time = new Random().Next(phill.sleep);
               phill.state = PhilosopherStates.Thinking;
               Console.WriteLine("Philosopher " + phill.Id + " is thinking for " + time + "ms");
               phill.guiPhilosopher.BackColor = Color.Yellow;
               Thread.Sleep(300);
               phill.state = PhilosopherStates.Hungry;
               Console.WriteLine("Philosopher " + phill.Id + " is ready to eat again");
               phill.guiPhilosopher.BackColor = Color.Red;
          }
          private int right(int i, Philospher phill)
          {
               return (i++) % phill.numOfphils;
          }
          private int left(int i, Philospher phill)
          {
               return (phill.numOfphils + i - 1) % phill.numOfphils;
          }
     }
}
