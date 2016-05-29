using System;
using System.IO;
using System.Diagnostics;

using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.Windows.Input;
	
namespace PortGui02
{
    public partial class Form1 : Form //, ISerializable
    {
        List<string> listExePath = new List<string>();//создаём массив иконок
        List<PictureBox> Pic = new List<PictureBox>();
        //Pic[0].Controls.
        Thread MousePositionThread;
        public Form1()
        {
            InitializeComponent();


            try//задаём размеры окна
            {

                /*
                  429
                  807
                 */
                StreamReader file = new StreamReader("HeightWidth.txt");
                this.Height = int.Parse(file.ReadLine());
                //if (this.Height < 300) this.Height = 429;//когда выкл комп он записывает нулевые (32,142) ширину и высоту
                this.Width = int.Parse(file.ReadLine()); file.Close();
                if (this.Width < 500||this.Height < 300) {this.Width = 720;this.Height = 600;}
                
            }
            catch { } ///finally { file.Close(); }
            //////////////////////////////
            try
		            {
		            string MyDirPath = FoundMyDirPath();//находим папку со всеми прогами
		            Found_writeToListExePath(MyDirPath);//записываем все пути к Exe-шкам
		            RemoveUnnecessaryExe(MyDirPath);		            
		            //////////////////////////////////////////
		            for (int i = 0; i < listExePath.Count; i++)
		            {
		                if (listExePath[i] != null)
		                {
		                    System.Drawing.Icon myIcon = System.Drawing.Icon.ExtractAssociatedIcon(listExePath[i]);//иконку проги достаём из пути
		                   // System.Drawing.Icon ttt=System.Drawing.Icon.ExtractAssociatedIcon(listExePath[i]);
		                    //	ttt=myIcon;
		                    Pic.Add(new PictureBox());
		                    Pic[i].Image = myIcon.ToBitmap();//записываем в очередной PictureBox иконку (предварительно "отконвертировав")
		                    tableLayoutPanel1.Controls.Add(Pic[i]);//первый столбец ,первая строка
		                    tableLayoutPanel1.AutoScroll=true;
		                    Pic[i].Tag = i;//просто i не получается в событиях использовать(оно всегда равно 66)
		                    Pic[i].AllowDrop = true;
		                    /////////////////////////////////////////                 
		                    Pic[i].MouseClick += (b, eArgs) =>//запускаем прогу
		                    {
		                    	
		                        int x = int.Parse((b as PictureBox).Tag.ToString());//находим индекс - альтернатива Pic[i]- не работает
		                        //ПКМ!, то пусть откроет проводник с прогой!
		                        if ((eArgs as System.Windows.Forms.MouseEventArgs).Button == System.Windows.Forms.MouseButtons.Right)
								{
		                        	Process PrFolder = new Process();
									ProcessStartInfo psi = new ProcessStartInfo();
									string file = listExePath[x];  
									psi.CreateNoWindow = true;
									psi.WindowStyle = ProcessWindowStyle.Normal;
									psi.FileName = "explorer";  
									psi.Arguments = @"/n, /select, " + file;
									PrFolder.StartInfo = psi;
									PrFolder.Start();
								    return;								    
								}
		                        if (checkBox1.Checked)
		                        {
		                            StreamWriter f = new StreamWriter("RemoveExe.txt", true);//дозапись
		                            f.WriteLine(listExePath[x].Remove(0, MyDirPath.Length));
		                            listExePath[x] = null;  //--///--/-/
		                            Pic[x].Dispose();
		                            f.Close();
		                        }
		                        else
		                        {
		                            ProcessStartInfo stInfo = new ProcessStartInfo(listExePath[x]);
		                            //stInfo.FileName = "C:\\Users\\Public\\Music\\Sample Music\\Kalimba.mp3";
		                            //stInfo.Verb ="open to exe";
		                            Process proc = new Process();  //создаем новый процесс
		                            proc.StartInfo = stInfo;
		                            proc.Start();//Запускаем процесс
		
		                        }
		                    };
		                    Pic[i].MouseEnter += (b, e) =>//ПОДСКАЗКИ при наведении
		                    {
		                        int x = int.Parse((b as PictureBox).Tag.ToString());//находим индекс - альтернатива Pic[i]- не работает
		                        toolTip1.SetToolTip(Pic[x], listExePath[x].Remove(0, listExePath[x].LastIndexOf("\\") + 1));//последнее имя папки EXE, +1 чтоб лишних знаков небыло ("\")
		                    };
		                    /////////////////////////////////////////////////////////////////////////////////                                
		                    Pic[i].DragEnter += (b, e) =>//Разрешаем Drop только файлам
		                    {
		                        e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ?
		                           DragDropEffects.All : DragDropEffects.None;
		                    };
		                    Pic[i].DragDrop += (object b, DragEventArgs e) =>//Извлекаем имя перетаскиваемого файла
		                    {
		                        string[] strings = (string[])e.Data.GetData(DataFormats.FileDrop, true);
		
		                        int x = int.Parse((b as PictureBox).Tag.ToString());//находим индекс - альтернатива Pic[i]- не работает
		
		                        Process.Start(listExePath[x], strings[0]);
		                    };
		                }
		                else Pic.Add(null);
		            }
		
		            button1.Click += (object sender, EventArgs e) =>
		        {
		            if (MousePositionThread != null)
		            {
		                MousePositionThread.Abort();
		                MousePositionThread = null;
		            }
		            else
		            {
		                MousePositionThread = new Thread((send) =>
		                {//Считывает координаты мышки в кнопку справа(скрыта поумолчанию)
		                    while (true)
		                    {
		                        button1.Text = Form1.MousePosition.ToString();
		                    }
		                });
		                MousePositionThread.Start();
		            }
		            };
        }
        catch(Exception Ex) {MessageBox.Show(Ex.Message);}/**/
        }/*
        private string MousePositionToString()
        {
            while (true)
            {
                button1.Text = Form1.MousePosition.ToString();
            }
        }/**/
        private string FoundMyDirPath()
        {
            string MyDirPath = "myFavoritePrograms";//как называется папку с программами?
            string firstItemOfDir=null;
				
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (var disc in drives)
            {
                DirectoryInfo dir = new DirectoryInfo(disc.ToString());  
                //dir.Extension.//ищем полный путь к папке с портабельными прогами и записываем её в MyDirPath
                try
                {
                    foreach (var item in dir.GetDirectories())
                        if (item.Name == MyDirPath)
	                    {
                    		if(firstItemOfDir==null)
		                            	firstItemOfDir=item.FullName;
                    		else {
								using (var dialog = new FolderBrowserDialog())
							    if (dialog.ShowDialog() == DialogResult.OK)
							        firstItemOfDir = dialog.SelectedPath;
                    		}
	                    }
                    
                }
                catch { }
            }
            return firstItemOfDir;//если не нашли то нулл
        }

