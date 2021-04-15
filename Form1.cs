using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmongUsHack_RaiCho
{
    public partial class Form1 : Form
    {
        Memory.Mem memory = new Memory.Mem();

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        //public static string speedLocation = "GameAssembly.dll+00DBDEA4,408,11C";
        public static string speedLocation = "GameAssembly.dll+00DA5A84,5C,4,14";
        public static string TotalImposter = "GameAssembly.dll+00DBDEA4,408,140";
        public static string noKillCooldown = "GameAssembly.dll+00DA3C30,5C,10,44";
        public static string getImposter = "GameAssembly.dll+00DA3C30,5C,10,34,28";
        float speedValue = 0;


        public Form1()
        {
            InitializeComponent();
            memory.OpenProcess(Process.GetProcessesByName("Among Us").FirstOrDefault().Id);
            BEFORESTART();
        }
        private void BEFORESTART()
        {
            speedValue = memory.ReadFloat(speedLocation);
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Show();
                button2.Hide();
                checkBox2.Checked = false;
            }
            else button1.Hide(); 
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string inverseValue = "-" + numericUpDown1.Value.ToString();
                MessageBox.Show("Inverse Cheat Activated ! With Speed " + numericUpDown1.Value.ToString() + "🔥");
                memory.WriteMemory(speedLocation, "float", inverseValue);
            }
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button2.Show();
                button1.Hide();
                checkBox1.Checked = false;
            }
            else button2.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                string Value = numericUpDown2.Value.ToString();
                MessageBox.Show("Speed Cheat Activated ! With Speed " + numericUpDown2.Value.ToString() + "🔥");
                memory.WriteMemory(speedLocation, "float", Value);
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
        }


        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Now Total imposter is " + numericUpDown3.Value.ToString() + "🔥");
            memory.WriteMemory(TotalImposter, "int", numericUpDown3.Value.ToString());
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                Thread NK = new Thread(NOKILL);
                NK.Start();  
            }
        }

        private void NOKILL()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.Q) < 0)
                {
                    memory.WriteMemory(noKillCooldown, "float", "0");
                }
                Thread.Sleep(100);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                memory.WriteMemory(getImposter, "int", "1");
                if (memory.ReadInt(getImposter) == 1)
                {
                    button5.Text = "Imposter Mode";
                }
                Thread GI = new Thread(GETIMP);
                GI.Start();
            }
        }

        private void GETIMP()
        {
            while (true)
            {
                if (checkBox4.Checked)
                {
                    if (GetAsyncKeyState(Keys.F) < 0)
                    {
                        if (memory.ReadInt(getImposter) == 1)
                        {
                            memory.WriteMemory(getImposter, "int", "0");
                            Thread.Sleep(50);
                            button5.Invoke((MethodInvoker)(() => button5.Text = "Crewmate Mode"));
                        }
                        else
                        {
                            memory.WriteMemory(getImposter, "int", "1");
                            Thread.Sleep(50);
                            button5.Invoke((MethodInvoker)(() => button5.Text = "Imposter Mode"));
                        }
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(100);
                } 
                Thread.Sleep(500);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox7.Checked = false;
                Thread UL = new Thread(ULTIMATE);
                UL.Start();
            }
        }
        public void ULTIMATE()
        {
            while (true)
            {
                if (checkBox5.Checked)
                {
                    memory.WriteMemory(getImposter, "int", "1");
                    Thread.Sleep(500);

                }
                Thread.Sleep(500);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                Thread PK = new Thread(PowerKey);
                PK.Start();
            }

        }
        private void PowerKey()
        {
            while (true)
            {
                if (checkBox6.Checked)
                {
                    if (GetAsyncKeyState(Keys.D1) < 0)
                    {
                        memory.WriteMemory(speedLocation, "float", "1");
                        Thread.Sleep(100);
                    }
                    else if (GetAsyncKeyState(Keys.D2) < 0)
                    {
                        memory.WriteMemory(speedLocation, "float", "2");
                        Thread.Sleep(100);
                    }
                    else if (GetAsyncKeyState(Keys.D3) < 0)
                    {
                        memory.WriteMemory(speedLocation, "float", "3");
                        Thread.Sleep(100);
                    }
                    else if (GetAsyncKeyState(Keys.D4) < 0)
                    {
                        memory.WriteMemory(speedLocation, "float", "4");
                        Thread.Sleep(100);
                    }
                    else if (GetAsyncKeyState(Keys.D5) < 0)
                    {
                        memory.WriteMemory(speedLocation, "float", "5");
                        Thread.Sleep(100);
                    }
                    else if (GetAsyncKeyState(Keys.D6) < 0)
                    {
                        memory.WriteMemory(speedLocation, "float", "6");
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(100);
                }
                Thread.Sleep(500); 
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox5.Checked = false;
                Thread CW = new Thread(CREWMATE);
                CW.Start();
            }
        }
        public void CREWMATE()
        {
            while (true)
            {
                if (checkBox7.Checked)
                {
                    memory.WriteMemory(getImposter, "int", "0");
                    Thread.Sleep(500);
                }
                Thread.Sleep(500);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
