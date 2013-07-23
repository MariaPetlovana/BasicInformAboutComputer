using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        internal string[] m_Disk_Name; 
        internal string[] m_Disk_Type; 
        internal string[] m_Disk_Label; 
        internal string[] m_Disk_Format; 
        internal string[] m_Disk_CurrentFreeSpace; 
        internal string[] m_Disk_TotalFreeSpace; 
        internal string[] m_Disk_TotalSpace; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label22.Text = Environment.OSVersion.ToString();
            label23.Text = Environment.SystemDirectory.ToString();
            label24.Text = Environment.Is64BitOperatingSystem ? "64" : "32";
            label25.Text = Environment.ProcessorCount.ToString();
            label26.Text = Environment.MachineName.ToString();
            label27.Text = Environment.UserName.ToString();
            
            string host = System.Net.Dns.GetHostName();
            label28.Text = System.Net.Dns.GetHostByName(host).AddressList[0].ToString();
            
            DriveInfo[] alldrivers = DriveInfo.GetDrives();

            int i = 0;
            m_Disk_Name = Environment.GetLogicalDrives();
            int a = m_Disk_Name.Length;
            m_Disk_Type = new string[a];
            m_Disk_Label = new string[a];
            m_Disk_Format = new string[a];
            m_Disk_CurrentFreeSpace = new string[a];
            m_Disk_TotalFreeSpace = new string[a];
            m_Disk_TotalSpace = new string[a];

            comboBox1.DataSource = m_Disk_Name;
            comboBox1.SelectedIndex = -1;
            
            foreach (DriveInfo d in alldrivers)
            {
                m_Disk_Type[i] = d.DriveType.ToString();

                if (d.IsReady == true)
                {
                    m_Disk_Label[i] = d.VolumeLabel;
                    m_Disk_Format[i] = d.DriveFormat;
                    m_Disk_CurrentFreeSpace[i] = d.AvailableFreeSpace.ToString();
                    m_Disk_TotalFreeSpace[i] = d.TotalFreeSpace.ToString();
                    m_Disk_TotalSpace[i] = d.TotalSize.ToString();
                }
                else
                {
                    m_Disk_Label[i] = "Unknown";
                    m_Disk_Format[i] = "Unknown";
                    m_Disk_CurrentFreeSpace[i] = "Unknown";
                    m_Disk_TotalFreeSpace[i] = "Unknown";
                    m_Disk_TotalSpace[i] = "Unknown";
                }

                ++i;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;

            if (-1 != i)
            {
                label16.Text = m_Disk_Type[i];
                label17.Text = m_Disk_Label[i];
                label18.Text = m_Disk_Format[i];
                label19.Text = m_Disk_CurrentFreeSpace[i];
                label20.Text = m_Disk_TotalFreeSpace[i];
                label21.Text = m_Disk_TotalSpace[i];
            }
        }
    }
}
