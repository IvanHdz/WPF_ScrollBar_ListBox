using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace AutoScroll.ListBox
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<EquipmentItem> m_selectedEquipmentHorizontal = new ObservableCollection<EquipmentItem>();
        private ObservableCollection<EquipmentItem> m_selectedEquipmentVertical = new ObservableCollection<EquipmentItem>();

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            ObservableCollection<EquipmentItem> equipmentList1 = new ObservableCollection<EquipmentItem>();
            this.horizontalListBox.ItemsSource = equipmentList1;
            CreateEquipments(equipmentList1, "Tank-");
            this.horizontalSelectedItemsListBox.ItemsSource = m_selectedEquipmentHorizontal;

            ObservableCollection<EquipmentItem> equipmentList2 = new ObservableCollection<EquipmentItem>();
            this.verticalListBox.ItemsSource = equipmentList2;
            CreateEquipments(equipmentList2, "Tank-");
            this.verticalSelectedItemsListBox.ItemsSource = m_selectedEquipmentVertical;
        }

        private ObservableCollection<EquipmentItem> CreateEquipments(ObservableCollection<EquipmentItem> equipmentList, string prefix)
        {
            int maxItemCount = 20;
            for (int i = 0; i < maxItemCount; i++)
            {
                equipmentList.Add(new EquipmentItem() { Name = prefix + i.ToString(), CampaignName = "Batch_ " + i.ToString() });
            }
            return equipmentList;
        }

        private void HorizontalListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                foreach (EquipmentItem item in e.AddedItems)
                {
                    m_selectedEquipmentHorizontal.Add(item);
                }
            }

            if (e.RemovedItems.Count > 0)
            {
                foreach (EquipmentItem item in e.RemovedItems)
                {
                    m_selectedEquipmentHorizontal.Remove(item);
                }
            }
        }

        private void VerticalListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                foreach (EquipmentItem item in e.AddedItems)
                {
                    m_selectedEquipmentVertical.Add(item);
                }
            }

            if (e.RemovedItems.Count > 0)
            {
                foreach (EquipmentItem item in e.RemovedItems)
                {
                    m_selectedEquipmentVertical.Remove(item);
                }
            }
        }
    }
}