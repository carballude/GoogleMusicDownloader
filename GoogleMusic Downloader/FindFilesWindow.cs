using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using GoogleMusic_Downloader.Model;

namespace GoogleMusic_Downloader
{
    /// <summary>
    /// The purpose of this class is to let the user select the files he wants to download.
    /// </summary>
    public partial class FindFilesWindow : Form
    {

        private DownloadWindow _downloadWindow;
        private List<MusicFile> _files;

        public FindFilesWindow()
        {
            InitializeComponent();
            browser.Url = new Uri("http://music.google.com/");
        }                

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var element = browser.Document.Body.FirstChild.InnerText.Split(new char[] { '"' })[3];
            _downloadWindow.newUrl(element);            
        }


        internal void DownloadFile(object musicFile)
        {            
            browser.Url = new Uri("http://music.google.com/music/play?songid=" + ((MusicFile)musicFile).Id + "&pt=e");
        }

        /// <summary>
        /// Displayed when the user request to download files the application can't find.
        /// </summary>
        private void ShowError() { MessageBox.Show("I can't find any songs. Are you in the Songs section?", "No songs", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        private void btDownloadSongs_Click(object sender, EventArgs e)
        {
            _files = new List<MusicFile>();
            var songs = browser.Document.GetElementById("0songContainer");
            if (songs == null) { ShowError(); return; }
            var table = songs.Children[0];
            for (int i = 0; i < table.Children.Count; i++)
            {
                var songRow = table.Children[i];
                _files.Add(new MusicFile() { Id = songRow.Id.Split('_')[1], Title = table.Children[i].Children[0].Children[0].InnerText, Artist = table.Children[i].Children[2].Children[0].InnerText, Album = table.Children[i].Children[3].Children[0].InnerText });
            }            
            if (_files.Count == 0) { ShowError(); }
            else
            {
                this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
                _downloadWindow = new DownloadWindow(_files, this);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
