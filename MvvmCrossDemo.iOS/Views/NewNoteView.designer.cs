// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MvvmCrossDemo.iOS.Views
{
    [Register ("NewNoteView")]
    partial class NewNoteView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DetailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SaveButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TitleTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DetailTextField != null) {
                DetailTextField.Dispose ();
                DetailTextField = null;
            }

            if (SaveButton != null) {
                SaveButton.Dispose ();
                SaveButton = null;
            }

            if (TitleTextField != null) {
                TitleTextField.Dispose ();
                TitleTextField = null;
            }
        }
    }
}