﻿#pragma checksum "..\..\..\TreeViewStudent.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "17E6BF82E00901A8DA2E25E3A53452F8"
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
    /// TreeViewStudent
    /// </summary>
    public partial class TreeViewStudent : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomGrid gdTree;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomWrapPanel wpColumn1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView treeControl;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomStackPanel spButtons;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomButtons btnSave;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomButtons btnClear;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomButtons btnGroup;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomButtons btnMaster;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\TreeViewStudent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FusilControlLib.CustomGrid gdChild;
        
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
            System.Uri resourceLocater = new System.Uri("/FusilWPFApplication;component/treeviewstudent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TreeViewStudent.xaml"
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
            this.gdTree = ((FusilControlLib.CustomGrid)(target));
            return;
            case 2:
            this.wpColumn1 = ((FusilControlLib.CustomWrapPanel)(target));
            return;
            case 3:
            this.treeControl = ((System.Windows.Controls.TreeView)(target));
            
            #line 13 "..\..\..\TreeViewStudent.xaml"
            this.treeControl.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.treeControl_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.spButtons = ((FusilControlLib.CustomStackPanel)(target));
            return;
            case 5:
            this.btnSave = ((FusilControlLib.CustomButtons)(target));
            
            #line 25 "..\..\..\TreeViewStudent.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnClear = ((FusilControlLib.CustomButtons)(target));
            
            #line 26 "..\..\..\TreeViewStudent.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnGroup = ((FusilControlLib.CustomButtons)(target));
            
            #line 27 "..\..\..\TreeViewStudent.xaml"
            this.btnGroup.Click += new System.Windows.RoutedEventHandler(this.btnGroup_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnMaster = ((FusilControlLib.CustomButtons)(target));
            
            #line 28 "..\..\..\TreeViewStudent.xaml"
            this.btnMaster.Click += new System.Windows.RoutedEventHandler(this.btnMaster_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.gdChild = ((FusilControlLib.CustomGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

