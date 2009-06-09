using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleHelper
{
    public delegate bool? VisibleChecker(MenuItem mi);

    // todo: menu 显示与否的条件
    public class MenuItem
    {

        #region Properties

        protected Menu _owner = null;
        protected MenuItem _parent = null;
        protected string _caption = string.Empty;
        protected string _intro = string.Empty;
        protected ConsoleKey _shortCutKey;
        protected List<MenuItem> _subMenus = new List<MenuItem>();

        public virtual Menu Owner
        {
            get { return this._owner; }
            set { this._owner = value; }
        }

        public virtual MenuItem Parent
        {
            get { return this._parent; }
            set { this._parent = value; }
        }
        public virtual string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }

        public virtual string Intro
        {
            get { return this._intro; }
            set { this._intro = value; }
        }

        public virtual List<MenuItem> SubMenus
        {
            get { return this._subMenus; }
            set { this._subMenus = value; }
        }

        public virtual ConsoleKey ShortCutKey
        {
            get { return this._shortCutKey; }
            set { this._shortCutKey = value; }
        }

        public virtual event Action<MenuItem> Action = null;
        public virtual event VisibleChecker VisibleChecker = null;


        public virtual Writer Writer
        {
            get { return this._owner.Writer; }
        }

        #endregion

        #region Constructors

        public MenuItem(Menu owner, MenuItem parent, string caption, string intro, ConsoleKey shortCutKey, Action<MenuItem> action, VisibleChecker visibleChecker)
        {
            this._owner = owner;
            this._parent = parent;
            this._caption = caption;
            this._intro = intro;
            this._shortCutKey = shortCutKey;
            this.Action = action;
            this.VisibleChecker = visibleChecker;
        }
        public MenuItem(Menu owner, string caption)
            : this(owner, null, caption, null, ConsoleKey.Escape, null, null)
        {
        }
        #endregion

        #region Methods

        /// <summary>
        /// 执行当前菜单的处理方法
        /// </summary>
        public virtual void DoAction()
        {
            if (this.Action != null) this.Action(this);
        }

        /// <summary>
        /// 执行当前菜单的显示与否检查方法
        /// </summary>
        public virtual bool? DoCheckVisible()
        {
            if (this.VisibleChecker != null) return this.VisibleChecker.Invoke(this);
            return true;
        }

        public virtual MenuItem Add(string caption, string intro, ConsoleKey shortCutKey, Action<MenuItem> action, VisibleChecker visibleCheck)
        {
            var cmi = new MenuItem(_owner, this, caption, intro, shortCutKey, action, visibleCheck);
            this.SubMenus.Add(cmi);
            return cmi;
        }

        /// <summary>
        /// 添加“返回上级”菜单
        /// </summary>
        public virtual MenuItem AddEx(string caption)
        {
            var cmi = new MenuItem(_owner, this, caption, null, ConsoleKey.Escape, cm => { cm.Owner.Escape(); }, null);
            this.SubMenus.Add(cmi);
            return cmi;
        }
        public virtual MenuItem AddEx(int key, string caption, Action<MenuItem> action)
        {
            var mi = Add(key, caption, action);
            mi.Action += o => { o.Escape(); };
            return mi;
        }
        public virtual MenuItem Add(int key, string caption)
        {
            return Add(key, caption, null, null, null);
        }
        public virtual MenuItem Add(int key, string caption, Action<MenuItem> action)
        {
            return Add(key, caption, null, action, null);
        }
        public virtual MenuItem Add(int key, string caption, string intro, Action<MenuItem> action)
        {
            return Add(key, caption, intro, action, null);
        }
        public virtual MenuItem Add(int key, string caption, Action<MenuItem> action, VisibleChecker visibleCheck)
        {
            return Add(key, caption, null, action, visibleCheck);
        }
        public virtual MenuItem Add(int key, string caption, string intro, Action<MenuItem> action, VisibleChecker visibleCheck)
        {
            if (key >= 0 && key <= 9) return Add(caption, intro, (ConsoleKey)(key + 48), action, visibleCheck);
            return null;
        }

        /// <summary>
        /// 输出当前菜单到控制台
        /// </summary>
        public virtual void Output()
        {
            this.Writer.W(ConsoleColor.Gray, "\n当前位置：");
            this.Writer.W(ConsoleColor.White, "{0}\n\n", MenuItem.GetLocation(this));
            if (!string.IsNullOrEmpty(this._intro)) this.Writer.W(ConsoleColor.Cyan, "{0}\n\n", this._intro);
            foreach (var m in this.SubMenus)
            {
                var isVisible = m.DoCheckVisible();
                if (isVisible == null)
                {
                    Writer.W(ConsoleColor.DarkGreen, " {0}\t：", GetShortCutKeyDisplay(m.ShortCutKey));
                    Writer.W(ConsoleColor.Gray, " {0}\n", m.Caption);
                }
                else if (isVisible.Value)
                {
                    Writer.W(ConsoleColor.Green, " {0}\t：", GetShortCutKeyDisplay(m.ShortCutKey));
                    Writer.W(ConsoleColor.White, " {0}\n", m.Caption);
                }
            }
            this.Writer.W(ConsoleColor.DarkYellow, "\n请按键：");
        }

        /// <summary>
        /// 调 Owner Menu 的 Escape()
        /// </summary>
        public void Escape()
        {
            this.Owner.Escape();
        }

        /// <summary>
        /// 获取菜单位于树中的路径
        /// </summary>
        public static string GetLocation(MenuItem cmi)
        {
            if (cmi == null) return string.Empty;
            if (cmi.Parent != null) return MenuItem.GetLocation(cmi.Parent) + "." + cmi.Caption;
            return cmi.Caption;
        }

        /// <summary>
        /// 取按键的显示内容
        /// </summary>
        public static string GetShortCutKeyDisplay(ConsoleKey ck)
        {
            var s = ck.ToString();
            if (s.Length == 2 && s[0] == 'D') s = s[1].ToString();  //处理 D1 D2 ... 的问题
            //陆续添加中
            return s;
        }

        #endregion

    }
}
