﻿#pragma checksum "D:\MOBILE PROJECTS\Pomodoro Assistant\Windows\Sources\PomodoroAssistant\PomodoroAssistant 4 - Prototype\Views\TimerPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AFB06B0B531407D39BCB5B497EBF3F5F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PomodoroAssistant.Views
{
    partial class TimerPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.pageTimer = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 12 "..\..\..\Views\TimerPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)this.pageTimer).SizeChanged += this.pageTimer_SizeChanged;
                    #line default
                }
                break;
            case 2:
                {
                    this.hubTimer = (global::Windows.UI.Xaml.Controls.Hub)(target);
                }
                break;
            case 3:
                {
                    this.secTimer = (global::Windows.UI.Xaml.Controls.HubSection)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

