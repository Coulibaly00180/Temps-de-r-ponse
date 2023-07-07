using Moq;
using Temps.API.Controllers;
using Temps.DTO;
using Temps.SRV;
using Xunit;

namespace Temps.API.Tests
{
    public class MachineController_Tests
    {
        [Fact]
        public void MachineController_Constructeur()
        {
            // Toujours du AAA
            // Préparer un mock du service
            var mock = new Mock<IMachine_SRV<Machine_DTO>>();

            // Instancier le controller
            var ctlr = new MachineController(mock.Object);

            // Vérifier le type du controller
            Assert.IsType<MachineController>(ctlr);
        }

        [Fact]
        public void MachineController_GetById()
        {
            // Toujours du AAA
            // Préparer un mock du service
            var mock = new Mock<IMachine_SRV<Machine_DTO>>();

            // Je crée une fausse méthode GetById dans mon mock
            mock.Setup(srv => srv.GetById(It.IsAny<int>())).Returns(new Machine_DTO()
            {
                MachineNumber = 1,
                MachineName = "Machine 1",
                MachineDescription = "Description de la machine 1",
                ServiceDate = new DateTime(2023, 1, 1),
                SignalTime = new DateTime(2023, 1, 1, 10, 0, 0),
                LocalTime = new DateTime(2023, 1, 1, 10, 0, 0)
            });

            // Instancier le controller
            var ctlr = new MachineController(mock.Object);

            // Appeler la méthode GetById du controller
            var result = ctlr.GetById(1);

            // Vérifier les assertions
            Assert.NotNull(result);
            Assert.IsType<Machine_DTO>(result);

            // Vérifier que la méthode GetById du service a été appelée une fois
            mock.Verify(srv => srv.GetById(It.IsAny<int>()), Times.Once);
        }
    }
}
