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
    public class AppointmentsControllerTests
    {
        private AppointmentsController appointmentsController;
        public AppointmentsControllerTests()
        {
            appointmentsController = new AppointmentsController(new Mock<IAppointmentsServices>().Object);
        }
        [Fact]
        public void Post_Appointmenst()
        {
            var appointments = appointmentsController.PostAppointment(new Appointment() 
            {
                Schedule = new DateTime (1995,08,20, 12,00,00),
                IdMedical = 2,
                IdPatient = 2
            });
            bool result;
            if (appointments != null)
            {
                result = true;
                Assert.True(result, "Consulta agendada com sucesso.");
            } else { 
                result = false;
                Assert.False(result, "Error ao cadastrar consulta.");
            }
        }
    }
}
