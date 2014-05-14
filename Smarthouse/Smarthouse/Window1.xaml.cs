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
using Microsoft.Speech.Recognition;

namespace Smarthouse
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        database d = new database();
        private SpeechRecognitionEngine sre;

        public Window1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

 

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window2 coffeemachine = new Window2();
            coffeemachine.setAGroup(1);
            /*Applaince ap1= new Applaince();
           
            ap1 = d.getApp(textBox1.Text);
            d.getfeature(ap1.appnum); 
            //List<Feature> list = d.getfeature(ap1.appnum); 
            List<Feature> list = ap1.features;
            String[] Array =new String[6];

            for(int i =0; i<list.Count;i++)
            {
               Array[i]= list[0].name;
            }*/

            string[] slide1 = { "cold", "warm", "hot", "very Hot" };
            string[] slide2 = { "no milk", "1", "2", "3", "4" };
            string[] slide3 = { "no sugar", "1", "2", "3", "4" };
            string[] slide4 = { "short", "long" };

            coffeemachine.changeValue("Temperature", "milk", "sugar", "shortlong", "null","null", new string [][] {slide1,slide2,slide3,slide4} );
            var w2 = coffeemachine;
            w2.ShowDialog();
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            Window2 oven = new Window2();

            oven.setAGroup(2);
            string [] slide1 = new string[45];
            for (int i = 0,j=0; i <= 220; i+=5,j++)
            {
                slide1[j] += "" + i;
            }
            string[] slide2 = { "off", "on" };
            string[] slide3 = { "fan assited","conventional oven","browning element","warming"};
            string[] slide4 = { "0 min", "15min", "30min", "45min","60min" };
            oven.changeValue("temperature", "light", "mode", "time", "null", "null", new string[][] { slide1, slide2, slide3, slide4 });
            var w2 = oven;
            w2.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Window2 microwave = new Window2();
            microwave.setAGroup(3);

            string[] slide1 = new string[45];
            for (int i = 0,j=0; i <= 220; i+=5,j++)
            {
                slide1[j] += "" + i;
            }
            string[] slide2 = { "0 min", "15min", "30min", "45min", "60min" };
            string[] slide3 = { "low", "medium", "high" };
            microwave.changeValue("Temperature", "Time", "Power", "null", "null", "null", new string[][] { slide1, slide2, slide3});
            var w2 = microwave;
            w2.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Window2 washingmachine = new Window2();

            washingmachine.setAGroup(4);

            string[] slide1 = {"cold","30","40","50","60","90"};
            
            string[] slide2 = { "cotton","colour","synthetic" };
            string[] slide3 = { "short","long" };
            string[] slide4 = { "800", "900","1000","1100","1200" };

            washingmachine.changeValue("Temperature", "Kind of Tissues", "time", "spin", "null", "null", new string[][] { slide1, slide2, slide3, slide4 });
            var w2 = washingmachine;
            w2.ShowDialog();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Window2 fridge = new Window2();

            fridge.setAGroup(5);

            string[] slide1 = { "10","9","8","7","6","5","4","3"};
            string[] slide2 = { "make ice","no ice" };
            string[] slide3 = { "1 per year","2 per year"};
            fridge.changeValue("Temperature", "Ice", "UnfreezePeriod", "null", "null", "null", new string[][] { slide1, slide2, slide3 });
            var w2 = fridge;
            w2.ShowDialog();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Window2 television = new Window2();

            television.setAGroup(6);

            string[] slide1 = { "on","off" };
            string[] slide2 = { "mute", "0","1","2","3","4","5","6","7","8","9" };
            string[] slide3 = { "0 min", "15min", "30min", "45min", "60min", "120min"};
            string[] slide4 = new string[50];
            for (int i = 1; i <= 50; i++)
            {
                slide4[i-1] += "" + i;
            }
            television.changeValue("OnOff", "Volume", "Timer", "Channel", "null", "null", new string[][] { slide1, slide2, slide3, slide4 });
            var w2 = television;
            w2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
