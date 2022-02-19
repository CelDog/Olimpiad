using Olimpiad;
using Olympiad;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Controls;

namespace Olimpiad
{
    internal class DataBaseControl
    {
        OlimpContext context; 

        public DataBaseControl()
        {
            context = new OlimpContext();
        }

        public void ConnectToDB(ref DataGrid control, string table)
        {

            switch (table)
            {
                case "Cities":
                    {
                        control.ItemsSource = context.Cities.ToList();

                        break;
                    }

                case "Countries":
                    {
                        control.ItemsSource = context.Countries.ToList();

                        break;
                    }

                case "KindSports":
                    {
                        control.ItemsSource = context.KindSports.ToList();

                        break;
                    }

                case "Participants":
                    {
                        control.ItemsSource = context.Participants.ToList();

                        break;
                    }

                case "Results":
                    {
                        control.ItemsSource = context.Results.ToList();

                        break;
                    }

                case "OlimpInfoes":
                    {
                        control.ItemsSource = context.OlimpInfos.ToList();

                        break;
                    }
            }
        }

        //public void ConnectToDB(ref ComboBox control, string table)
        //{

        //    switch (table)
        //    {
        //        case "Cities":
        //            {
        //                control.ItemsSource = context.Cities.ToList();

        //                control.DisplayMemberPath = "Cities";
        //                control.SelectedValuePath = ""

        //                break;
        //            }

        //        case "Countries":
        //            {
        //                control.ItemsSource = context.Countries.ToList();

        //                break;
        //            }

        //        case "KindSports":
        //            {
        //                control.ItemsSource = context.KindSports.ToList();

        //                break;
        //            }

        //        case "Participants":
        //            {
        //                control.ItemsSource = context.Participants.ToList();

        //                break;
        //            }

        //        case "Results":
        //            {
        //                control.ItemsSource = context.Results.ToList();

        //                break;
        //            }
        //    }
        //}

        public string GetConnect()
        {
            return context.Database.Connection.ConnectionString;
        }

        public OlimpContext GetContext()
        {
            return context;
        }
    }
}
