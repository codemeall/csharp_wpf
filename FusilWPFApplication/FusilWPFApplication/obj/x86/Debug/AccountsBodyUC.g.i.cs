﻿#pragma checksum "..\..\..\AccountsBodyUC.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC0843230B4CD7150AE404E8897A680A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FusilControlLib;
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


namespace FusilWPFApplication {
    
    
    /// <summary>
    /// AccountsBodyUC
    /// </summary>
    public partial class AccountsBodyUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\AccountsBodyUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomGrid gdAccountsBodyUC;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\AccountsBodyUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomGroupBox gbBody;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\AccountsBodyUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomWrapPanel wpBody;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AccountsBodyUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomDataGrid dgBody;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AccountsBodyUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn dgColumnTaxClass;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\AccountsBodyUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomDataGridTextColumns dgColumnTaxRate;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\AccountsBodyUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomDataGridTextColumns dgNarration;
        
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
            System.Uri resourceLocater = new System.Uri("/FusilWPFApplication;component/accountsbodyuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AccountsBodyUC.xaml"
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
            this.gdAccountsBodyUC = ((FusilControlLib.CustomGrid)(target));
            return;
            case 2:
            this.gbBody = ((FusilControlLib.CustomGroupBox)(target));
            return;
            case 3:
            this.wpBody = ((FusilControlLib.CustomWrapPanel)(target));
            return;
            case 4:
            this.dgBody = ((FusilControlLib.CustomDataGrid)(target));
            return;
            case 5:
            this.dgColumnTaxClass = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 6:
            this.dgColumnTaxRate = ((FusilControlLib.CustomDataGridTextColumns)(target));
            return;
            case 7:
            this.dgNarration = ((FusilControlLib.CustomDataGridTextColumns)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

