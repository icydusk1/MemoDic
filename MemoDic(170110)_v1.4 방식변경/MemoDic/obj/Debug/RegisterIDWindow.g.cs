﻿#pragma checksum "..\..\RegisterIDWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "67D5196C6137F08B873E9A562ADACD51"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MemoDic;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MemoDic {
    
    
    /// <summary>
    /// RegisterIDWindow
    /// </summary>
    public partial class RegisterIDWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\RegisterIDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_NewID;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\RegisterIDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_NewPW;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\RegisterIDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_ConfirmNewPW;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\RegisterIDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_OK;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\RegisterIDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_Cancel;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\RegisterIDWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_HintForPW;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MemoDic;component/registeridwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegisterIDWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TB_NewID = ((System.Windows.Controls.TextBox)(target));
            
            #line 10 "..\..\RegisterIDWindow.xaml"
            this.TB_NewID.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_PW_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TB_NewPW = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\RegisterIDWindow.xaml"
            this.TB_NewPW.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_PW_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TB_ConfirmNewPW = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\RegisterIDWindow.xaml"
            this.TB_ConfirmNewPW.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_PW_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BT_OK = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.BT_Cancel = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.TB_HintForPW = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\RegisterIDWindow.xaml"
            this.TB_HintForPW.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TB_PW_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

