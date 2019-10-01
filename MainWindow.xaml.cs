using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;



namespace FolderWithDate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        string currentDirectory;
        string folderName;
        string folderFullPath;
        public MainWindow()
        {
            InitializeComponent();
            currentDirectory = Directory.GetCurrentDirectory();
            textBox.KeyDown += new KeyEventHandler(tb_keydown);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void tb_keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                createFolder();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            createFolder();

        }

        private void createFolder()
        {
            // "yyyyMMdd_HHmmss"
            folderName = DateTime.Now.ToString("yyyyMMdd") + " - " + textBox.Text;
            folderName = GetSafeFilename(folderName);
            folderFullPath = currentDirectory + "\\" + folderName;
            Directory.CreateDirectory(folderFullPath);
            System.Windows.Application.Current.Shutdown();
        }


        public string GetSafeFilename(string filename)
        {

            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));

        }




    }
}
