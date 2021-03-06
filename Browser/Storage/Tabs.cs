﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chromium
{
    public class Tabs
    {
        /// <summary>
        /// Open tab for Browser
        /// </summary>
        /// <param name="url"></param>
        public static void New(string url)
        {
            TabUrls.Add(url);
            NewTab("",url);
        }
        /// <summary>
        /// Close tab by index
        /// </summary>
        /// <param name="index"></param>
        public static void Close(int index)
        {
            try
            {
                TabUrls.RemoveAt(index);
                CloseTab("", index);
            }
            catch (Exception)
            {

            }
        }
        public static EventHandler<string> NewTab;
        public static EventHandler<int> CloseTab;
        public static List<string> TabUrls = new List<string>();
    }
}
