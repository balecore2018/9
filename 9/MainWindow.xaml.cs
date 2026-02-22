using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace _9
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Boets> Warriors { get; set; }
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            Warriors = new ObservableCollection<Boets>
            {
                new Bystrik(),
                new VasyaSToporom(),
                new Shkaf()
            };

            DataContext = this;
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            var target = button?.CommandParameter as Boets;

            if (target == null || target.Health <= 0) return;

            int damage = random.Next(10, 31);
            int oldHealth = target.Health;

            target.OyBolnlo(damage);

            int actualDamage = oldHealth - target.Health;
            LogList.Items.Add($"{target.Name} получил {actualDamage} урона. Осталось: {target.Health}");

            if (target.Health <= 0)
            {
                LogList.Items.Add($"{target.Name} погиб!");
            }
        }
    }
}