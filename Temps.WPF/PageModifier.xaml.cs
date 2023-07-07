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
    public partial class PageModifier : Window
    {
        private const string ApiBaseUrl = "https://localhost:7236";
        
        public PageModifier(MachineData selectedMachine)
        {
            InitializeComponent();

            NumeroTextBox.Text = selectedMachine.machineNumber.ToString();
            NomTextBox.Text = selectedMachine.MachineName;
            DescriptionTextBox.Text = selectedMachine.MachineDescription;
            DateEntreeServiceDatePicker.SelectedDate = selectedMachine.ServiceDate;
        }

        private async void ModifyMachineButton(object sender, RoutedEventArgs e)
        {
            string numero = NumeroTextBox.Text;
            string nom = NomTextBox.Text;
            string description = DescriptionTextBox.Text;
            DateTime dateEntreeService = DateEntreeServiceDatePicker.SelectedDate.GetValueOrDefault();

            if (int.TryParse(numero, out int numeroInt))
            {
                var machine = new MachineData
                {
                    machineNumber = numeroInt,
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
                    await ModifierMachine(machine, numeroInt);
                }
            }
        }


        private async Task ModifierMachine(MachineData machine, int machineNumber)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string json = JsonConvert.SerializeObject(machine);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"{ApiBaseUrl}/Machine/update/{machineNumber}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Machine modifiée avec succès !");

                        WinPrincipale winPrincipale = new WinPrincipale();
                        winPrincipale.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la modification de la machine : " + response.StatusCode);
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
