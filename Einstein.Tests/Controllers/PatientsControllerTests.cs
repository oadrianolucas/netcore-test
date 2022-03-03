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
    public class PatientsControllerTests
    {
        private PatientsController patientsController;
        public PatientsControllerTests()
        {
            patientsController = new PatientsController(new Mock<IAppointmentsServices>().Object, new Mock<IPatientsServices>().Object);
        }
        [Fact]
        public void Get_ValidPatient()
        {
            var list = patientsController.GetAppointmentsPatient(2);
            bool result;
            if (list != null)
            {
                result = true;
                Assert.True(result, "Paciente encontrado");
            }
        }
        [Fact]
        public void Get_NotValidPatient()
        {
            var list = patientsController.GetAppointmentsPatient(2);
            bool result;
            if (list == null)
            {
                result = false;
                Assert.False(result, "Paciente não encontrado");
            }
        }

    }
}
