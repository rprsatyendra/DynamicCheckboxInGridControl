using System.Windows;
using System.Windows.Controls;

namespace DXGridSample {
    public abstract class Column {
        public string ColumnName { get; set; }
    }
    public class StaticColumn : Column { }
    public class DynamicColumn : Column {
        public string ValuePath => $"DynamicValues[{ColumnName}].Value";
    }

    public class ColumnTemplateSelector : DataTemplateSelector {
        public DataTemplate StaticColumnTemplate { get; set; }
        public DataTemplate DynamicColumnTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            if(item is StaticColumn)
                return StaticColumnTemplate;
            if(item is DynamicColumn)
                return DynamicColumnTemplate;
            return base.SelectTemplate(item, container);
        }
    }
}
