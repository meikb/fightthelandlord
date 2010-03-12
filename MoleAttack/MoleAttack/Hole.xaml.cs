﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MoleAttack
{
	public partial class Hole : UserControl
	{
		public Hole()
		{
			// 为初始化变量所必需
			InitializeComponent();
            mouse.EvInjured += new Action(mouse_EvInjured);
		}

        void mouse_EvInjured()
        {
            mouse.Injured();
        }
	}
}