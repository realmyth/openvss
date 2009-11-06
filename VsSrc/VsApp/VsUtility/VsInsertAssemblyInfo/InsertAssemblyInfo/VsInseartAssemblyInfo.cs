// jisv	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// rqsz	
// gqbf	 By downloading, copying, installing or using the software you agree to this license.
// cpoo	 If you do not agree to this license, do not download, install,
// mjqc	 copy or use the software.
// rjqe	
// mdjq	                          License Agreement
// pmvp	         For OpenVss - Open Source Video Surveillance System
// sutu	
// iuxi	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// mvhv	
// zhzz	Third party copyrights are property of their respective owners.
// euxz	
// iffa	Redistribution and use in source and binary forms, with or without modification,
// rnjn	are permitted provided that the following conditions are met:
// gcjt	
// umnh	  * Redistribution's of source code must retain the above copyright notice,
// wtfs	    this list of conditions and the following disclaimer.
// lhqw	
// buff	  * Redistribution's in binary form must reproduce the above copyright notice,
// ejmv	    this list of conditions and the following disclaimer in the documentation
// pwgm	    and/or other materials provided with the distribution.
// ptcv	
// ljbk	  * Neither the name of the copyright holders nor the names of its contributors 
// lnam	    may not be used to endorse or promote products derived from this software 
// trck	    without specific prior written permission.
// ofna	
// piyx	This software is provided by the copyright holders and contributors "as is" and
// iejw	any express or implied warranties, including, but not limited to, the implied
// poey	warranties of merchantability and fitness for a particular purpose are disclaimed.
// gasd	In no event shall the Prince of Songkla University or contributors be liable 
// rkgb	for any direct, indirect, incidental, special, exemplary, or consequential damages
// gfln	(including, but not limited to, procurement of substitute goods or services;
// usln	loss of use, data, or profits; or business interruption) however caused
// hcgk	and on any theory of liability, whether in contract, strict liability,
// jgwg	or tort (including negligence or otherwise) arising in any way out of
// ufmh	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace InsertAssemblyInfo
{
    public partial class VsInseartAssemblyInfo : Form
    {
        List<string> Files = new List<string>();
        Random random;

        public VsInseartAssemblyInfo()
        {
            InitializeComponent();
            random = new Random();
        }

        string status = "";

        public void getAllFile(String str)
        {
            listBox1.Items.Clear();
            Thread t = new Thread(() =>
            {
                Files.Clear();

                Queue<string> Dirs = new Queue<string>();
                Dirs.Enqueue(str);

                string type = textBox2.Text;

                while (Dirs.Count > 0)
                {
                    string dir = Dirs.Dequeue();
                    foreach (string Element in Directory.GetFileSystemEntries(dir))
                    {
                        // Sub directories
                        if (Directory.Exists(Element))
                        {
                            status = "add Dir" + Element;
                            Dirs.Enqueue(Element);
                        }

                        // Files in directory

                        else if (Path.GetFileName(Element).Equals(type)) //(Element.EndsWith(type))
                        {
                            status = "add" + Element;
                            Files.Add(Element);


                        }
                    }
                }
                status = "complete";

            });

            t.IsBackground = true;

            t.Start();

            //  return Files.ToArray();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;

                getAllFile(textBox1.Text);
                button2.Enabled = true;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            getAllFile(textBox1.Text);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = status;

            if (status.Contains("add"))
            {
                textBox3.Text = Files.Count.ToString();
                //listBox1.Items.Add(status);
            }


            else if (status.Contains("append"))
            {
                button4.Enabled = false;
                //listBox1.Items.Add(status);
                textBox3.Text = i.ToString();
            }



            else if ("complete".Equals(status))
            {
                status = "show all file";
                textBox3.Text = Files.Count.ToString();
                listBox1.Items.Clear();
                listBox1.Items.AddRange(Files.ToArray());


            }

            else if (status.Equals("appcompp"))
            {
                status = "";
                textBox3.Text = i.ToString();
                button4.Enabled = true;
            }


        }

        private string getText(string filePath)
        {

            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            StringBuilder s = new StringBuilder();


            while (sr.Peek() >= 0)
            {
                //  Thread.Sleep(10);
                s.AppendLine(sr.ReadLine());
            }


            sr.Close();
            fs.Close();

            return s.ToString();
        }




        private void addText(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);

            StringBuilder file = new StringBuilder();

            //file.AppendLine("//test ?????");

            string line;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("AssemblyCompany"))
                {
                    file.AppendLine(getAssemblyInfoLineStr("AssemblyCompany", textBoxAssemblyCompany.Text));
                }
                else if (line.Contains("AssemblyCopyright"))
                {
                    file.AppendLine(getAssemblyInfoLineStr("AssemblyCopyright", textBoxAssemblyCopyright.Text));
                }
                else if (line.Contains("AssemblyVersion"))
                {
                    file.AppendLine(getAssemblyInfoLineStr("AssemblyVersion", "1.0.0.0"));
                }
                else if (line.Contains("AssemblyFileVersion"))
                {
                    file.AppendLine(getAssemblyInfoLineStr("AssemblyFileVersion", "1.0.0.0"));
                }
                else
                {
                    file.AppendLine(line);
                }
            }
            //&& (line.Contains("//") || !(line.Contains("using ") || line.Contains("namespace ")))) { }

            //while (line != null)
            //{

            //    
            //    line = sr.ReadLine();
            //}

            sr.Close();
            fs.Close();

            //string s = "";
            //s = text + "\r\n";
            //s += file.ToString();


            fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);

            sw.Write(file.ToString());
            sw.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                // textBox4.Text = dlg.FileName;

                MessageBox.Show("You selected the file " + dlg.FileName + "\n\r" + getText(dlg.FileName));

                Files.Add(dlg.FileName);
                listBox1.Items.Add(dlg.FileName);
                //addText(filename, );
            }
        }
        int i = 0;

        private string getAssemblyInfoLineStr(string infoName, string infoValue)
        {
            return string.Format("[assembly: {0}(\"{1}\")]", infoName, infoValue);
        }

        private void appendToAllFile()
        {
            Thread t = new Thread(() =>
            {
                random = new Random();
                i = 0;

                foreach (string file in Files)
                {
                    status = "append to " + file;
                    addText(file);
                    i++;
                }

                status = "appcompp";
            });

            t.IsBackground = true;

            t.Start();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            appendToAllFile();
        }

    }
}
