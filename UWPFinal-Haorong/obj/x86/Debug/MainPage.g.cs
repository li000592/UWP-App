﻿#pragma checksum "C:\Users\liuzi\source\repos\UWPFinal-Haorong\UWPFinal-Haorong\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C5CE69739A5DD8AB421338F73E30323AC1315982E1C7511F36FDDBA24293381C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UWPFinal_Haorong
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 13
                {
                    this.aboutButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.aboutButton).Click += this.aboutButton_Click;
                }
                break;
            case 3: // MainPage.xaml line 23
                {
                    this.imageStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // MainPage.xaml line 29
                {
                    this.pageTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MainPage.xaml line 30
                {
                    this.buttonStackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 6: // MainPage.xaml line 31
                {
                    this.ImageButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ImageButton).Click += this.ImageButton_Click;
                }
                break;
            case 7: // MainPage.xaml line 32
                {
                    this.videoButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.videoButton).Click += this.videoButton_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

