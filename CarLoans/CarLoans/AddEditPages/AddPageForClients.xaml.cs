using CarLoans.Classes;
using CarLoans.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarLoans.AddEditPages
{
    /// <summary>
    /// Логика взаимодействия для AddPageForClients.xaml
    /// </summary>
    public partial class AddPageForClients : Page
    {

        private Clients _currentClients = new Clients();
        public AddPageForClients(Clients selectedClient)
        {
            InitializeComponent();
            if (selectedClient != null)
                _currentClients = selectedClient;

            DataContext = _currentClients;
            ComboCars.ItemsSource = AvtokreditovanieEntities.GetContext().Cars.ToList();
            ComboDoverennsot.ItemsSource = AvtokreditovanieEntities.GetContext().ClientTrustworthiness.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_save(object sender, RoutedEventArgs e) // код отвечающий за добавление, сохранение нового элемента в список
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentClients.FIO))
                errors.AppendLine("Укажите имя клиента");

            if (string.IsNullOrWhiteSpace(_currentClients.AmountOfCredit))
                errors.AppendLine("Укажите размер кредита");

            if (dpDate.SelectedDate == null)
                errors.AppendLine("Укажите дату платежа");

            if (string.IsNullOrWhiteSpace(_currentClients.LoanStatus))
                errors.AppendLine("Укажите статус кредита");

            if (_currentClients.Trustworthiness == null)
                errors.AppendLine("Выберите благонадежность клиента");

            if (_currentClients.Car == null)
                errors.AppendLine("Выберите автомобиль клиента");



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentClients.Id == 0)
                AvtokreditovanieEntities.GetContext().Clients.Add(_currentClients);


            try
            {
                AvtokreditovanieEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ComboDoverennsot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
