using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Console;

namespace WinForm
{
    class WinForm : Form
    {
        public WinForm()
        {

        }
        public WinForm(string method)
        {
            if(method == "FormEvent")
            {
                this.Text = "Mouse Event Test";
                this.MouseDown += new MouseEventHandler(MyMouseHandler);
            }

            if (method == "FormBackground")
            {
                this.MouseWheel += new MouseEventHandler(WinForm_MouseWheel);
                this.MouseDown += new MouseEventHandler(WinForm_MouseDown_Color);
            }

            if(method == "FormStyle")
            {
                this.MouseDown += new MouseEventHandler(WinForm_MouseDown_Style);
            }
        }

        public void MyMouseHandler(object sender, MouseEventArgs e)
        {
            WriteLine($"Sender : {((Form)sender).Text}");
            WriteLine($"X : {e.X}, Y : {e.Y}");
            WriteLine($"Button : {e.Button}, Clicks : {e.Clicks}");
            WriteLine();
        }
        public void WinForm_MouseDown_Color(object sender, MouseEventArgs e)
        {
            Random rand = new Random();

            if(e.Button == MouseButtons.Left)
            {
                Color oldColor = this.BackColor;
                this.BackColor = Color.FromArgb(rand.Next(0, 255),
                                                rand.Next(0, 255),
                                                rand.Next(0, 255));
            }
            else if(e.Button == MouseButtons.Right)
            {
                if (this.BackgroundImage != null)
                {
                    this.BackgroundImage = null;
                    return;
                }

                string file = System.IO.Directory.GetCurrentDirectory() + "\\Sample.jpg";
                if (System.IO.File.Exists(file) == false)
                    MessageBox.Show("이미지 파일이 없습니다.");
                else
                    this.BackgroundImage = Image.FromFile(file);
            }
        }
        public void WinForm_MouseWheel(object sender, MouseEventArgs e)
        {
            this.Opacity = this.Opacity + (e.Delta > 0 ? 0.1 : -0.1);
            WriteLine($"Opactiy : {this.Opacity}");
        }
        public void WinForm_MouseDown_Style(object sender, MouseEventArgs e)
        {
            Form form = (Form)sender;

            if(e.Button == MouseButtons.Left)
            {
                form.MaximizeBox = true;
                form.MinimizeBox = true;
                form.Text = "최소화/최대화 버튼이 활성화되었습니다.";
            }

            else if(e.Button == MouseButtons.Right)
            {
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Text = "최소화/최대화 버튼이 비활성화되었습니다.";
            }
        }
    }
    class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        { 
            
            if (m.Msg == 0x0F || m.Msg == 0xA0 || m.Msg == 0x200 || m.Msg == 0x113)
                return false;

            WriteLine($"{m.ToString()} : {m.Msg} ");

            if (m.Msg == 0x201)
                Application.Exit();
           

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //SimpleWindows();
            //UsingApplication();
            //MessageFilter();
            //FormEvent();
            //FormSize();
            //FormBackground();
            //FormStyle();
            FormAndCotrol();

            WriteLine();
        }
        static void SimpleWindows()
        {
            WinForm form = new WinForm();
            System.Windows.Forms.Application.Run(form);
        }
        static void UsingApplication()
        {
            WinForm form = new WinForm();

            form.Click += new EventHandler((sender, eventArgs) =>
            {
                WriteLine("Closing Window...");
                Application.Exit();
            });

            WriteLine("Starting Window Application...");
            Application.Run(form);

            WriteLine("Exiting Window Application...");
        }
        static void MessageFilter()
        {
            Application.AddMessageFilter(new MessageFilter());
            Application.Run(new Form());
        }
        static void FormEvent()
        {
            Application.Run(new WinForm("FormEvent"));
        }
        static void FormSize()
        {
            void form_MouseDown(object sender, MouseEventArgs e)
            {
                Form _form = (Form)sender;
                int oldWidth = _form.Width;
                int oldHeight = _form.Height;

                if (e.Button == MouseButtons.Left)
                {
                    if (oldWidth < oldHeight)
                    {
                        _form.Width = oldHeight;
                        _form.Height = oldWidth;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (oldHeight < oldWidth)
                    {
                        _form.Width = oldHeight;
                        _form.Height = oldWidth;
                    }
                }

                WriteLine("윈도우의 크기가 변경되었습니다.");
                WriteLine($"Width : {_form.Width}, Height : {_form.Height}");
            }

            WinForm form = new WinForm();
            form.Width = 300;
            form.Height = 200;

            form.MouseDown += new MouseEventHandler(form_MouseDown);

            Application.Run(form);

        }
        static void FormBackground()
        {
            Application.Run(new WinForm("FormBackground"));
        }
        static void FormStyle()
        {
            WinForm form = new WinForm("FormStyle");

            form.Width = 400;

            Application.Run(form);
        }
        static void FormAndCotrol()
        {
            Button button = new Button();

            button.Text = "Click Me";
            button.Left = 100;
            button.Top = 50;

            button.Click += ((object sender, EventArgs e) =>
            {
                MessageBox.Show("딸깍!");
            });

            WinForm form = new WinForm();
            form.Text = "Form & Contrl";
            form.Controls.Add(button);

            Application.Run(form);
        }
    }
}
