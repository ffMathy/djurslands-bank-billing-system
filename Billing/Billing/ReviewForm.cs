using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Url = new Uri("https://portal4.djurslandsbank.dk/wps/bankdata/jsp/html/da/PortalFrame.jsp?danid=true");

            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
        }

        void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser.DocumentCompleted -= webBrowser_DocumentCompleted;

        }
    }
}
