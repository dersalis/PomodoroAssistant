﻿

#pragma checksum "D:\PROJEKTY\APLIKACJE\Pomodoro Assistant\Sources\Windows Universal Apps_8.1\PomodoroAssistant\PomodoroAssistantPlus\PomodoroAssistantPlus.WindowsPhone\Pages\EditCategoryPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "604776A0C105408067CBBD7F26041BB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PomodoroAssistantPlus.Pages
{
    partial class EditCategoryPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 34 "..\..\..\Pages\EditCategoryPage.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.txtCategoryName_TextChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 44 "..\..\..\Pages\EditCategoryPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.lstColors_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


