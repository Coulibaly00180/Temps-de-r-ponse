using Moq;
using Temps.DAL;
using Temps.DTO;
using Xunit;

namespace Temps.SRV.Tests
{
    public class Machine_SRV_Tests
    {
        [Fact]
        public void Machine_SRV_GetById()
        {
            // Créer un mock du dépôt DAL
            var mockDepot = new Mock<IDepot_DAL<Machine_DAL>>();
            mockDepot.Setup(d => d.GetById(It.IsAny<int>())).Returns(new Machine_DAL(
                machineNumber: 1,
                machineName: "Machine 1",
                machineDescription: "Description de la machine 1",
                serviceDate: new DateTime(2023, 1, 1),
                signalTime: new DateTime(2023, 1, 1, 10, 0, 0),
                localTime: new DateTime(2023, 1, 1, 10, 0, 0)
            ));

            // Créer une instance du service Machine_SRV en utilisant le mock du dépôt
            var srv = new Machine_SRV(mockDepot.Object);

            // Appeler la méthode GetById du service
            var result = srv.GetById(1);

            // Vérifier les assertions
            Assert.NotNull(result);
            Assert.Equal(1, result.MachineNumber);
            Assert.Equal("Machine 1", result.MachineName);
            Assert.Equal("Description de la machine 1", result.MachineDescription);
            Assert.Equal(new DateTime(2023, 1, 1), result.ServiceDate);
            Assert.Equal(new DateTime(2023, 1, 1, 10, 0, 0), result.SignalTime);
            Assert.Equal(new DateTime(2023, 1, 1, 10, 0, 0), result.LocalTime);

            // Vérifier que la méthode GetById du dépôt a été appelée au moins une fois
            mockDepot.Verify(depot => depot.GetById(It.IsAny<int>()), Times.AtLeastOnce);
        }

        [Fact]
        public void Machine_SRV_GetAll()
        {
            // Créer une liste de machines de test
            var machines = new List<Machine_DAL>
            {
                new Machine_DAL(
                    machineNumber: 1,
                    machineName: "Machine 1",
                    machineDescription: "Description de la machine 1",
                    serviceDate: new DateTime(2023, 1, 1),
                    signalTime: new DateTime(2023, 1, 1, 10, 0, 0),
                    localTime: new DateTime(2023, 1, 1, 10, 0, 0)
                ),
                new Machine_DAL(
                    machineNumber: 2,
                    machineName: "Machine 2",
                    machineDescription: "Description de la machine 2",
                    serviceDate: new DateTime(2023, 1, 2),
                    signalTime: new DateTime(2023, 1, 2, 11, 0, 0),
                    localTime: new DateTime(2023, 1, 2, 11, 0, 0)
                )
            };

            // Créer un mock du dépôt DAL
            var mockDepot = new Mock<IDepot_DAL<Machine_DAL>>();
            mockDepot.Setup(d => d.GetAll()).Returns(machines);

            // Créer une instance du service Machine_SRV en utilisant le mock du dépôt
            var srv = new Machine_SRV(mockDepot.Object);

            // Appeler la méthode GetAll du service
            var results = srv.GetAll();

            // Vérifier les assertions
            Assert.NotNull(results);

            // Vérifier que la méthode GetAll du dépôt a été appelée au moins une fois
            mockDepot.Verify(depot => depot.GetAll(), Times.AtLeastOnce);
        }

        [Fact]
        public void Machine_SRV_Add()
        {
            // Créer un mock du dépôt DAL
            var mockDepot = new Mock<IDepot_DAL<Machine_DAL>>();

            // Créer une instance du service Machine_SRV en utilisant le mock du dépôt
            var srv = new Machine_SRV(mockDepot.Object);

            // Créer une machine à ajouter
            var machineToAdd = new Machine_DTO
            {
                MachineNumber = 1,
                MachineName = "Machine 1",
                MachineDescription = "Description de la machine 1",
                ServiceDate = new DateTime(2023, 1, 1),
                SignalTime = new DateTime(2023, 1, 1, 10, 0, 0),
                LocalTime = new DateTime(2023, 1, 1, 10, 0, 0)
            };

            // Appeler la méthode Add du service
            srv.Ajouter(machineToAdd);

            // Vérifier que la méthode Add du dépôt a été appelée une fois avec la machine à ajouter
            mockDepot.Verify(depot => depot.Insert(It.IsAny<Machine_DAL>()), Times.Once);
        }

        [Fact]
        public void Machine_SRV_Update()
        {
            // Créer un mock du dépôt DAL
            var mockDepot = new Mock<IDepot_DAL<Machine_DAL>>();

            // Créer une instance du service Machine_SRV en utilisant le mock du dépôt
            var srv = new Machine_SRV(mockDepot.Object);

            // Créer une machine à mettre à jour
            var machineToUpdate = new Machine_DTO
            {
                MachineNumber = 1,
                MachineName = "Machine 1",
                MachineDescription = "Description de la machine 1",
                ServiceDate = new DateTime(2023, 1, 1),
                SignalTime = new DateTime(2023, 1, 1, 10, 0, 0),
                LocalTime = new DateTime(2023, 1, 1, 10, 0, 0)
            };

            // Appeler la méthode Update du service
            srv.Modifier(machineToUpdate);

            // Vérifier que la méthode Update du dépôt a été appelée une fois avec la machine à mettre à jour
            mockDepot.Verify(depot => depot.Update(It.IsAny<Machine_DAL>()), Times.Once);
        }

        [Fact]
        public void Machine_SRV_Delete()
        {
            // Créer un mock du dépôt DAL
            var mockDepot = new Mock<IDepot_DAL<Machine_DAL>>();

            // Créer une instance du service Machine_SRV en utilisant le mock du dépôt
            var srv = new Machine_SRV(mockDepot.Object);

            // ID de la machine à supprimer
            var machineId = 1;

            // Appeler la méthode Delete du service
            srv.Supprimer(machineId);

            // Vérifier que la méthode Delete du dépôt a été appelée une fois avec l'ID de la machine à supprimer
            mockDepot.Verify(depot => depot.Delete(machineId), Times.Once);
        }
    }
}

