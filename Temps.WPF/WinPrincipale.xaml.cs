using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Net.Http;
using Temps.WPF.Models;
using Newtonsoft.Json.Linq;

namespace Temps.WPF
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class WinPrincipale : Window
    {
        private const string ApiBaseUrl = "https://localhost:7236";

        // Machine selectionné dans listView
        private MachineData selectedMachine;

        public List<MachineData> Machines { get; set; }
        public WinPrincipale()
        {
            InitializeComponent();
            // Machines = new List<MachineData>();
            LoadMachines();
        }


        private async void LoadMachines()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync($"{ApiBaseUrl}/Machine/showAll");

                    if (response.IsSuccessStatusCode)
                    {

                        string apiResponse = await response.Content.ReadAsStringAsync();
                        List<MachineData> apiData = JsonConvert.DeserializeObject<List<MachineData>>(apiResponse);

                        // Machines.AddRange(apiData);

                        foreach (MachineData machine in apiData)
                        {
                            myListView.Items.Add(machine);
                        }

                        // OnPropertyChanged(nameof(Machines));
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la récupération des machines : " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                }
                finally
                {
                    httpClient.Dispose();
                }
            }
        }

        // Aller à la fenêtre PageAjouter
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            PageAjouter pageAjouter = new PageAjouter();
            pageAjouter.Show();
            Close();
        }

        // Supprimer une Machine
        private async void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMachine != null)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    try
                    {
                        var response = await httpClient.DeleteAsync($"{ApiBaseUrl}/Machine/delete/{selectedMachine.machineNumber}");

                        if (response.IsSuccessStatusCode)
                        {

                            myListView.Items.Clear();

                            LoadMachines();
                        }
                        else
                        {
                            MessageBox.Show("Échec de la suppression de la machine : " + response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la suppression de la machine : " + ex.Message);
                    }
                    finally
                    {
                        httpClient.Dispose();
                    }

                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionnez une machine à supprimer");
            }
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (selectedMachine != null)
            {
                PageModifier pageModifier = new PageModifier(selectedMachine);
                pageModifier.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Veuillez selectionnez une machine à modifier");
            }
        }

        // Selection une machine dans listview
        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMachine = (MachineData)myListView.SelectedItem;

        }
    }
}
