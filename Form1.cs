using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace FolderSplitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int sayac=0;
            int bolunme_adedi=999999999;
            //int dosya_sayisi = 10;

            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("bölünme adedi giriniz...");
                
            }
            else
            {
                bolunme_adedi = Int32.Parse(textBox1.Text);
                progressBar1.Minimum = 1;
                
                DialogResult dr = folderBrowserDialog1.ShowDialog();
                string foldername = "";
                string dizin;

                if (dr == DialogResult.OK)
                {
                    foldername = folderBrowserDialog1.SelectedPath;


                }
                else
                {
                    return;
                }
                DirectoryInfo d = new DirectoryInfo(foldername);
                dizin = d.Name;
                FileInfo[] file = d.GetFiles();


                int klasor_no = 1;
                int dosya_sayisi = file.Length;
                progressBar1.Visible = true;
                progressBar1.Maximum = dosya_sayisi;
                progressBar1.Value = 1;
                progressBar1.Step = 1;
                MessageBox.Show(dosya_sayisi.ToString());
                // dosya sayısı kontrol başlangıcı............

                if (dosya_sayisi > bolunme_adedi)
                {
                    //++++++++++foreach dosyalar döngü başlangıcı++++++++++++++++++++++++++++++4

                    #region foreach kontrol
                    foreach (FileInfo dosya in file)
                    {

                        sayac++;
                        #region sayackontrol
                        if (sayac > bolunme_adedi)
                        {
                            klasor_no++;
                            sayac = 1;


                        }

                        #endregion
                        string yeniyol = foldername + "\\" + dizin + "_"+klasor_no;


                        #region directoryKontrol
                        if (Directory.Exists(yeniyol) == true)
                        {

                            dosya.MoveTo(Path.Combine(yeniyol, dosya.Name));
                            progressBar1.PerformStep();

                        }


                        else
                        {
                            Directory.CreateDirectory(yeniyol);
                            dosya.MoveTo(Path.Combine(yeniyol, dosya.Name));
                            progressBar1.PerformStep();
                        }
                        #endregion

                        Application.DoEvents();

                        //MessageBox.Show(tamyol+":..................."+dosya.FullName);
                    }
                    #endregion

                    //++++++++++foreach dosyalar döngü bitimi++++++++++++++++++++++++++++++4
                }

                else
                {
                    return;
                }

                progressBar1.Visible = false;
                MessageBox.Show("..............klasör bölme işlemi tamamlandı.........");
            }
            
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bir klasör içerisindeki dosyaları belirtilen adede böler ve ana klasör ile aynı isimde olan numaralandırılmış alt klasörlere kopyalar...\n\n Yazan:Caner KOCAMAZ.\n E-posta:kocamaz.caner@gmail.com");
        }
                //dosya sayısı kontrol bitiş............

                 
        
        }
    }
