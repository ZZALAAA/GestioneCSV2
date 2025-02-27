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

        }
        private void OnLoadCsvClicked(object sender, EventArgs e)
        {
            try
            {
                _gestioneArticoli = new GestioneArticoli();
                List<Articolo> ListaDiArticoli= _gestioneArticoli.LeggiDati();
                ListaArticoli.ItemsSource = ListaDiArticoli;

            }
            catch (Exception eccezione)
            {
                DisplayAlert("Errore", eccezione.Message, "OK");
            }
        }
    }
}
