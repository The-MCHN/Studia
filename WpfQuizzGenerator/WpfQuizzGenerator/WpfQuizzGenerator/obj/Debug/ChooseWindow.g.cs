#pragma checksum "..\..\ChooseWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "796404385C4D8FDCAC2BCC3CE0BB447EE95AA69F9A6ED480EF4E09345F355707"
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
using WpfQuizzGenerator;


namespace WpfQuizzGenerator {
    
    
    /// <summary>
    /// ChooseWindow
    /// </summary>
    public partial class ChooseWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\ChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Load_Text;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Load_Quiz;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Load_Button;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Create_New;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ChooseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Choose_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfQuizzGenerator;component/choosewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChooseWindow.xaml"
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
            this.Load_Text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Load_Quiz = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.Load_Button = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ChooseWindow.xaml"
            this.Load_Button.Click += new System.Windows.RoutedEventHandler(this.Load_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Create_New = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ChooseWindow.xaml"
            this.Create_New.Click += new System.Windows.RoutedEventHandler(this.Create_New_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Choose_Button = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\ChooseWindow.xaml"
            this.Choose_Button.Click += new System.Windows.RoutedEventHandler(this.Choose_Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

