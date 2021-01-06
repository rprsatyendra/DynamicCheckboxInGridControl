using DevExpress.Mvvm.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using DXGridSample.Annotations;
using System.Windows.Input;

namespace DXGridSample {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }

    [POCOViewModel]
    public class MainViewModel {
        public ObservableCollection<Item> Items { get; set; }
        public ObservableCollection<Column> Columns { get; set; }

        public MainViewModel() {

            Columns = new ObservableCollection<Column> {
                new StaticColumn { ColumnName = "StaticColumn" },
                new DynamicColumn { ColumnName = "DynamicColumn1" },
                new DynamicColumn { ColumnName = "DynamicColumn2" },
                new DynamicColumn { ColumnName = "DynamicColumn3" },
                new DynamicColumn { ColumnName = "DynamicColumn4" },
            };

            Items = new ObservableCollection<Item>();
            for (int i = 1; i <= 3; i++) {
                var item = new Item { StaticColumn = $"Static : {i}" };
                if(i == 1)
                {
                    //item.DynamicValues["DynamicColumn1"] = new Info { Value = true };
                    item.DynamicValues["DynamicColumn2"] = new Info { Value = true };
                    //item.DynamicValues["DynamicColumn3"] = new Info { Value = null };
                    item.DynamicValues["DynamicColumn4"] = new Info { Value = true };
                }
                else if(i == 2)
                {
                    item.DynamicValues["DynamicColumn1"] = new Info { Value = true };
                    item.DynamicValues["DynamicColumn2"] = new Info { Value = false };
                    item.DynamicValues["DynamicColumn3"] = new Info { Value = true };
                    //item.DynamicValues["DynamicColumn4"] = new Info { Value = null };
                }
                else if(i == 3)
                {
                    //item.DynamicValues["DynamicColumn1"] = new Info { Value = i % 1 == 0 };
                    item.DynamicValues["DynamicColumn2"] = new Info { Value = false };
                    item.DynamicValues["DynamicColumn3"] = new Info { Value = false };
                    item.DynamicValues["DynamicColumn4"] = new Info { Value = true };
                }

                Items.Add(item);
            }
        }
    }

    public class Item {
        public string StaticColumn { get; set; }
        public Dictionary<string, Info> DynamicValues { get; set; }

        public Dictionary<string, Info> DynamicValuesNotDeployed { get; set; }
        public Item() {
            DynamicValues = new Dictionary<string, Info>();
            DynamicValuesNotDeployed = new Dictionary<string, Info>();
        }
    }

    public class Info : INotifyPropertyChanged {
        private bool? _value;
        public bool? Value {
            get { return _value; }
            set {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}