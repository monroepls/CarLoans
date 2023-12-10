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
using CarLoans.Classes;
using CarLoans.Pages;

namespace CarLoans.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainNewsWindow.xaml
    /// </summary>
    public partial class MainNewsWindow : Window
    {
        public MainNewsWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainNewsPage());
            Manager.MainFrame = MainFrame;

            if (Authorization.Globals.Role == 1)  //Код отвечающий за показ элементов (некоторые элементы скрыты для обычного сотрудника)
            {
                Sotrudniki.Visibility = Visibility.Visible;
                Clients.Visibility = Visibility.Visible;
            }
            else
            {
                Sotrudniki.Visibility = Visibility.Collapsed;
                Clients.Visibility = Visibility.Collapsed;
            }


        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void Client_click(object sender, RoutedEventArgs e)// код отвечающий за кнопку "Клиенты"
        {
            Manager.MainFrame.Navigate(new ClientsPage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Выход"
        {
            Authorization exitwin = new Authorization();
            exitwin.Show();
            Close();
        }

        private void Go_to_sotrudniki(object sender, RoutedEventArgs e)// код отвечающий за кнопку "Сотрудники"
        {
           Manager.MainFrame.Navigate(new EmployeesPage());
        }

        private void go_to_avtorizaciya(object sender, RoutedEventArgs e)// код отвечающий за кнопку "Главное меню"
        {
            Manager.MainFrame.Navigate(new MainNewsPage());

        }

        private void go_to_zayavki(object sender, RoutedEventArgs e)// код отвечающий за кнопку "Заявки на кредит"
        {
            Manager.MainFrame.Navigate(new LoansApplicationsPage());
        }

        private void go_to_cars(object sender, RoutedEventArgs e)// код отвечающий за кнопку "Автомобили"
        {
           Manager.MainFrame.Navigate(new CarsPage());
        }
    }
}
