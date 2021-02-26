using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Newtonsoft.Json;

namespace Test
{
    public partial class frmMain : Form
    {
        class Candidate
        {
            public  int matches_template;
            public string plate;
            public double confidence;
        }

        class  RegionsOfInterest
        {
            public int height;
            public int width;
            public int y;
            public int x;
        }


        public frmMain()
        {
            InitializeComponent();
        }
        Image<Bgr, byte> src;
        string imagepath;
        private void button1_Click(object sender, EventArgs e)
        {

            System.DateTime firstDate = new System.DateTime(2000, 01, 01,0,0,5);
            System.DateTime secondDate = new System.DateTime(2000, 01, 01,23,59,59);

            System.TimeSpan diff = secondDate.Subtract(firstDate);
            System.TimeSpan diff1 = secondDate - firstDate;

            var diff2 = (int)(secondDate - firstDate).TotalDays;

            MessageBox.Show(diff2.ToString());
        }
        private static readonly HttpClient client = new HttpClient();
        public  async Task<string> ProcessImage(string image_path)
        {
            string SECRET_KEY = "sk_e15ff75142e70e7f3eb1b159";

            Byte[] bytes = File.ReadAllBytes(image_path);
            string imagebase64 = Convert.ToBase64String(bytes);

            var content = new StringContent(imagebase64);

            var response = await client.PostAsync("https://api.openalpr.com/v2/recognize_bytes?recognize_vehicle=1&country=eu&secret_key=" + SECRET_KEY, content).ConfigureAwait(false);

            var buffer = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            var byteArray = buffer.ToArray();
            var responseString = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);

            return responseString;
        }
        public  string GetResultLicense(string image_path)
        {
            Task<string> recoginzedTask = Task.Run(() => ProcessImage(image_path));
            recoginzedTask.Wait();
            string task_result = recoginzedTask.Result;
            dynamic deserializedValue = JsonConvert.DeserializeObject(task_result);
            var values = deserializedValue["results"];
            dynamic licences;
            for (int i = 0; i < values.Count; i++)
            {
                dynamic result_field = values[i].ToString();
                dynamic deseriableResultField = JsonConvert.DeserializeObject(result_field);
                licences = deseriableResultField["plate"];
                return Convert.ToString(licences.ToString());
            }
            return "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Task<string> recognizeTask = Task.Run(() => ProcessImage(imagepath));
            recognizeTask.Wait();
            string task_result = recognizeTask.Result;
           
           
        }
    }
}
