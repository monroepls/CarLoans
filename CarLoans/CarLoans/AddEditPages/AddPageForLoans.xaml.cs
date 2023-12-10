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
    /// Логика взаимодействия для AddPageForLoans.xaml
    /// </summary>
    public partial class AddPageForLoans : Page
    {
        private LoanApplications _currentLoan = new LoanApplications();
        public AddPageForLoans(LoanApplications selectedLoan)
        {
            InitializeComponent();
            if (selectedLoan != null)
                _currentLoan = selectedLoan;

            DataContext = _currentLoan;
            ComboCars.ItemsSource = AvtokreditovanieEntities.GetContext().Cars.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_save(object sender, RoutedEventArgs e) // код отвечающий за добавление, сохранение нового элемента в список
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentLoan.FIO))
                errors.AppendLine("Укажите имя клиента");

            if (dpDate2.SelectedDate == null)
                errors.AppendLine("Укажите дату рождения");

            if (string.IsNullOrWhiteSpace(_currentLoan.TCPNumber))
                errors.AppendLine("Укажите номер ПТС");

            if (string.IsNullOrWhiteSpace(_currentLoan.Income))
                errors.AppendLine("Укажите доходы клиента");

            if (string.IsNullOrWhiteSpace(_currentLoan.Income))
                errors.AppendLine("Укажите доходы клиента");

            if (_currentLoan.Car == null)
                errors.AppendLine("Выберите автомобиль клиента");

            if (dpDate.SelectedDate == null)
                errors.AppendLine("Укажите дату заявки");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentLoan.Id == 0)
                AvtokreditovanieEntities.GetContext().LoanApplications.Add(_currentLoan);


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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboCars_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}