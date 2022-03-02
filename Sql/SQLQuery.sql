use Einstein;
CREATE TABLE Medical (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,
	Specialty VARCHAR(255) NOT NULL,
	Cfm INT NOT NULL,
	Birth DATE NOT NULL
);
CREATE TABLE Patient (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(255) NOT NULL,
	Birth DATE NOT NULL
);
CREATE TABLE Appointment (
	Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Schedule  DATETIME NOT NULL,
	IdMedical INT NOT NULL,
	IdPatient INT NOT NULL
);

/* Insert Into Medical */
use Einstein;
INSERT INTO Medical VALUES ('Victor Vergueiro', 'Otorrinolaringologista', '048963578', '17/7/1983');
INSERT INTO Medical VALUES ('Vinícius Laporte', 'Ginecologista', '875369840', '6/9/1976');
INSERT INTO Medical VALUES ('Rafael Setubal', 'Urologista', '048963578', '11/11/1988');
INSERT INTO Medical VALUES ('Nicolas Ferreira', 'Oncologista', '489363578', '27/2/1966');
SELECT * FROM Medical;

/* Insert Into Patient */
use Einstein;
INSERT INTO Patient VALUES ('Rodnei Machado', '6/1/1986');
INSERT INTO Patient VALUES ('Amanda Silva', '14/6/1986');
INSERT INTO Patient VALUES ('Helma Maria', '23/12/1986');
INSERT INTO Patient VALUES ('Mohamad Segal', '11/7/1986');
SELECT * FROM Patient;

/* Insert Into Appointment */
use Einstein;
INSERT INTO Appointment VALUES ('17-09-22 11:00:00 AM', 1, 2);
INSERT INTO Appointment VALUES ('22-02-22 14:00:00 PM', 3, 1);
INSERT INTO Appointment VALUES ('11-07-22 16:00:00 PM', 2, 3);
INSERT INTO Appointment VALUES ('02-11-22 12:00:00 PM', 4, 4);
SELECT * FROM Appointment;
