using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Reflection.PortableExecutable;
using System.Text;
using Temps.Console.Models;
using static System.Net.WebRequestMethods;

namespace MachineMonitor
{
    class Program
    {
        private const string ApiBaseUrl = "https://localhost:7236";
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            // Récupérer les valeurs de configuration
            int machineNumberC = int.Parse(ConfigurationManager.AppSettings["MachineNumber"]);
            int intervalSeconds = int.Parse(ConfigurationManager.AppSettings["IntervalSeconds"]);

            Console.WriteLine($"Console Machine {machineNumberC}, Intervalle d'envoi du signal: {intervalSeconds} secondes");

            while (true) 
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    try
                    {
                        var machineData = new MachineData()
                        {
                            machineNumber = machineNumberC,
                            SignalTime = DateTime.Now,
                            LocalTime = DateTime.Now,
                        };

                        string json = JsonConvert.SerializeObject(machineData);

                        var response = await httpClient.GetAsync($"{ApiBaseUrl}/Machine/showAll");
                        Console.WriteLine("Signal reçu avec succès");

                        // Mise à jour
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var responseUpdate = await httpClient.PatchAsync($"{ApiBaseUrl}/Machine/updateSignal/{machineNumberC}", content);

                        if (responseUpdate.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Machine update avec succès !");
                            Console.WriteLine(DateTime.Now);
                        }
                        else
                        {
                            Console.WriteLine("Erreur lors de la modification de la machine : " + responseUpdate.StatusCode);
                        }

                        // Attendre l'intervalle spécifié
                        await Task.Delay(intervalSeconds * 1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur de signal " + ex.Message);
                        // Attendre avant de réessayer
                        await Task.Delay(intervalSeconds * 1000);
                    }
                    finally
                    {
                        httpClient.Dispose();
                    }
                }
            }

            
        }
    }
}

