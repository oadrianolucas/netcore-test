using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Einstein.Controllers;
using Einstein.Models;
using Moq;
using Einstein.Data;
using Xunit;

namespace Einstein.Tests.Controllers
{
    public class MedicalsControllerTest
    {
        private MedicalsController medicalsController;

        public MedicalsControllerTest()
        {
            medicalsController = new MedicalsController(new Mock<EinsteinContext>().Object);
        }
        [Fact]
        public void Get_AppointmentsId()
        {
           
        }
    }
}