using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using WinFormFibonacci.FibonacciService;
using WinFormFibonacci.XmlToJsonService;

namespace WinFormFibonacci
{
    public partial class MainForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger("FileAppender");
        public MainForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var busyForm = new BusyForm();
            try
            {
                if (txtNumber.Text.Equals(""))
                {
                    MessageBox.Show("Enter the number !!!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    log.Warn("Enter the number !!!");
                }
                else
                {
                    log.Debug("Begin Process");
                    Enabled = false;
                    busyForm.Show();
                    Task.Delay(2000).Wait();
                    log.Info("Task waited for 2 second");
                    var result = await GetFibonacciAsync(Convert.ToInt32(txtNumber.Text));
                    busyForm.Hide();
                    Enabled = true;
                    MessageBox.Show("Result of the Fibonacci(" + txtNumber.Text + ") = " + result,
                        "Result of the Fibonacci(" + txtNumber.Text + ")",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.Info("Result of the Fibonacci(" + txtNumber.Text + ") = " + result);
                    BringToFront();
                    txtNumber.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Fatal("Exception: " + ex.Message);
                busyForm.Hide();
                Enabled = true;
                BringToFront();
            }
        }

        private Task<int> GetFibonacciAsync(int number)
        {
            var fibonacciServiceSoapClient = new FibonacciServiceSoapClient();
            return fibonacciServiceSoapClient.FibonacciAsync(number);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var busyForm = new BusyForm();
            try
            {
                if (txtXmlToParse.Text.Equals(""))
                {
                    MessageBox.Show("Enter the xml string !!!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    log.Warn("Enter the xml string !!!");
                }
                else
                {
                    log.Debug("Begin Process");
                    Enabled = false;
                    busyForm.Show();
                    Task.Delay(2000).Wait();
                    log.Info("Task waited for 2 second");
                    var result = await GetJsonFromXmlAsync(txtXmlToParse.Text);
                    busyForm.Hide();
                    Enabled = true;
                    txtJsonParsed.Text = result.ToString();
                    MessageBox.Show("JSON parsed successfully !",
                        "JSON Parser",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    log.Info("JSON parsed successfully ! => " + result);
                    BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bad Xml format. Exception: " + ex.Message, "Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Fatal("Bad Xml format. Exception: " + ex.Message);
                busyForm.Hide();
                Enabled = true;
                BringToFront();
            }
        }

        private Task<string> GetJsonFromXmlAsync(string xml)
        {
            var xmlToJsonServiceSoapClient = new XmlToJsonServiceSoapClient();
            return Task.Run(() =>
            {
                return xmlToJsonServiceSoapClient.XmlToJsonAsync(xml).Result.Body.XmlToJsonResult;
            });
        }
    }
}
