using DevExpress.Xpf.Grid;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DXGridSample {
    public static class CheckBoxHelper
    {
        public static readonly DependencyProperty CheckBoxPathProperty =
            DependencyProperty.RegisterAttached("CheckBoxPath", typeof(string), typeof(CheckBoxHelper), new PropertyMetadata(null, (d, e) =>
            {
                if (e.NewValue == null) return;

                var checkBox = d as CheckBox;
                checkBox?.SetBinding(CheckBox.IsCheckedProperty, new Binding((string)e.NewValue));
            }));
        public static string GetCheckBoxPath(DependencyObject obj)
        {
            return (string)obj.GetValue(CheckBoxPathProperty);
        }
        public static void SetCheckBoxPath(DependencyObject obj, string value)
        {
            obj.SetValue(CheckBoxPathProperty, value);
        }
    }

    public static class BindingHelper {


        public static string GetBindingPath(DependencyObject obj) {
            return (string)obj.GetValue(BindingPathProperty);
        }

        public static void SetBindingPath(DependencyObject obj, string value) {
            obj.SetValue(BindingPathProperty, value);
        }

        // Using a DependencyProperty as the backing store for BindingPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindingPathProperty =
            DependencyProperty.RegisterAttached("BindingPath", typeof(string), typeof(BindingHelper ), new PropertyMetadata(null, (d,e)=> {
                if(e.NewValue == null) return;

                var column = d as GridColumn;
                Binding b = new Binding(e.NewValue as string);
                b.Mode = BindingMode.TwoWay;
                column.Binding = b;
            }));
    }
}
