using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _9
{
    public class Boets : INotifyPropertyChanged
    {
        private int _health = 100;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

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

        public string HealthText => $"{Health}/{(this is Slava ? 150 : 100)}";

        public Boets(string name)
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
    public class Slava : Boets
    {
        public Slava() : base("Славяновка") { }

        public override void OyBolnlo(int damage)
        {
            Health -= (int)(damage * 0.6);
        }
    }
    public class PKPS : Boets
    {
        public PKPS() : base("ПКПС") { }
    }
    public class Avik : Boets
    {
        public Avik() : base("Авиатехникум")
        {
            Health = 150;
        }

        public override void OyBolnlo(int damage)
        {
            Health -= (int)(damage * 1.2);
        }
    }
}