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
    /// Логика взаимодействия для AddForCars.xaml
    /// </summary>
    public partial class AddForCars : Page
    {
        private Cars _currentCars = new Cars();
        public AddForCars(Cars selectedCars)
        {
            InitializeComponent();
            if (selectedCars != null)
                _currentCars = selectedCars;

            DataContext = _currentCars;
        }

        private void Button_Click_save(object sender, RoutedEventArgs e) // код отвечающий за добавление, сохранение нового элемента в список
        {

            StringBuilder errors = new StringBuilder();



            if (string.IsNullOrWhiteSpace(_currentCars.ModelName))
                errors.AppendLine("Укажите название модели");

            if (string.IsNullOrWhiteSpace(_currentCars.Price))
                errors.AppendLine("Укажите цену автомобиля");

            if (Date.SelectedItem == null)
                errors.AppendLine("Укажите дату производства");

            if (string.IsNullOrWhiteSpace(_currentCars.Engine))
                errors.AppendLine("Укажите двигатель автомобиля");

            if (string.IsNullOrWhiteSpace(_currentCars.VehicleType))
                errors.AppendLine("Укажите тип автомобиля");






            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentCars.Id == 0)
                AvtokreditovanieEntities.GetContext().Cars.Add(_currentCars);


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
    }
}
