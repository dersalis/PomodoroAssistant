﻿

#pragma checksum "D:\MOBILE PROJECTS\Pomodoro Assistant\Windows\Sources\OLD\Windows Universal Apps_8.1\PomodoroAssistant\PomodoroAssistantPlus\PomodoroAssistantPlus.WindowsPhone\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "983AD61AF25520214304C88F175D669A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PomodoroAssistantPlus
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 28 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.addTask_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 29 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.addCategory_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 34 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.settingsAppBarButton_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 35 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.aboutButton_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 36 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.reviewAppBarButton_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 48 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Hub)(target)).SectionsInViewChanged += this.hubPomodoro_SectionsInViewChanged;
                 #line default
                 #line hidden
                #line 49 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Hub)(target)).SectionHeaderClick += this.hubPomodoro_SectionHeaderClick;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 121 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCategoriesByName_Click;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 122 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCategoriesByTasksCount_Click;
                 #line default
                 #line hidden
                break;
            case 9:
                #line 123 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCategoriesByCyclesCount_Click;
                 #line default
                 #line hidden
                break;
            case 10:
                #line 124 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCategoriesByTime_Click;
                 #line default
                 #line hidden
                break;
            case 11:
                #line 93 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCompletedTasksByName_Click;
                 #line default
                 #line hidden
                break;
            case 12:
                #line 94 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCompletedTasksByAddDate_Click;
                 #line default
                 #line hidden
                break;
            case 13:
                #line 95 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCompletedTasksByEditDate_Click;
                 #line default
                 #line hidden
                break;
            case 14:
                #line 96 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCompletedTasksByTime_Click;
                 #line default
                 #line hidden
                break;
            case 15:
                #line 97 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiCompletedTasksByCategory_Click;
                 #line default
                 #line hidden
                break;
            case 16:
                #line 64 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiActiveTasksByName_Click;
                 #line default
                 #line hidden
                break;
            case 17:
                #line 65 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiActiveTasksByAddDate_Click;
                 #line default
                 #line hidden
                break;
            case 18:
                #line 66 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiActiveTasksByEditDate_Click;
                 #line default
                 #line hidden
                break;
            case 19:
                #line 67 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiActiveTasksByTime_Click;
                 #line default
                 #line hidden
                break;
            case 20:
                #line 68 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target)).Click += this.mfiActiveTasksByCategory_Click;
                 #line default
                 #line hidden
                break;
            case 21:
                #line 83 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.lstActiveTasks_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


