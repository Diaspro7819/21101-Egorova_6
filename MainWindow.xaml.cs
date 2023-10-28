using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
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

namespace _21101_Egorova_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // gl - гласные буквы
        bool Bool = true;


        // Проверяем, что все символы в строке text являются буквами и имеют значение меньше или равное символу 'z'.
        private bool inEnglish(string text)
        {
            // Проверяем, что все символы в строке text являются буквами и имеют значение меньше или равное символу 'z'.

            Bool = !string.IsNullOrEmpty(text) && text.All(c => char.IsLetter(c) && c <= 'z');
            return Bool;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем значение из textbox
                string text_str = textbox1.Text;

                // Удаляем лишние пробелы и оставляем только один пробел между словами
                text_str = string.Join(" ", text_str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

                // Проверяем, что введены только английские буквы
                if (!inEnglish(text_str))
                {
                    MessageBox.Show("Пожалуйста, введите только английские буквы.");
                    textbox1.Clear();
                    return;
                }
                // Разделяем его на слова
                string[] words = text_str.Split(' ');

                // считем кол-во гласных букв 
                int count_gl = 0;
                for (int i = 0; i < text_str.Length; i++)
                {
                    char gl = text_str[i];
                    if (gl == 'A' || gl == 'a' ||
                        gl == 'E' || gl == 'e' ||
                        gl == 'I' || gl == 'i' ||
                        gl == 'O' || gl == 'o' ||
                        gl == 'U' || gl == 'u')
                    {
                        count_gl++; // счетчик
                    }
                }
                // Найти самое длинное слово в предложении
                string word = words[0];
                for (int i = 1; i < words.Length; i++)
                {
                    if (words[i].Length > word.Length)
                    {
                        word = words[i];
                    }
                }     
                lb_word.Content = word.ToString();
                lb_count.Content = count_gl.ToString();

                // Отобразить результаты в метке
                MessageBox.Show($"Количество гласных букв в предложении: {count_gl}" +
                    $"\nСамое длинное слово в предложении: {word}");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
            
        }
        
    }
}
