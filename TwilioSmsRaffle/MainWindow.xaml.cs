using Kent.Boogaart.KBCsv;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwilioSmsRaffle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string smsLogPath = @"[The_Twilio_Sms_Log_File_Path]";

        List<Message> uniqueMessages = new List<Message>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Message> messages = new List<Message>();

            var file = File.OpenRead(smsLogPath);

            using (var reader = new CsvReader(file))
            {
                reader.ReadHeaderRecord();

                while (reader.HasMoreRecords)
                {
                    var record = reader.ReadDataRecord();
                                                          
                    var body = record["Body"];
                    var from = record["From"];

                    messages.Add( new Message() { Body = body, From = from } );

                    Console.WriteLine("{0}, {1}", body, from);
                }
            }

            uniqueMessages = messages.DistinctBy(m => m.From).ToList();
        }

        Random rand = new Random(Environment.TickCount);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int next = rand.Next(0, uniqueMessages.Count);
            Console.WriteLine(next);

            Console.WriteLine("Count: " + uniqueMessages.Count.ToString());

            this.lblName.Content = uniqueMessages[next].Body;
            this.lblFrom.Content = uniqueMessages[next].From;

            uniqueMessages.RemoveAt(next);
        }    
    }

    public class Message
    {
        public string Body { get; set; }
        public string From { get; set; }
    }
}
