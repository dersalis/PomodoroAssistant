﻿using PomodoroAssistant.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PomodoroAssistant.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimerPage : Page, INotifyPropertyChanged
    {
        public int SectionWidth { get; private set; }
        public int SectionHeight { get; private set; }


        /// <summary>
        /// KONSTRUKTOR
        /// </summary>
        public TimerPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            
            //this.UpdateLayout();
        }


        /// <summary>
        /// Występuje gdy zmienia się rozmiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageTimer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int currentPageWidth = (int)this.ActualWidth;
            int currentPageHeight = (int)this.ActualHeight;
            SectionHeight = SectionCreator.CalculateSectionHeight(currentPageHeight);
            SectionWidth = SectionCreator.CalculateSectionWidth(currentPageWidth);
            NotifyPropertyChanged("SectionHeight");
            NotifyPropertyChanged("SectionWidth");
        }


        #region NotityPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
