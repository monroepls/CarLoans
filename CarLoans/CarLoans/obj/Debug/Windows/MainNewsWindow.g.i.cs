﻿#pragma checksum "..\..\..\Windows\MainNewsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "165DF30020416B7C5914324C7ECA7C4CBBB9F29F52EA8A3A1264A367098A0584"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarLoans.Windows;
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


namespace CarLoans.Windows {
    
    
    /// <summary>
    /// MainNewsWindow
    /// </summary>
    public partial class MainNewsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 400 "..\..\..\Windows\MainNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        
        #line 404 "..\..\..\Windows\MainNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Clients;
        
        #line default
        #line hidden
        
        
        #line 405 "..\..\..\Windows\MainNewsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Sotrudniki;
        
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
            System.Uri resourceLocater = new System.Uri("/CarLoans;component/windows/mainnewswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\MainNewsWindow.xaml"
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
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            
            #line 400 "..\..\..\Windows\MainNewsWindow.xaml"
            this.MainFrame.ContentRendered += new System.EventHandler(this.MainFrame_ContentRendered);
            
            #line default
            #line hidden
            
            #line 400 "..\..\..\Windows\MainNewsWindow.xaml"
            this.MainFrame.Navigated += new System.Windows.Navigation.NavigatedEventHandler(this.MainFrame_Navigated);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 402 "..\..\..\Windows\MainNewsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.go_to_zayavki);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 403 "..\..\..\Windows\MainNewsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.go_to_avtorizaciya);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Clients = ((System.Windows.Controls.Button)(target));
            
            #line 404 "..\..\..\Windows\MainNewsWindow.xaml"
            this.Clients.Click += new System.Windows.RoutedEventHandler(this.Client_click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Sotrudniki = ((System.Windows.Controls.Button)(target));
            
            #line 405 "..\..\..\Windows\MainNewsWindow.xaml"
            this.Sotrudniki.Click += new System.Windows.RoutedEventHandler(this.Go_to_sotrudniki);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 406 "..\..\..\Windows\MainNewsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonExit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 408 "..\..\..\Windows\MainNewsWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.go_to_cars);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

