using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public Log()
        {
            InitializeComponent();
            Group.CreateGroups();

            using(var db = new DBContext())
            {
                db.Groups.ToList().ForEach(g => groups.Items.Add(g.GetCode()));
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            groups.Items.Clear();
            using (var db = new DBContext())
            {
                db.Groups.ToList().ForEach(i =>
                {
                    if (i.GetCode().ToString().Contains(filter.Text))
                        groups.Items.Add(i.GetCode());
                });
            }
        }
    }
}
