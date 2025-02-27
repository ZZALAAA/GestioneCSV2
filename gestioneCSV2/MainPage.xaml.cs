using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace gestioneCSV2
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Articolo> Articoli { get; set; }
        private GestioneArticoli _gestioneArticoli;

        public MainPage()
        {
            InitializeComponent();
            _gestioneArticoli = new GestioneArticoli();
            Articoli = _gestioneArticoli.ElencoArticoli;
        }
        private void OnLoadCsvClicked(object sender, EventArgs e)
        {
            try
            {
                int numeroRighe = _gestioneArticoli.LeggiDati();
                LblNumeroRighe.Text = $"Numero di righe lette: {numeroRighe}";
            }
            catch (Exception eccezione)
            {
                DisplayAlert("Errore", eccezione.Message, "OK");
            }
        }
    }
}
