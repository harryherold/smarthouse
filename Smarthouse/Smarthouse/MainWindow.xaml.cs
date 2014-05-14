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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Speech.Recognition;


namespace Smarthouse
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        database d = new database();

        int rowcount = 2;
        int columncount = 3;
        RowDefinition[] RowDef;
        ColumnDefinition[] ColDef;
        List <UserControl1> usList;
        public MainWindow()
        {
            InitializeComponent();
            List<Applaince> allapps = new List<Applaince>();
            allapps = d.getAllApps();
            createGrid();
            fillGrid(allapps);
            Console.WriteLine();
        }
        private void fillGrid(List<Applaince> allapps)
        {
            int row = 0;
            int col = 0;
            int j = 0;
            usList = new List<UserControl1>();
            foreach (Applaince a in allapps)
            {
                usList.Add( new UserControl1() );
                usList[j].mygrid.ColumnDefinitions.Add(new ColumnDefinition());
                usList[j].mygrid.ColumnDefinitions.Add(new ColumnDefinition());
       
                for (int i = 0; i < a.features.Count; i++)
                {
                    usList[j].mygrid.RowDefinitions.Add(new RowDefinition());
                }
                /*TextBox tb1 = new TextBox();
                tb1.Text = a.name;
                Grid.SetRow(tb1, 0);
                Grid.SetColumn(tb1, 0);

                usList[j].mygrid.Children.Add(tb1);*/

                for (int i = 0; i < a.features.Count; i++)
                {
                    string tmp = a.features[i].enums;
                    List<string> enums = tmp.Split(',').ToList<string>();
                    TextBox tb1 = new TextBox();
                    tb1.Text = a.features[i].name;
                    Grid.SetRow(tb1, i);
                    Grid.SetColumn(tb1, 0);

                    TextBox tb2 = new TextBox();
                    tb2.Text = enums[a.features[i].value];
                    Grid.SetRow(tb2, i);
                    Grid.SetColumn(tb2, 1);
                    usList[j].mygrid.Children.Add(tb1);
                    usList[j].mygrid.Children.Add(tb2);
                }
                if ((col % columncount) == 0 && (col != 0))
                {
                    row++;
                    col = 0;
                }
                Grid.SetRow(usList[j], row);
                Grid.SetColumn(usList[j], col);
                gridlayout.Children.Add(usList[j]);
                j++;
                col++;
            }
        }
        private void createGrid()
        {
            RowDef = new RowDefinition[rowcount];
            ColDef = new ColumnDefinition[columncount];

            for (int i = 0; i < rowcount; i++)
            {
                RowDef[i] = new RowDefinition();
                gridlayout.RowDefinitions.Add(RowDef[i]);
               
                /*for (int j = 0; j < columncount; j++)
                {
                    ColDef[j] = new ColumnDefinition();
                    gridlayout.ColumnDefinitions.Add(ColDef[j]);
                }*/
            }
            for (int i = 0; i < columncount; i++)
            {
                ColDef[i] = new ColumnDefinition();
                gridlayout.ColumnDefinitions.Add(ColDef[i]);
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            var w1 = window1;
            w1.ShowDialog();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            var w3 = window3;
            w3.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        

       




    }
}
