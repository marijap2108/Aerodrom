﻿#pragma checksum "..\..\..\Pages\SendPackage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6FF1BFFCBB3B8A00F5077DCA135804F66274DF2A871B9C841226AE92AC0D5F31"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Aerodrom.Pages;
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


namespace Aerodrom.Pages {
    
    
    /// <summary>
    /// SendPackage
    /// </summary>
    public partial class SendPackage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Zapremina;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ZapreminaBroj;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Tezina;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TezinaBroj;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Lomljivost;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label VrstaPaketa;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Naziv;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Let;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\SendPackage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Send;
        
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
            System.Uri resourceLocater = new System.Uri("/Aerodrom;component/pages/sendpackage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SendPackage.xaml"
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
            this.Zapremina = ((System.Windows.Controls.Slider)(target));
            
            #line 29 "..\..\..\Pages\SendPackage.xaml"
            this.Zapremina.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ZapreminaBroj = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Tezina = ((System.Windows.Controls.Slider)(target));
            
            #line 34 "..\..\..\Pages\SendPackage.xaml"
            this.Tezina.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TezinaBroj = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Lomljivost = ((System.Windows.Controls.CheckBox)(target));
            
            #line 38 "..\..\..\Pages\SendPackage.xaml"
            this.Lomljivost.Checked += new System.Windows.RoutedEventHandler(this.CheckboxChanged);
            
            #line default
            #line hidden
            
            #line 38 "..\..\..\Pages\SendPackage.xaml"
            this.Lomljivost.Unchecked += new System.Windows.RoutedEventHandler(this.CheckboxChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.VrstaPaketa = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Naziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.Let = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.Send = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Pages\SendPackage.xaml"
            this.Send.Click += new System.Windows.RoutedEventHandler(this.Send_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
