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
    /// Логика взаимодействия для LoansApplicationsPage.xaml
    /// </summary>
    public partial class LoansApplicationsPage : Page
    {
        public LoansApplicationsPage()
        {
            InitializeComponent();
            DGridZayavki.ItemsSource = AvtokreditovanieEntities.GetContext().LoanApplications.ToList();
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

        private void BtnDelete_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Удалить" и за удаления элемента из таблицы
        {
            var loansforremoving = DGridZayavki.SelectedItems.Cast<LoanApplications>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {loansforremoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AvtokreditovanieEntities.GetContext().LoanApplications.RemoveRange(loansforremoving);
                    AvtokreditovanieEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridZayavki.ItemsSource = AvtokreditovanieEntities.GetContext().LoanApplications.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)  // код отвечающий за кнопку "Добавить", которая открывает страницу с добавлением
        {
            Manager.MainFrame.Navigate(new AddPageForLoans(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Редактировать", которая открывает страницу с редактированием
        {
            Manager.MainFrame.Navigate(new AddPageForLoans((sender as Button).DataContext as LoanApplications));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) // код обновляющий таблицу, чтобы изменения были видны
        {
            if (Visibility == Visibility.Visible)
            {
                AvtokreditovanieEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridZayavki.ItemsSource = AvtokreditovanieEntities.GetContext().LoanApplications.ToList();
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
            worksheet.Name = "Заявки на кредит";

            worksheet.Cells[1][startRowIndex] = "Номер заявки";
            worksheet.Cells[2][startRowIndex] = "Дата заявки";
            worksheet.Cells[3][startRowIndex] = "Сумма кредита";
            worksheet.Cells[4][startRowIndex] = "ПТС-номер";
            worksheet.Cells[5][startRowIndex] = "Доходы";
            worksheet.Cells[6][startRowIndex] = "Ф.И.О.";
            worksheet.Cells[7][startRowIndex] = "Дата рождения";
            worksheet.Cells[8][startRowIndex] = "Автомобиль";

            startRowIndex++;

            var loanApplic = AvtokreditovanieEntities.GetContext().LoanApplications.ToList();

            foreach (var loans in loanApplic)
            {
                worksheet.Cells[1][startRowIndex] = loans.Id;
                worksheet.Cells[2][startRowIndex] = loans.ApplicationDate;
                worksheet.Cells[3][startRowIndex] = loans.AmountOfCredit;
                worksheet.Cells[4][startRowIndex] = loans.TCPNumber;
                worksheet.Cells[5][startRowIndex] = loans.Income;
                worksheet.Cells[6][startRowIndex] = loans.FIO;
                worksheet.Cells[7][startRowIndex] = loans.DateOfBirth;
                worksheet.Cells[8][startRowIndex] = loans.Car;


                startRowIndex++;
            }

            Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[7][startRowIndex]];
            sumRange.Merge();
            sumRange.Value = "Всего заявок на кредит: ";
            sumRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

            worksheet.Cells[8][startRowIndex] = loanApplic.Count();


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
