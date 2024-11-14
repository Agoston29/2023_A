using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Mountain
{
    public class MountainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Mountainek> Mountains { get; set; }  // hegyek objektumok gyűjteménye (autamata UI értesítés magától! azért kell ez a kollekció)

        private Mountainek selectedMountain;                     // kiválaszott hegyet tárol
        public Mountainek SelectedMountain
        {
            get => selectedMountain;                             //lekéri az selectedMountain értéket
            set
            {
                if (selectedMountain != value)   
                {
                    selectedMountain = value;                    // beállítjuk az új értéket
                    OnPropertyChanged(nameof(SelectedMountain)); // Értesítjük az UI-t az új értékről
                }
            }
        }


        public Command ClearClimbsCommand { get; } // parancsot képvisel az UI számára

        public MountainViewModel()  // létrehozza a hegyeket és a törlés commandot 
        {
            Mountains = new ObservableCollection<Mountainek>  // alapértelmezett elemek behelyezése
        {
            new Mountainek { Name = "János-hegy", Height = 527, IsClimbed = false },
            new Mountainek { Name = "Kis-Hárs-hegy", Height = 362, IsClimbed = false },
            new Mountainek { Name = "Nagy-Hárs-hegy", Height = 454, IsClimbed = false },
            new Mountainek { Name = "Hármashatár-hegy", Height = 495, IsClimbed = false }
        };

            ClearClimbsCommand = new Command(ClearClimbs);  // inicializáljuk aztán már EZ lesz hozzárendelhető egy gombhoz
        }

        private void ClearClimbs()
        {
            foreach (var mountain in Mountains)     // végigmegy a hegyeken
            {
                mountain.IsClimbed = false;         // minden hegy megmászott értékét hamisra állitja
            }
            OnPropertyChanged(nameof(Mountains));   // Értesítjük az UI-t az új értékről
        }

        public event PropertyChangedEventHandler PropertyChanged; // ez kerül meghívásra ha egy tulajdonság megváltozik
        protected virtual void OnPropertyChanged(string propertyName)  // Értesíti a felületet a változásról (megváltozott tulajdonság neve))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                        // ? azt jelenti, hogy a PropertyChanged esemény nem null
        }
    }

}
