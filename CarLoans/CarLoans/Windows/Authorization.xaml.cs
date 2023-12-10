using CarLoans.Windows;
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
using System.Windows.Threading;
using CarLoans.Models;
using CarLoans.Classes;

namespace CarLoans
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        string code;
        public Authorization()
        {
            InitializeComponent();
        }
        public static class Globals
        {
            public static int Role;

            public static User userinfo { get; set; }
        }

        private void gencode()// код отвечающий за генерацию кода
        {
            code = null;
            Random random = new Random();
            string[] massiveCharacter = new string[] {"1", "2","3","4","5","6","7", "8", "9", "a", "B", "c", "d", "E", "F", "j", "f", "z", "f", "S",
            "t", "T", "Y","y","D","d","l","L","H","h","A","m","M","n","N", "@", "!", "?", "*"};
            for (int i = 0; i < 4; i++)
            {
                code += massiveCharacter[random.Next(0, massiveCharacter.Length)];
            }
            if (MessageBox.Show(code.ToString(), "Code", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                timer.Interval = TimeSpan.FromSeconds(10);
                timer.Tick += Timer_Tick;
                timer.Start();

                CodeBox.IsEnabled = true;
                Login.IsEnabled = false;
                RefreshKnopka.IsEnabled = true;
                BtnSingInl.IsEnabled = true;

            }
        }

        private void Login_KeyUp(object sender, KeyEventArgs e)// код отвечающий за поле "Логин"
        {
            if (e.Key == Key.Enter)
            {
                var Log = Encryption1.EncryptionPass(Login.Text);
                using (var db = new AvtokreditovanieEntities())
                {
                    var login = db.User.AsNoTracking().FirstOrDefault(l => l.Login == Log);
                    if (login == null)
                    {
                        MessageBox.Show("Неверный логин");
                    }
                    else
                    {
                        BtnSingInl.IsEnabled = false;
                        Password.IsEnabled = true;
                        Login.IsEnabled = false;
                        CodeBox.IsEnabled = false;
                        RefreshKnopka.IsEnabled = false;
                        Password.Focus();
                    }
                }
            }
        }



        private void Password_KeyUp(object sender, KeyEventArgs e)// код отвечающий за поле "Пароль"
        {
            if (e.Key == Key.Enter)
            {
                var Pass = Encryption1.EncryptionPass(Password.Password);
                var Log = Encryption1.EncryptionPass(Login.Text);
                using (var db = new AvtokreditovanieEntities())
                {
                    var login = db.User.AsNoTracking().FirstOrDefault(l => l.Login == Log & l.Password == Pass);
                    if (login == null)
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                    else
                    {
                        Password.IsEnabled = false;
                        CodeBox.IsEnabled = true;
                        Login.IsEnabled = false;
                        RefreshKnopka.IsEnabled = false;
                        BtnSingInl.IsEnabled = false;
                        gencode();
                        CodeBox.Focus();
                    }
                }
            }
        }
        void Timer_Tick(Object sender, EventArgs e)
        {
            code = null;
            MessageBox.Show("Время написания кода вышло. Повторите попытку");
            timer.Stop();
        }

        private void Sign_In(object sender, RoutedEventArgs e)// Код отвечающий за вход
        {
            var Pass = Encryption1.EncryptionPass(Password.Password);
            var Log = Encryption1.EncryptionPass(Login.Text);
            using (var db = new AvtokreditovanieEntities())
            {

                var auth = db.User.AsNoTracking().FirstOrDefault(m => m.Login == Log && m.Password == Pass);
                if (auth != null & code == CodeBox.Text)
                {
                    timer.Stop();
                    Globals.Role = auth.RoleId;
                    Globals.userinfo = auth;
                    MainNewsWindow winavto = new MainNewsWindow();
                    MessageBox.Show("Добро пожаловать");
                    winavto.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный код, повторите попытку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    timer.Stop();
                }
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)// код отвечающий за кнопку "Обновить"
        {
            timer.Stop();
            gencode();
            CodeBox.Focus();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void CodeBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Sign_In(BtnSingInl, e);
            }
        }

        private void ClearBtn(object sender, RoutedEventArgs e)// код отвечающий за кнопку "Отмена"
        {
            Login.Clear();
            Password.Clear();
            CodeBox.Clear();
            Login.IsEnabled = true;
            Password.IsEnabled = false;
            CodeBox.IsEnabled = false;
            BtnSingInl.IsEnabled = false;
            RefreshKnopka.IsEnabled = false;
            Login.Focus();
        }
    }
}
