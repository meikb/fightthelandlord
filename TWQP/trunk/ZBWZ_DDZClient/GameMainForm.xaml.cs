using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZBWZ_DDZClient
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class GameMainForm : Window
    {
        public GameMainForm()
        {
            InitializeComponent();
            PaintLogin();
        }

        public void PaintLogin()
        {
            TextBlock txt = new TextBlock();
            txt.Text = "请输入ID: ";
            TextBox tb = new TextBox();
            Button btn = new Button();
            tb.Width = 100;
            btn.Width = 30; btn.Height = 20; btn.Content = "确定";
            btn.Click += (sender, ea1) =>
                {
                    MessageHandler.PlayerID = int.Parse(tb.Text);
                    ClearLogin();
                };
            DockPanel dockPanel = new DockPanel();
            dockPanel.Children.Add(txt);
            dockPanel.Children.Add(tb);
            dockPanel.Children.Add(btn);
            canvas.Children.Add(dockPanel);
            Canvas.SetTop(dockPanel, 300);
            Canvas.SetLeft(dockPanel, 300);
        }

        public void ClearLogin()
        {
            
        }
    }
}
