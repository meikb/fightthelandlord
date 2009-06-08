
一小段示例：

static void Main(string[] args)
{
    Console.Title = "xxxxxxxxxxxxxxxxxx";

    var menu = new Menu(true, null, MenuHandler);
}

static void MenuHandler(object sender, EventConsoleUIArgs e)
{
    var c = (Menu)sender;
    var m = new MenuItem(c, null, "根菜单", "", ConsoleKey.Escape, null);
    c.Current = c.Root = m;

    var m0 = m.Add("退出", "", ConsoleKey.Escape, (o, ea)=>{ c.Escape(); });
    var m1 = m.Add("子菜单1", "", ConsoleKey.D1, (o, ea)=>{ m.Writer.WL("xxx"); });
    var m2 = m.Add("子菜单2", "", ConsoleKey.D2, null);

    m2.Action += new EventMenuItemActionHandler(m1_Action);
...