using System.ComponentModel;

namespace Maui.Mountain
{
    public class Mountainek : INotifyPropertyChanged  // interfész felelős UI felé küldséről a megváltoztatott adatokról 
    {
        private bool isClimbed;

        public string Name { get; set; }
        public int Height { get; set; }      //Egyértelmű paraméterek

        public bool IsClimbed
        {
            get => isClimbed;  //lekéri az isClimbed értéket
            set
            {
                if (isClimbed != value)                   // set-el új értéket adunk neki, ha nem egyezik meg vele
                {
                    isClimbed = value;                    // beállítjuk az új értéket
                    OnPropertyChanged(nameof(IsClimbed)); // Értesítjük az UI-t az új értékről
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; // ez kerül meghívásra ha egy tulajdonság megváltozik
        protected virtual void OnPropertyChanged(string propertyName)  // Értesíti a felületet a változásról (megváltozott tulajdonság neve))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }                 // ? azt jelenti, hogy a PropertyChanged esemény nem null
    }
}
