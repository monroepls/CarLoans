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
using Excel = Microsoft.Office.Interop.Excel;
using CarLoans.AddEditPages;

namespace CarLoans.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            if (Authorization.Globals.Role == 1) // код, который скрывает некоторые элементы для обычного сотрудника
            {
                BtnDelete.Visibility = Visibility.Visible;
                Gridddd.Visibility = Visibility.Visible;
            }
            else
            {
                BtnDelete.Visibility = Visibility.Collapsed;
                Gridddd.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Редактировать", которая открывает страницу с редактированием
        {
            Manager.MainFrame.Navigate(new AddPageForClients((sender as Button).DataContext as Clients));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Удалить" и за удаления элемента из таблицы
        {
            var clientsForRemoving = DGridClients.SelectedItems.Cast<Clients>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientsForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AvtokreditovanieEntities.GetContext().Clients.RemoveRange(clientsForRemoving);
                    AvtokreditovanieEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridClients.ItemsSource = AvtokreditovanieEntities.GetContext().Clients.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Добавить", которая открывает страницу с добавлением
        {
            Manager.MainFrame.Navigate(new AddPageForClients(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) // код обновляющий таблицу, чтобы изменения были видны
        {
            if (Visibility == Visibility.Visible)
            {
                AvtokreditovanieEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridClients.ItemsSource = AvtokreditovanieEntities.GetContext().Clients.ToList();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Назад
        {
            Manager.MainFrame.GoBack();
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e) // код отвечающий за экспорт данных в Excel таблицу
        {
            var application = new Excel.Application();
            application.SheetsInNewWorkbook = 1;

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;

            Excel.Worksheet worksheet = application.Worksheets.Item[1];
            worksheet.Name = "Клиенты";

            worksheet.Cells[1][startRowIndex] = "Номер клиента";
            worksheet.Cells[2][startRowIndex] = "Ф.И.О.";
            worksheet.Cells[3][startRowIndex] = "Дата платежа";
            worksheet.Cells[4][startRowIndex] = "Благонадежность";
            worksheet.Cells[5][startRowIndex] = "Статус кредита";
            worksheet.Cells[6][startRowIndex] = "Автомобиль";
            worksheet.Cells[7][startRowIndex] = "Размер кредита";
            worksheet.Cells[8][startRowIndex] = "Комментарий";

            startRowIndex++;

            var loanApplic = AvtokreditovanieEntities.GetContext().Clients.ToList();

            foreach (var loans in loanApplic)
            {
                worksheet.Cells[1][startRowIndex] = loans.Id;
                worksheet.Cells[2][startRowIndex] = loans.FIO;
                worksheet.Cells[3][startRowIndex] = loans.PaymentDate;
                worksheet.Cells[4][startRowIndex] = loans.Trustworthiness;
                worksheet.Cells[5][startRowIndex] = loans.LoanStatus;
                worksheet.Cells[6][startRowIndex] = loans.Car;
                worksheet.Cells[7][startRowIndex] = loans.AmountOfCredit;
                worksheet.Cells[8][startRowIndex] = loans.Comment;


                startRowIndex++;
            }

            Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[6][startRowIndex]];
            sumRange.Merge();
            sumRange.Value = "Всего клиентов: ";
            sumRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

            worksheet.Cells[7][startRowIndex] = loanApplic.Count();


            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[8][startRowIndex]];
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle =
            rangeBorders.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous;

            worksheet.Columns.AutoFit();

            application.Visible = true;
        }

    }
}
