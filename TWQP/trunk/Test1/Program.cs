using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using ConsoleHelper;

namespace Test1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";
            int sId = 0, sType = 0;
            new Menu("服务配置和运行", (owner) =>
            {
                var w = owner.Writer; var m = owner.Root;
                var m0 = m.AddEx("退出");
                var m1 = m.Add(1, "设置服务类型", "请按相应的数字键选择服务类型", (cm) =>
                {
                    w.W(ConsoleColor.Yellow, "当前服务类型为：");
                    w.W(ConsoleColor.Green, (sType == 0 ? "未知" : (sType == 1 ? "RollClient" : "RollServer")) + "\n");
                });
                var m1_0 = m1.AddEx("返回上层");
                var m1_1 = m1.AddEx(1, "RollClient", (cm) => { sType = 1; });
                var m1_2 = m1.AddEx(2, "RollServer", (cm) => { sType = 2; });
                var m2 = m.Add(2, "设置服务编号", (cm) => { int.TryParse(w.RL("请输入服务编号："), out sId); });
                var m3 = m.Add(3, "开始运行服务", (cm) =>
                {
                    var h = new ContactCenterCallback(sType == 1 ?
                        (IContactCenterCallbackHandler)new Handler_RollClient(sId) : new Handler_RollServer(sId));
                    w.RL("服务运行中...按回车中断...");
                    w.WL("服务已终止！");
                }, (cm) => { return (sType == 0 || sId == 0) ? null : new bool?(true); });
            });
        }
    }
}
