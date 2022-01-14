using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AfanasevGlava10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] astrLogicalDrives = System.IO.Directory.GetLogicalDrives();
            foreach (string disk in astrLogicalDrives)
                listBox1.Items.Add(disk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] astrLogicalDrives = System.Environment.GetLogicalDrives();
            foreach (string disk in astrLogicalDrives)
                listBox1.Items.Add(disk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Выводим информацию о диске
            System.IO.DriveInfo drv = new System.IO.DriveInfo(@"d:\");
            listBox1.Items.Clear();
            listBox1.Items.Add("Диск: " + drv.Name);

            if (drv.IsReady)
            {
                listBox1.Items.Add("Тип диска: " + drv.DriveType.ToString());
                listBox1.Items.Add("Файловая система: " +
                drv.DriveFormat.ToString());
                listBox1.Items.Add("Свободное место на диске: " +
                drv.AvailableFreeSpace.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Получим список папок на диске D:
            listBox1.Items.Clear();
            string[] astrFolders = System.IO.Directory.GetDirectories(@"d:\");
            foreach (string folder in astrFolders)
                listBox1.Items.Add(folder);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            // Получим список папок, где встречается буквосочетание pro
            listBox1.Items.Clear();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@"d:\");
            System.IO.DirectoryInfo[] folders = di.GetDirectories("*pro*");
            foreach (System.IO.DirectoryInfo maskdirs in folders)
                listBox1.Items.Add(maskdirs);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Получим информацию о свойствах папки 

 System.IO.DirectoryInfo dir = new
 System.IO.DirectoryInfo(@"c:\wutemp");
            listBox1.Items.Clear();
            listBox1.Items.Add("Проверка папки: " + dir.Name);
            listBox1.Items.Add("Родительская папка: " + dir.Parent.Name);
            listBox1.Items.Add("Папка существует: ");
            listBox1.Items.Add(dir.Exists.ToString());
            if (dir.Exists)
            {
                listBox1.Items.Add("Папка создана: ");
                listBox1.Items.Add(dir.CreationTime.ToString());
                listBox1.Items.Add("Папка изменена: ");
                listBox1.Items.Add(dir.LastWriteTime.ToString());
                listBox1.Items.Add("Время последнего доступа: ");
                listBox1.Items.Add(dir.LastAccessTime.ToString());
                listBox1.Items.Add("Атрибуты папки: ");
                listBox1.Items.Add(dir.Attributes.ToString());
                listBox1.Items.Add("Папка содержит: " +
                dir.GetFiles().Length.ToString() + " файла");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            System.IO.DirectoryInfo dir = new
            System.IO.DirectoryInfo(@"d:\Notepad++");
            textBox1.Text = "Общий размер: " +
            GetDirectorySize(dir, true).ToString() + " байт.";
            this.Cursor = Cursors.Default;
        }
        static long GetDirectorySize(System.IO.DirectoryInfo directory,
 bool includeSubdir)
        {
            long totalSize = 0;
            // Считаем все файлы
            System.IO.FileInfo[] files = directory.GetFiles();
            foreach (System.IO.FileInfo file in files)
            {
                totalSize += file.Length;
            }
 
 // Считаем все подпапки
 if (includeSubdir)
            {
                System.IO.DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (System.IO.DirectoryInfo dir in dirs)
                {
                    totalSize += GetDirectorySize(dir, true);
                }
            }
            return totalSize;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] astrFiles = System.IO.Directory.GetFiles(@"c:\");
            listBox1.Items.Add("Всего файлов: " + astrFiles.Length);
            foreach (string file in astrFiles)
                listBox1.Items.Add(file);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            // задаем папку верхнего уровня
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            // Заголовок в диалоговом окне
            fbd.Description = "Выберите папку";
            // Не выводим кнопку Новая папка
            fbd.ShowNewFolderButton = false;
            // Получаем папку, выбранную пользователем
            if (fbd.ShowDialog() == DialogResult.OK)
                this.Text = fbd.SelectedPath;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            // Полный путь к файлу
            string fileNamePath = @"c:\windows\system32\notepad.exe";
            // Имя файла с расширением
            listBox1.Items.Add(System.IO.Path.GetFileName(fileNamePath));
            // Имя файла без расширения
            listBox1.Items.Add(
            System.IO.Path.GetFileNameWithoutExtension(fileNamePath));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Выводим информацию о файле.
            System.IO.FileInfo file = new
            System.IO.FileInfo(@"c:\wutemp\text.txt");
            listBox1.Items.Clear();
            listBox1.Items.Add("Свойства для файла: " + file.Name);
            listBox1.Items.Add("Наличие файла: " + file.Exists.ToString());
            if (file.Exists)
            {
                listBox1.Items.Add("Время создания файла: ");
                listBox1.Items.Add(file.CreationTime.ToString());
                listBox1.Items.Add("Последнее изменение файла: ");
                listBox1.Items.Add(file.LastWriteTime.ToString());
                listBox1.Items.Add("Файл был открыт в последний раз: ");
                listBox1.Items.Add(file.LastAccessTime.ToString());
                listBox1.Items.Add("Размер файла (в байтах): ");
                listBox1.Items.Add(file.Length.ToString());
                listBox1.Items.Add("Атрибуты файла: ");
                listBox1.Items.Add(file.Attributes.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            System.Diagnostics.FileVersionInfo info =
            System.Diagnostics.FileVersionInfo.GetVersionInfo(
            @"C:\windows\system32\mspaint.exe");
            // Выводим информацию о выбранном файле
            listBox1.Items.Add("Выбранный файл: " + info.FileName);
            listBox1.Items.Add("Product Name: " + info.ProductName);
            listBox1.Items.Add("Product Version: " + info.ProductVersion);
            listBox1.Items.Add("Company Name: " + info.CompanyName);
            listBox1.Items.Add("File Version: " + info.FileVersion);
            listBox1.Items.Add("File Description: " + info.FileDescription);
            listBox1.Items.Add("Original Filename: " + info.OriginalFilename);
            listBox1.Items.Add("Legal Copyright: " + info.LegalCopyright);
            listBox1.Items.Add("InternalName: " + info.InternalName);
            listBox1.Items.Add("IsDebug: " + info.IsDebug);
            listBox1.Items.Add("IsPatched: " + info.IsPatched);
            listBox1.Items.Add("IsPreRelease: " + info.IsPreRelease);
            listBox1.Items.Add("IsPrivateBuild: " + info.IsPrivateBuild);
            listBox1.Items.Add("IsSpecialBuild: " + info.IsSpecialBuild);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string fileName = @"c:\wutemp\text.txt";
            if (System.IO.File.Exists(fileName))
            {
                MessageBox.Show("Указанный файл уже существует.", fileName);
                return;
            }
            System.IO.StreamWriter sr = System.IO.File.CreateText(fileName);
            sr.WriteLine("Раз, два, три, четыре, пять");
            sr.WriteLine("1, 2, 3. 9 1/2 и так далее");
            sr.WriteLine("Я изучаю {0} и {1}.", "C#", "Visual Basic");
            sr.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            // Создаем временный файл
            listBox1.Items.Add(System.IO.Path.GetTempFileName());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string fileName = @"d:\wutemp\test.bin";
            // Создадим новый пустой файл
            if (System.IO.File.Exists(fileName))
            {
                MessageBox.Show("Указанный файл уже существует!", fileName);
                return;
            }
            System.IO.FileStream fs = new System.IO.FileStream(fileName,
            System.IO.FileMode.CreateNew);
            // Запишем данные в файл
            System.IO.BinaryWriter w = new System.IO.BinaryWriter(fs);

            for (int i = 0; i < 11; i++)
            {
                w.Write((int)i);
            }
            w.Close();
            fs.Close();

 // Попытаемся прочитать записанное
 fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open,
 System.IO.FileAccess.Read);
            System.IO.BinaryReader binread = new System.IO.BinaryReader(fs);
            // считываем данные из test.bin
            for (int i = 0; i < 11; i++)
            {
                MessageBox.Show(binread.ReadInt32().ToString());
            }
            w.Close();
        }
    }
    
    
}
