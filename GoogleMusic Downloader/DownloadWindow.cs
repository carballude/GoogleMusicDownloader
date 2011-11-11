using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using GoogleMusic_Downloader.Model;

namespace GoogleMusic_Downloader
{
    public partial class DownloadWindow : Form
    {

        private List<MusicFile> _files;
        private WebClient _client;
        private FindFilesWindow _findFilesWindow;
        public DownloadWindow(List<MusicFile> files, FindFilesWindow findFilesWindow)
        {
            this._findFilesWindow = findFilesWindow;
            this._files = files;
            InitializeComponent();
            progressBar1.Maximum = files.Count;
            progressBar1.Minimum = 0;
            _client = new WebClient();
            _client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            _client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            this.Visible = true;
            listBox1.DataSource = files;
            lbTitle.Text = files[0].ToString();
            findFilesWindow.Visible = false;
            new Thread(new ParameterizedThreadStart(findFilesWindow.DownloadFile)).Start(files[0]);
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            songProgressBar.Value = e.ProgressPercentage;
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lbTitle.Text = "Nothing";
            progressBar1.Value++;
            _files.RemoveAt(0);
            listBox1.DataSource = _files;
			if (_files.Count > 0)
				DownloadNext();
        }

        private void DownloadNext()
        {                        
            lbTitle.Text = _files[0].ToString();
            _findFilesWindow.DownloadFile(_files[0]);
        }        

        public void newUrl(string url)
        {
			String sTitle = _files[0].Artist + " - " + _files[0].Title;
			
			// Replace characters that are invalid in a windows filename with "_"
			char[] invalidChars = Path.GetInvalidFileNameChars();
			foreach (char invalidChar in invalidChars)
			{
				sTitle = sTitle.Replace(invalidChar.ToString(), "_");
			}

			// If the file is already there, rename it.
			FileInfo file = new FileInfo(sTitle + ".mp3");
			int iCount = 0;
			bool bRename = file.Exists;
			while (bRename)
			{
				iCount++;
				String sTempTitle = sTitle + " (" + iCount + ")";
				file = new FileInfo(sTempTitle + ".mp3");
				bRename = file.Exists;

				if (!bRename)
				{
					// Found a valid filename
					sTitle = sTempTitle;
				}
			}

            _client.DownloadFileAsync(new Uri(url), sTitle + ".mp3");
        }

		private void onClose(object sender, FormClosingEventArgs e)
		{
			// Make sure the hidden browser window is disposed of as well
			_findFilesWindow.Close();
		}
    }
}
