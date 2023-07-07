using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using Temps.WPF.Models;

namespace Temps.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PageAjouter : Window
    {
        private const string ApiBaseUrl = "https://localhost:7236";
        
        public PageAjouter()
        {
            InitializeComponent();
        }

        private async void CreateMachineButton(object sender, RoutedEventArgs e)
        {
            string nom = NomTextBox.Text;
            string description = DescriptionTextBox.Text;
            DateTime dateEntreeService = DateEntreeServiceDatePicker.SelectedDate.GetValueOrDefault();
                var machine = new MachineData
                {
                    MachineName = nom,
                    MachineDescription = description,
                    ServiceDate = dateEntreeService,
                    SignalTime = DateTime.Now,
                    LocalTime = DateTime.Now,
                };

            if (nom == null || description == null || dateEntreeService == null)
            {
                MessageBox.Show("Veuillez remplir les champs vide");
            }
            else 
            {
                await AjouterMachine(machine);
            }
                
        }

        private async Task AjouterMachine(MachineData machine)
        {
            
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(machine);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{ApiBaseUrl}/Machine/create", content);

                    if (response.IsSuccessStatusCode)
                    {
                        // MessageBox.Show(json);
                        MessageBox.Show("Machine ajoutée avec succès !");
                        
                        NomTextBox.Text = string.Empty;
                        DescriptionTextBox.Text = string.Empty;
                        DateEntreeServiceDatePicker.SelectedDate = null;
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de l'ajout de la machine : " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur s'est produite : " + ex.Message);
                }
            }
        }

        private void RetourButton(object sender, RoutedEventArgs e)
        {
            WinPrincipale win = new WinPrincipale();
            win.Show();
            Close();
        }
    }
}
