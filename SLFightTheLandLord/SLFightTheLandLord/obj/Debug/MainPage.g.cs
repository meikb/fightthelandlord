#pragma checksum "C:\Users\DavidLee\Documents\Visual Studio 2008\Projects\SLFightTheLandLord\SLFightTheLandLord\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9E89DE3D4A0CCFDACDFA100F48983E3E"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4927
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SLFightTheLandLord {
    
    
    public partial class MainPage : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal System.Windows.Controls.Canvas canvasMyPokers;
        
        internal System.Windows.Controls.Button btnLeadPoker;
        
        internal System.Windows.Controls.Canvas canvasLeftPlayerPokers;
        
        internal System.Windows.Controls.Canvas canvasRightPlayerPokers;
        
        internal System.Windows.Controls.Canvas canvasLeftPlayerLeadedPokers;
        
        internal System.Windows.Controls.Canvas canvasRightPlayerLeadedPokers;
        
        internal System.Windows.Controls.Button btnStart;
        
        internal System.Windows.Controls.Button btnPass;
        
        internal System.Windows.Controls.Button btnLandLord;
        
        internal System.Windows.Controls.Button btnNoLandLord;
        
        internal System.Windows.Controls.TextBlock textblockMessage;
        
        internal System.Windows.Controls.TextBlock textblockLeftPlayerTimer;
        
        internal System.Windows.Controls.TextBlock textblockRightPlayerTimer;
        
        internal System.Windows.Controls.TextBlock textblockMyTimer;
        
        internal System.Windows.Controls.Canvas canvasLandLordPokers;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SLFightTheLandLord;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.canvasMyPokers = ((System.Windows.Controls.Canvas)(this.FindName("canvasMyPokers")));
            this.btnLeadPoker = ((System.Windows.Controls.Button)(this.FindName("btnLeadPoker")));
            this.canvasLeftPlayerPokers = ((System.Windows.Controls.Canvas)(this.FindName("canvasLeftPlayerPokers")));
            this.canvasRightPlayerPokers = ((System.Windows.Controls.Canvas)(this.FindName("canvasRightPlayerPokers")));
            this.canvasLeftPlayerLeadedPokers = ((System.Windows.Controls.Canvas)(this.FindName("canvasLeftPlayerLeadedPokers")));
            this.canvasRightPlayerLeadedPokers = ((System.Windows.Controls.Canvas)(this.FindName("canvasRightPlayerLeadedPokers")));
            this.btnStart = ((System.Windows.Controls.Button)(this.FindName("btnStart")));
            this.btnPass = ((System.Windows.Controls.Button)(this.FindName("btnPass")));
            this.btnLandLord = ((System.Windows.Controls.Button)(this.FindName("btnLandLord")));
            this.btnNoLandLord = ((System.Windows.Controls.Button)(this.FindName("btnNoLandLord")));
            this.textblockMessage = ((System.Windows.Controls.TextBlock)(this.FindName("textblockMessage")));
            this.textblockLeftPlayerTimer = ((System.Windows.Controls.TextBlock)(this.FindName("textblockLeftPlayerTimer")));
            this.textblockRightPlayerTimer = ((System.Windows.Controls.TextBlock)(this.FindName("textblockRightPlayerTimer")));
            this.textblockMyTimer = ((System.Windows.Controls.TextBlock)(this.FindName("textblockMyTimer")));
            this.canvasLandLordPokers = ((System.Windows.Controls.Canvas)(this.FindName("canvasLandLordPokers")));
        }
    }
}
