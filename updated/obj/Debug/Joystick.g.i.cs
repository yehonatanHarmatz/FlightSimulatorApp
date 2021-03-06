﻿#pragma checksum "..\..\Joystick.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "52ECBEBDB7379055C4B77B440F9C5739C4E9DAFE6E29191D827CF255FCA246D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace FlightSimulatorApp {
    
    
    /// <summary>
    /// Joystick
    /// </summary>
    public partial class Joystick : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Joystick.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Base;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Joystick.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse BorderMouse;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Joystick.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse BorderStick;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Joystick.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Knob;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Joystick.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse KnobBase;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\Joystick.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.TranslateTransform knobPosition;
        
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
            System.Uri resourceLocater = new System.Uri("/FlyingSimulator;component/joystick.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Joystick.xaml"
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
            this.Base = ((System.Windows.Controls.Canvas)(target));
            
            #line 9 "..\..\Joystick.xaml"
            this.Base.MouseMove += new System.Windows.Input.MouseEventHandler(this.onMouseMove);
            
            #line default
            #line hidden
            
            #line 10 "..\..\Joystick.xaml"
            this.Base.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.onMouseMove);
            
            #line default
            #line hidden
            
            #line 10 "..\..\Joystick.xaml"
            this.Base.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.onMouseMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BorderMouse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 3:
            this.BorderStick = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 4:
            this.Knob = ((System.Windows.Controls.Canvas)(target));
            return;
            case 5:
            this.KnobBase = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 6:
            this.knobPosition = ((System.Windows.Media.TranslateTransform)(target));
            return;
            case 7:
            
            #line 121 "..\..\Joystick.xaml"
            ((System.Windows.Media.Animation.Storyboard)(target)).Completed += new System.EventHandler(this.centerKnob_Completed);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

