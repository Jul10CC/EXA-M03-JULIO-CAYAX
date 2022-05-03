namespace EXA_M03_JULIO_CAYAX.Migrations
{
    using EXA_M03_JULIO_CAYAX.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EXA_M03_JULIO_CAYAX.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EXA_M03_JULIO_CAYAX.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Catedraticos
            context.Catedraticos.AddOrUpdate(new Catedratico[]
            {
                new Catedratico() { CatedraticoId = 1, Nombre ="Frida", Apellido = "Hernandez", Especialidad="Ciencias Economicas"},
                new Catedratico() { CatedraticoId = 2, Nombre ="Kevin", Apellido = "Gonzalez", Especialidad="Derecho"},
                new Catedratico() { CatedraticoId = 3, Nombre ="Andres", Apellido = "Rivera", Especialidad="Programacion"},
                new Catedratico() { CatedraticoId = 4, Nombre ="Noel", Apellido = "De Leon", Especialidad="Matematicas"},
                new Catedratico() { CatedraticoId = 5, Nombre ="Karen", Apellido = "Lopez", Especialidad="Ciencias Exactas"},
            });

            //Cursos
            context.Cursos.AddOrUpdate(new Curso[]
            {
                new Curso() { CursoId = 1, Nombre = "Economia", Categoria ="Primer Semestre", Descripcion = "Clase de 30 alumnos", CatedraticoId = 1},
                new Curso() { CursoId = 2, Nombre = "Derecho Civil", Categoria ="Derecho", Descripcion = "Clase de 20 alumnos", CatedraticoId = 2},
                new Curso() { CursoId = 3, Nombre = "C++", Categoria ="Algortimos base", Descripcion = "Clase de 15 alumnos", CatedraticoId = 3},
                new Curso() { CursoId = 4, Nombre = "Integrales I", Categoria ="Cuarto Semestre", Descripcion = "Clase de 3 alumnos", CatedraticoId = 4},
                new Curso() { CursoId = 5, Nombre = "Contabilidad", Categoria ="Numerica", Descripcion = "Clase de 20 alumnos", CatedraticoId = 5},
            });

            //Alumnos
            context.Alumnos.AddOrUpdate(new Alumno[]
            {
                new Alumno() { AlumnoId =1, Nombre = "Hector", Apellido = "Suarez", DPI ="123456", Edad = 21, CursoId = 1},
                new Alumno() { AlumnoId =2, Nombre = "Emmanuel", Apellido = "Coyoy", DPI ="654321", Edad = 23, CursoId = 2},
                new Alumno() { AlumnoId =3, Nombre = "Fatima", Apellido = "Avila", DPI ="456789", Edad = 21, CursoId = 3},
                new Alumno() { AlumnoId =4, Nombre = "Rosa", Apellido = "Jerez", DPI ="987654", Edad = 20, CursoId = 4},
                new Alumno() { AlumnoId =5, Nombre = "Nuria", Apellido = "Valdez", DPI ="258963", Edad = 19, CursoId = 5},
            });

        }
    }
}
