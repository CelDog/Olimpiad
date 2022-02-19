using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Olympiad;

namespace Olimpiad
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        //object sel_dbviewer;

        public Window1()
        {
            InitializeComponent();

            DbSelect.Items.Add("Cities");
            DbSelect.Items.Add("Countries");
            DbSelect.Items.Add("KindSports");
            DbSelect.Items.Add("Participants");
            DbSelect.Items.Add("Results");
            DbSelect.Items.Add("OlimpInfoes");

        }

        private void DbSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (DbSelect.SelectedValue as string)
            {
                case "Cities":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        dbcontrol.ConnectToDB(ref DbViewer, "Cities");

                        break;
                    }

                case "Countries":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        dbcontrol.ConnectToDB(ref DbViewer, "Countries");

                        break;
                    }

                case "KindSports":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        dbcontrol.ConnectToDB(ref DbViewer, "KindSports");

                        break;
                    }

                case "Participants":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        dbcontrol.ConnectToDB(ref DbViewer, "Participants");

                        break;
                    }

                case "Results":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();

                        dbcontrol.ConnectToDB(ref DbViewer, "Results");

                        break;
                    }

                case "OlimpInfoes":
                    {
                        DataBaseControl dbcontrol = new DataBaseControl();
                        dbcontrol.ConnectToDB(ref DbViewer, "OlimpInfoes");


                        break;
                    }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Add_Win add_Win = new Add_Win(DbSelect.SelectedValue.ToString());

            add_Win.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Add_Win add_Win = new Add_Win(DbSelect.SelectedValue.ToString());

            add_Win.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            DataBaseControl dbcontrol = new DataBaseControl();

            switch (DbSelect.SelectedValue.ToString())
            {
                case "Cities":
                    {
                        var id = (DbViewer.Items.CurrentItem as City).Id;

                        dbcontrol.GetContext().Cities.Remove(dbcontrol.GetContext().Cities.Where(i => i.Id.Equals(id)).FirstOrDefault());

                        break;
                    }

                case "Countries":
                    {
                        var id = (DbViewer.Items.CurrentItem as Country).Id;

                        dbcontrol.GetContext().Countries.Remove(dbcontrol.GetContext().Countries.Where(i => i.Id.Equals(id)).FirstOrDefault());

                        break;
                    }

                case "KindSports":
                    {
                        var id = (DbViewer.Items.CurrentItem as KindSport).Id;

                        dbcontrol.GetContext().KindSports.Remove(dbcontrol.GetContext().KindSports.Where(i => i.Id.Equals(id)).FirstOrDefault());

                        break;
                    }

                case "Participants":
                    {
                        var id = (DbViewer.Items.CurrentItem as Participant).Id;

                        dbcontrol.GetContext().Participants.Remove(dbcontrol.GetContext().Participants.Where(i => i.Id.Equals(id)).FirstOrDefault());

                        break;
                    }

                case "Results":
                    {
                        var id = (DbViewer.Items.CurrentItem as Participant).Id;

                        dbcontrol.GetContext().Results.Remove(dbcontrol.GetContext().Results.Where(i => i.Id.Equals(id)).FirstOrDefault());

                        break;
                    }

                case "OlimpInfoes":
                    {
                        var id = (DbViewer.Items.CurrentItem as OlimpInfo).Id;

                        dbcontrol.GetContext().OlimpInfos.Remove(dbcontrol.GetContext().OlimpInfos.Where(i => i.Id.Equals(id)).FirstOrDefault());

                        break;
                    }

                    
            }

            dbcontrol.GetContext().SaveChanges();
        }

        private void DbViewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //sel_dbviewer = DbViewer.SelectedCells[0];
        }
    }
}
