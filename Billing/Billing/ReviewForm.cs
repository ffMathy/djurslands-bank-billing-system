using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing
{
    public partial class ReviewForm : Form
    {

        public ReviewForm()
        {
            InitializeComponent();

            webBrowser.DocumentCompleted += LaunchMainSiteCallback;

            webBrowser.ScriptErrorsSuppressed = true;

            Load();
        }

        async void Load()
        {

            var request = WebRequest.CreateHttp("https://portal4.djurslandsbank.dk/wps/bankdata/jsp/html/da/PortalFrame.jsp?danid=true");
            request.CookieContainer = new CookieContainer();

                client.DownloadString("https://portal4.djurslandsbank.dk/wps/bankdata/jsp/html/da/PortalFrame.jsp?danid=true");

                var headers = client.Headers;
                headers[HttpRequestHeader.Referer] = "https://portal4.djurslandsbank.dk/wps/bankdata/jsp/html/da/PortalFrame.jsp?danid=true";

                webBrowser.Navigate("about:blank");

                var response = await client.GetAsync("https://portal4.djurslandsbank.dk/wps/portal/djurslandsbank-dk/NemIDJS");
                var content = await response.Content.ReadAsStringAsync();
                webBrowser.DocumentText = content;
            }
        }

        async void LaunchMainSiteCallback(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            var url = e.Url + "";
            if (url.EndsWith("/wps/portal/djurslandsbank-dk/NemIDJS"))
            {
                webBrowser.DocumentCompleted -= LaunchMainSiteCallback;

                IEnumerable<HtmlElement> buttons;
                while (true)
                {
                    buttons = webBrowser.FindElements("*//button[@class='Box-Button-Submit']");
                    if (buttons.Any())
                    {
                        break;
                    }
                }
            }

        }
    }
}
