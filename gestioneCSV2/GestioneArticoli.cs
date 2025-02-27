using gestioneCSV2;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

public class GestioneArticoli
{
    public ObservableCollection<Articolo> ElencoArticoli { get; }

    public GestioneArticoli()
    {
        ElencoArticoli = new ObservableCollection<Articolo>();
    }

    public int LeggiDati()
    {
        int numeroRighe = 0;
        bool intestazione = true;

        string percorsoRelativo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.csv");

        using (FileStream stream = new FileStream(percorsoRelativo, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream && numeroRighe < 30)
            {
                // leggo una riga dal file
                string riga = reader.ReadLine();

                if (intestazione)
                {
                    intestazione = false;
                    continue;
                }

                // splitto la riga in base al carattere ','
                string[] celle = riga.Split(',');

                // creo l'oggetto canzone
                Articolo articolo = new Articolo();

                articolo.ID = celle[0];
                articolo.Nome = celle[1];
                articolo.Prezzo = double.Parse(celle[2]);
                articolo.Quantità = int.Parse(celle[3]);


                // aggiungo l'oggetto partita alla lista
                ElencoArticoli.Add(articolo);

                // incremento il contatore delle righe
                numeroRighe++;
            }
        }

        return numeroRighe;
    }
}
