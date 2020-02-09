﻿#pragma checksum "..\..\..\Views\MusicView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E2736D3E3530B67DDDE8BB7F135D0AC065664B71"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Caliburn.Micro;
using DagiCaliburn.Views;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace DagiCaliburn.Views {
    
    
    /// <summary>
    /// MusicView
    /// </summary>
    public partial class MusicView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 24 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock CurrentAudio;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AudioTypes;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseGBSelected;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalSum;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid DrivesIsVisible;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl DrivesToCopyTo;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid RegisterIsVisible;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\..\Views\MusicView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Register;
        
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
            System.Uri resourceLocater = new System.Uri("/DagiCaliburn;component/views/musicview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MusicView.xaml"
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
            this.CurrentAudio = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.AudioTypes = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.CloseGBSelected = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.TotalSum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.DrivesIsVisible = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.DrivesToCopyTo = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 8:
            this.RegisterIsVisible = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.Register = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 110 "..\..\..\Views\MusicView.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Card_MouseEnter);
            
            #line default
            #line hidden
            
            #line 110 "..\..\..\Views\MusicView.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Card_MouseLeave);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
