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
    /// Логика взаимодействия для CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        public CarsPage()
        {
            InitializeComponent();
            DGridCars.ItemsSource = AvtokreditovanieEntities.GetContext().Cars.ToList();
            if (Authorization.Globals.Role == 1) // код, который скрывает некоторые элементы для обычного сотрудника
            {
                BtnAdd.Visibility = Visibility.Visible;
                BtnDelete.Visibility = Visibility.Visible;
                Gridddd.Visibility = Visibility.Visible;
            }
            else
            {
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
                Gridddd.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Добавить", которая открывает страницу с добавлением
        {
            Manager.MainFrame.Navigate(new AddForCars(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Редактировать", которая открывает страницу с редактированием
        {
            Manager.MainFrame.Navigate(new AddForCars((sender as Button).DataContext as Cars));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e) // код отвечающий за кнопку "Удалить" и за удаления элемента из таблицы
        {
            var carsforremoving = DGridCars.SelectedItems.Cast<Cars>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {carsforremoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AvtokreditovanieEntities.GetContext().Cars.RemoveRange(carsforremoving);
                    AvtokreditovanieEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridCars.ItemsSource = AvtokreditovanieEntities.GetContext().Cars.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) // код обновляющий таблицу, чтобы изменения были видны
        {
            AvtokreditovanieEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridCars.ItemsSource = AvtokreditovanieEntities.GetContext().Cars.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)// код отвечающий за кнопку "Назад
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
            worksheet.Name = "Автомобили";

            worksheet.Cells[1][startRowIndex] = "Номер автомобиля";
            worksheet.Cells[2][startRowIndex] = "Название модели";
            worksheet.Cells[3][startRowIndex] = "Стоимость";
            worksheet.Cells[4][startRowIndex] = "Год выпуска";
            worksheet.Cells[5][startRowIndex] = "Двигатель";
            worksheet.Cells[6][startRowIndex] = "Тип автомобиля";


            startRowIndex++;

            var loanApplic = AvtokreditovanieEntities.GetContext().Cars.ToList();

            foreach (var loans in loanApplic)
            {
                worksheet.Cells[1][startRowIndex] = loans.Id;
                worksheet.Cells[2][startRowIndex] = loans.ModelName;
                worksheet.Cells[3][startRowIndex] = loans.Price;
                worksheet.Cells[4][startRowIndex] = loans.YearOfIssue;
                worksheet.Cells[5][startRowIndex] = loans.Engine;
                worksheet.Cells[6][startRowIndex] = loans.VehicleType;



                startRowIndex++;
            }

            Excel.Range sumRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[5][startRowIndex]];
            sumRange.Merge();
            sumRange.Value = "Всего автомобилей: ";
            sumRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

            worksheet.Cells[6][startRowIndex] = loanApplic.Count();


            Excel.Range rangeBorders = worksheet.Range[worksheet.Cells[1][1], worksheet.Cells[6][startRowIndex]];
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
