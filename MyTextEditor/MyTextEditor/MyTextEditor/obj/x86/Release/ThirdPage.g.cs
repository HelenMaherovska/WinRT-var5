﻿#pragma checksum "D:\ПЗ\іспитWinRT\Variant5\MyTextEditor\MyTextEditor\MyTextEditor\ThirdPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "08E923B892A12D43DF44C22ADFDC17A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyTextEditor
{
    partial class ThirdPage : 
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
                    this.grid3 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 11 "..\..\..\ThirdPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.Back_ToMainPageClick;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.Button element3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 18 "..\..\..\ThirdPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element3).Click += this.Button_Click_1;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 27 "..\..\..\ThirdPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.Button_Click_2;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 35 "..\..\..\ThirdPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Button_Click_8;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 37 "..\..\..\ThirdPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Tapped += this.r1;
                    #line default
                }
                break;
            case 7:
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 42 "..\..\..\ThirdPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Tapped += this.r2;
                    #line default
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
