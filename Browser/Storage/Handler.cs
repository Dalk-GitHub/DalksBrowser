using CefSharp;
using System;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Chromium
{
    public class Keyhandler : IKeyboardHandler
    {
        public Keyhandler() { }

        public bool OnKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            return true;
        }

        public bool OnPreKeyEvent(IWebBrowser chromiumWebBrowser, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            return true;
        }
    }
    public class JSHandler : IJsDialogHandler
    {
        public bool OnBeforeUnloadDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string messageText, bool isReload, IJsDialogCallback callback)
        {
            return true;
        }

        public void OnDialogClosed(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }

        public bool OnJSDialog(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, CefJsDialogType dialogType, string messageText, string defaultPromptText, IJsDialogCallback callback, ref bool suppressMessage)
        {
            new JSAlert(messageText);
            return true;
        }

        public void OnResetDialogState(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            
        }
    }
    public class DwlInf
    {
        public DwlInf() { }
        public long Speed { get; set; }
        public string Url { get; set; }
    }
    public class FileDownloadHandle : IDownloadHandler
    {
        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            Data.MainForm.Invoke(new Action(() =>
            {
                if (new DownloadBox(new DwlInf
                {
                    Speed = downloadItem.CurrentSpeed,
                    Url = downloadItem.OriginalUrl
                }).ShowDialog() == DialogResult.OK)
                {
                    SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "All files|*.*",
                        FileName = downloadItem.SuggestedFileName
                    };
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (!callback.IsDisposed)
                        {
                            Data.RunningDownloads++;
                            callback.Continue(showDialog: false, downloadPath: sfd.FileName);
                        }
                    }
                    else
                    {
                        downloadItem.IsCancelled = true;
                    }
                }
                else
                {
                    downloadItem.IsCancelled = true;
                }
            }));
        }

        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            if (downloadItem.IsComplete)
            {
                Data.RunningDownloads--;
            }
        }
    }
}