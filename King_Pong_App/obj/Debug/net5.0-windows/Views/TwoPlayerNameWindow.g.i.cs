﻿#pragma checksum "..\..\..\..\Views\TwoPlayerNameWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38AA67FA7AA43582022B1A5077066CB3E285AEE1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using King_Pong_App.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace King_Pong_App.Views {
    
    
    /// <summary>
    /// TwoPlayerNameWindow
    /// </summary>
    public partial class TwoPlayerNameWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\..\Views\TwoPlayerNameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameOfPlayer1;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Views\TwoPlayerNameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Team1Name;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\Views\TwoPlayerNameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Team2Name;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\Views\TwoPlayerNameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameOfPlayer3;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\Views\TwoPlayerNameWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmNames;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/King_Pong_App;V1.0.0.0;component/views/twoplayernamewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\TwoPlayerNameWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NameOfPlayer1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Team1Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Team2Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NameOfPlayer3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ConfirmNames = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\Views\TwoPlayerNameWindow.xaml"
            this.ConfirmNames.Click += new System.Windows.RoutedEventHandler(this.ConfirmNames_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

