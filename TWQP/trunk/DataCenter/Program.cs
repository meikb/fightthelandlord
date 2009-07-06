using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Configuration;
using System.Timers;
using System.Data;

namespace ContactCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ContactCenter Host";
            var host = new ServiceHost(typeof(ContactCenter.ContactCenterService));
            host.Opened += (sender1, ea1) =>
            {
                var t = new Timer(2000);
                t.Elapsed += (sender2, ea2) =>
                {
                    try
                    {
                        var dt = new DataTable("asdfqwer");
                        dt.Columns.Add("asdf");
                        dt.Columns.Add("qwer");
                        dt.Rows.Add("asdf1", "qwer1");
                        dt.Rows.Add("asdf2", "qwer2");

                        //var writer = new System.IO.StringWriter();
                        //dt.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                        //var binary = Encoding.Default.GetBytes(writer.ToString());

                        ContactCenterService.Broadcast(null, new MessageEventArgs
                        {
                            MessageType = MessageType.Ping,
                            Data = new byte[][] { dt.ToBinary<DataTable>() }
                        });
                        Console.Write(".");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                };
                t.Start();
            };
            host.Open();
            Console.WriteLine("ContactCenter service listening ....");
            Console.WriteLine("Press ENTER to stop service...");
            Console.ReadLine();
            host.Abort();
            host.Close();

        }
    }
}
