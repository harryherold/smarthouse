using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Smarthouse
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    /// 
    
    public partial class Window2 : Window
    {
        database d = new database();

        
        
        string[] slide1;
        string[] slide2;
        string[] slide3;
        string[] slide4;
        string[] slide5;
        string[] slide6;

        int[] ident = new int[6];
        Applaince ap;


        public Window2()
        {
            InitializeComponent();
            ap = new Applaince();
            ap.appgroup = new ApplainceGroup();
        }
        public void setAGroup(int groupid)
        {
            ap.appgroup.appgroupnum = groupid;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {

        }
        public void changeValue(string first, string second, string third, string fourth, string five, string six, string [][] sliders)
        {
            if (first.Equals("null"))
            {
                textBox1.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Hidden;
                slider1.Visibility = Visibility.Hidden;
            }
            else
            {
                textBox1.Visibility = Visibility.Visible;
                slider1.Visibility = Visibility.Visible;
                label1.Visibility = Visibility.Visible;
                textBox1.Text = first;
                slide1 = sliders[0];
                label1.Content = slide1[0];
                slider1.Maximum = slide1.Length - 1;

            }
            if (second.Equals("null"))
            {
                slider2.Visibility = Visibility.Hidden;
                label2.Visibility = Visibility.Hidden;
                textBox2.Visibility = Visibility.Hidden;
            }
            else
            {

                textBox2.Visibility = Visibility.Visible;
                slider2.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Visible;
                textBox2.Text = second;
                slide2 = sliders[1];
                label2.Content = slide2[0];
                slider2.Maximum = slide2.Length - 1;
            }
            if (third.Equals("null"))
            {
                slider3.Visibility = Visibility.Hidden;
                label3.Visibility = Visibility.Hidden;

                textBox3.Visibility = Visibility.Hidden;
            }
            else
            {
                textBox3.Visibility = Visibility.Visible;
                slider3.Visibility = Visibility.Visible;
                label3.Visibility = Visibility.Visible;
                textBox3.Text = third;
                slide3 = sliders[2];
                label3.Content = slide3[0];
                slider3.Maximum = slide3.Length - 1;
            }
            if (fourth.Equals("null"))
            {
                slider4.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                textBox4.Visibility = Visibility.Hidden;
            }
            else
            {
                textBox4.Visibility = Visibility.Visible;
                slider4.Visibility = Visibility.Visible;
                label4.Visibility = Visibility.Visible;
                textBox4.Text = fourth;
                slide4 = sliders[3];
                label4.Content = slide4[0];
                slider4.Maximum = slide4.Length - 1;
            }
            if (five.Equals("null"))
            {
                slider5.Visibility = Visibility.Hidden;
                textBox5.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
            }
            else
            {
                textBox5.Visibility = Visibility.Visible;
                slider5.Visibility = Visibility.Visible;
                label5.Visibility = Visibility.Visible;
                textBox5.Text = five;
                slide5 = sliders[4];
                label5.Content = slide5[0];
                slider5.Maximum = slide5.Length - 1;
            }
            if (six.Equals("null"))
            {
                slider6.Visibility = Visibility.Hidden;
                textBox6.Visibility= Visibility.Hidden;
                label6.Visibility = Visibility.Hidden;
            }
            else
            {
                textBox6.Visibility = Visibility.Visible;
                slider6.Visibility = Visibility.Visible;
                label6.Visibility = Visibility.Visible;
                textBox6.Text = six;
                slide6 = sliders[5];
                label6.Content = slide6[0];
                slider6.Maximum = slide6.Length - 1;
            }

        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int var2 = (int) slider2.Value;
            label2.Content = slide2[var2];
        }

        private void slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int var3 = (int) slider3.Value;
            label3.Content = slide3[var3];
        }

        private void slider4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int var4 = (int)slider4.Value;
            label4.Content = slide4[var4];
        }

        private void slider5_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int var5 = (int)slider5.Value;
            label5.Content = slide5[var5];
        }

        private void slider6_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int var6 = (int)slider6.Value;
            label6.Content = slide3[var6];
        }

        private void Cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void slider1_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int var1 = (int)slider1.Value;
            label1.Content = slide1[var1];
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            String name = textBox8.Text;

            ap.name = name;
            ap.gestures = "";
            ap.command = "";
            List<Feature> list = new List<Feature>();
            if (slider1.IsVisible)
            {
                list.Add(new Feature(0,
                                       textBox1.Text,
                                       string.Join(",", slide1.ToArray()),
                                       (int) slider1.Value));
            }
            if (slider2.IsVisible)
            {
                list.Add(new Feature(0,
                                       textBox2.Text,
                                       string.Join(",", slide2.ToArray()),
                                       (int)slider2.Value));
            }
            if (slider3.IsVisible)
            {
                list.Add(new Feature(0,
                                       textBox3.Text,
                                       string.Join(",", slide3.ToArray()),
                                       (int)slider3.Value));
            }
            if (slider4.IsVisible)
            {
                list.Add(new Feature(0,
                                       textBox4.Text,
                                       string.Join(",", slide4.ToArray()),
                                       (int)slider4.Value));
            }
            if (slider5.IsVisible)
            {
                list.Add(new Feature(0,
                                       textBox5.Text,
                                       string.Join(",", slide5.ToArray()),
                                       (int)slider5.Value));
            }
            if (slider6.IsVisible)
            {
                list.Add(new Feature(0,
                                       textBox6.Text,
                                       string.Join(",", slide6.ToArray()),
                                       (int)slider6.Value));
            }
            ap.features = list;
            database d = new database();
            int anum = d.AddAppliance(ap);
            d.AddFeatures(ap.features, anum);
        }
        /*private void button1_Click(object sender, RoutedEventArgs e)
        {

            String name = textBox8.Text;
            int prop1 = (int) slider1.Value;
            int prop2 = (int)slider2.Value;
            int prop3 = (int)slider3.Value;
            int prop4 = (int)slider4.Value;
            int prop5 = (int)slider5.Value;
            int prop6 = (int)slider6.Value;


            Applaince tmp = d.getApp(name);
            List<Feature> list = d.getfeature(tmp.appnum);
            Feature f;

            f = list[0];
            f.value = prop1;
            d.setfeature(f);

            f = list[1];
            f.value = prop2;
            d.setfeature(f);

            f = list[2];
            f.value = prop3;
            d.setfeature(f);

            if (slider4.IsVisible)
            {
                f = list[3];
                f.value = prop4;
                d.setfeature(f);
            }
            if (slider5.IsVisible)
            {
                f = list[4];
                f.value = prop5;
                d.setfeature(f);
            }
            if (slider6.IsVisible)
            {
                f = list[5];e
                f.value = prop6;
                d.setfeature(f);
            }
            this.Close();
        }*/

        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
