using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wallet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Exchange : ContentPage
	{
        String currency= "";
		public Exchange ()
		{
			InitializeComponent ();
		}
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;

            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                currency = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void Trans_ButtonClicked(object sender, EventArgs e)
        {
            int inputnumber = Convert.ToInt32(input.Text);


            string url = "https://blockchain.info/tobtc?currency=" + currency + "&value=" + inputnumber;

            output.Text = HttpGet(url);


        }

        ///?<summary>
        ///?后台发送GET请求
        ///?</summary>
        ///?<param?name="url">服务器地址</param>
        ///?<param?name="data">发送的数据</param>
        ///?<returns></returns>
        public string HttpGet(string url)
        {
            try
            {
                //创建Get请求

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string retString = streamReader.ReadToEnd();

                streamReader.Close();
                stream.Close();
                response.Close();

                return retString;
            }
            catch (Exception)
            {
                return "";
            }
        }


    }


}