using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

namespace ConsoleHelper
{
    /// <summary>
    /// 提供简易文本菜单功能的控制台UI，以及一些静态辅助方法
    /// </summary>
    public class Menu
    {
        #region Properties

        protected object _args = null;
        protected bool _isDoLoop = true;
        protected MenuItem _root = null;
        protected MenuItem _current = null;
        protected Writer _w = new Writer();

        public virtual MenuItem Root
        {
            get { return this._root; }
            set { this._root = value; }
        }
        public virtual MenuItem Current
        {
            get { return this._current; }
            set { this._current = value; }
        }
        public virtual Writer Writer
        {
            get { return this._w; }
        }

        public virtual event Action<Menu> OnInit = null;

        #endregion

        #region Constructors

        public Menu(bool isDoLoop, object args, Action<Menu> init)
        {
            this._isDoLoop = isDoLoop;
            this._args = args;
            this.OnInit = init;
            if (this.OnInit != null) this.OnInit(this);
            this.Loop();
        }
        public Menu(string caption, Action<Menu> init)
        {
            this.Current = this.Root = new MenuItem(this, caption);
            this._isDoLoop = true;
            this._args = null;
            this.OnInit = init;
            if (this.OnInit != null) this.OnInit(this);
            this.Loop();
        }

        #endregion

        #region Loop, Escape, Warning

        public virtual void Loop()
        {
            if (this._current == null) return;

            //菜单的显示与响应
            do
            {
                this._current.Output();
                var cki = Console.ReadKey();
                this.Writer.W("\n\n");
                var isRightCmd = false;
                foreach (var m in this._current.SubMenus)
                {
                    var isVisible = m.DoCheckVisible();
                    if (isVisible != null && isVisible.Value &&
                        m.ShortCutKey.ToString().Equals(cki.Key.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (m.SubMenus.Count > 0) this._current = m;
                        isRightCmd = true;
                        m.DoAction();
                        break;
                    }
                }
                if (!isRightCmd) Warning();

            } while (this._isDoLoop);
        }
        public virtual void Escape()
        {
            if (this._current.Parent != null)
            {
                this._current = this._current.Parent;
            }
            else this._isDoLoop = false;
        }
        public virtual void Warning()
        {
            this.Writer.W(ConsoleColor.Red, "无法识别或禁止使用的命令，请重新输入。\n");
        }


        #endregion
    }
}
