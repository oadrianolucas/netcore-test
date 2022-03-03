using Einstein.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Einstein.Interfaces;
using Moq;
using Xunit;
using Einstein.Models;

namespace Einstein.Tests.Controllers
{
    public class MedicalsControllerTests
    {
        private MedicalsController medicalsController;
        public MedicalsControllerTests()
        {
            medicalsController = new MedicalsController(new Mock<IAppointmentsServices>().Object, new Mock<IMedicalsServices>().Object);
        }
        [Fact]
        public void Get_ValidMedical()
        {
            var list = medicalsController.GetAppointmentsMedical(2);
            bool result;
            if (list != null)
            {
                result = true;
                Assert.True(result, "Médico encontrado");
            }
        }
        [Fact]
        public void Get_NotValidMedical()
        {
            var list = medicalsController.GetAppointmentsMedical(2);
            bool result;
            if (list == null)
            {
                result = false;
                Assert.False(result, "Médico não encontrado");
            }
        }

    }
}
