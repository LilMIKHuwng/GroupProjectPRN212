﻿#pragma checksum "..\..\..\MatchesDetail.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AEA9F566588AE9CADEFB8487C645332BD1B76493"
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
using ViewEuroMatchManagerment;


namespace ViewEuroMatchManagerment {
    
    
    /// <summary>
    /// MatchesDetail
    /// </summary>
    public partial class MatchesDetail : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TitleLabel;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox HomeTeamComboBox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GuestTeamComboBox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IdMatchLable;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IdMatchTextBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GoalHomeTeamTextBox;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GoalGuestTeamTextBox;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AttendanceTextBox;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QuitButton;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\MatchesDetail.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox LocationComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ViewEuroMatchManagerment;V1.0.0.0;component/matchesdetail.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MatchesDetail.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\MatchesDetail.xaml"
            ((ViewEuroMatchManagerment.MatchesDetail)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Windown_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TitleLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.HomeTeamComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 45 "..\..\..\MatchesDetail.xaml"
            this.HomeTeamComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.HomeTeamComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GuestTeamComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 52 "..\..\..\MatchesDetail.xaml"
            this.GuestTeamComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.GuestTeamComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.IdMatchLable = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.IdMatchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.GoalHomeTeamTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.GoalGuestTeamTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.AttendanceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\..\MatchesDetail.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.QuitButton = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\MatchesDetail.xaml"
            this.QuitButton.Click += new System.Windows.RoutedEventHandler(this.QuitButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.LocationComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 132 "..\..\..\MatchesDetail.xaml"
            this.LocationComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.HomeTeamComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

