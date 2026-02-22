using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _9
{
    public class Boets : INotifyPropertyChanged
    {
        private int _health = 100;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public string Emoji { get; set; }

        public int Health
        {
            get => _health;
            set
            {
                _health = value > 0 ? value : 0;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HealthText));
            }
        }

        public string HealthText => $"{Emoji} {Health}/{(this is Shkaf ? 150 : 100)}";

        public Boets(string name, string emoji)
        {
            Name = name;
        }

        public virtual void OyBolnlo(int damage)
        {
            Health -= damage;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class Bystrik : Boets
    {
        public Bystrik() : base("Славяновка", "") { }

        public override void OyBolnlo(int damage)
        {
            Health -= (int)(damage * 0.6);
        }
    }
    public class VasyaSToporom : Boets
    {
        public VasyaSToporom() : base("ПКПС", "") { }
    }
    public class Shkaf : Boets
    {
        public Shkaf() : base("Авиатехникум", "")
        {
            Health = 150;
        }

        public override void OyBolnlo(int damage)
        {
            Health -= (int)(damage * 1.2);
        }
    }
}