using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SnakesLaddersMon
{
    public class Settings : INotifyPropertyChanged
    {
        private string grid_colour1;
        private string grid_colour2;

        public string GRID_COLOUR1
        {
            get => grid_colour1;
            set
            {
                if(grid_colour1 != value) {
                    grid_colour1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string GRID_COLOUR2
        {
            get => grid_colour2;
            set
            {
                if (grid_colour2 != value) {
                    grid_colour2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public Settings() {
            GRID_COLOUR1 = "#2B0B98";
            GRID_COLOUR2 = "#2B0B98";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SaveSettingsJson() {
            string filename = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "settings.json");
            WritetoJson(filename);
        }

        private bool WritetoJson(string filename) {
            string jsonalice = JsonSerializer.Serialize(this);
            try {
                using (StreamWriter writer = new StreamWriter(filename)) {
                    writer.Write(jsonalice);
                }
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