        private void Found_writeToListExePath(string MyDirPath)
        {
            string[] fullFilesPath;

            string[] fullDirPath = Directory.GetDirectories(MyDirPath);//забрали из папкb все пути папок с exe
            foreach (var DirPath in fullDirPath) //перебираем все папки в папке PORT
            {       
                 fullFilesPath = Directory.GetFiles(DirPath, "*.exe");//ищем все exe в папке str
                foreach(var exePath in fullFilesPath)//перебираем все exe-шки
                    listExePath.Add(exePath);
            }

            fullFilesPath = Directory.GetFiles(MyDirPath, "*.exe");//ищем все exe в папке str
            foreach (var exePath in fullFilesPath)//перебираем все exe-шки
                listExePath.Add(exePath);
        }

        private void RemoveUnnecessaryExe(string MyDirPath)
        {
            StreamReader f = new StreamReader("RemoveExe.txt");
            string _unExe = f.ReadToEnd();
            _unExe=_unExe.Replace("\r",null);
            string[] unExe = _unExe.Split('\n');int x=99999;
            for (int k = 0; k < unExe.Length; k++)
                for(int i=0;i<listExePath.Count;i++)
                    if (listExePath[i] != null)
                        if (((listExePath[i]).Equals(MyDirPath + unExe[k])))
                            listExePath[i] = null;
            f.Close();
            /*x= listExePath.IndexOf(unExe[k]); не смог найти!!!- не знаю почему*/
        }
        //
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // StreamWriter f = new StreamWriter("HeightWidth.txt");
            try{
            string[] a = new string[2];           
            a[0] = this.Height.ToString();
            a[1] = this.Width.ToString();
            if(a[0]=="0"||a[1]=="0") return;
            File.WriteAllLines("HeightWidth.txt", a);   //до сюда доходит и заканчивает
            }
            catch{}
            try { MousePositionThread.Abort(); }
            catch { }//завершаем поток, иначе он сидит в процессах, хоть и закртыта прога
        } //сохраняем размеры формы
        //    
        protected override void OnResize(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
           
        }
        private void Tray_MouseClick(object sender,System.Windows.Forms.MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Visible = true;
                    this.ShowInTaskbar = true;
                    this.WindowState = FormWindowState.Normal;
                }
            else
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.Visible = false;
                    this.Visible = true;
                    this.ShowInTaskbar = true;
                    this.WindowState = FormWindowState.Normal;

                }
        }

    }
}
