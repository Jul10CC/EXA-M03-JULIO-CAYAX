var ViewModel = function () {
    var self = this;
    //Variables
    self.cursos = ko.observableArray();
    self.alumnos = ko.observableArray();

    //Permite el enlace de los datos. Cuando el contenido de este cambia, el observable notifica
    //a todos los controles enlazados.
    //observableArray -> es la version de matriz de observable
    self.error = ko.observable();

    //APIS
    var listaCursosURI = '/api/Curso/';
    var listaAlumnosURI = '/api/Alumno/';

    function ajaxHelper(uri, method, data) {
        self.error(''); //Limpia la variable
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown)
        });
    }

    //GET
    function getListaCursos() {
        ajaxHelper(listaCursosURI, 'GET').done(function (data) {
            self.cursos(data);
        });
    }
    function getListaAlumnos() {
        ajaxHelper(listaAlumnosURI, 'GET').done(function (data) {
            self.alumnos(data);
        });
    }

    //Llama  a la funcion creada
    getListaCursos();
    getListaAlumnos()

    //Detalles
    self.detalle = ko.observable();
    self.getCursoDetalle = function (item) {
        ajaxHelper(listaCursosURI + item.Id, 'GET').done(function (data) {
            self.detalle(data);
        })
    }

    self.detallealumno = ko.observable();
    self.getAlumnoDetalle = function (item) {
        ajaxHelper(listaAlumnosURI + item.Id, 'GET').done(function (data) {
            self.detallealumno(data);
        })
    }

    //ComboBox
    self.catedraticos = ko.observableArray();

    var catedraticoURI = '/api/Catedratico/';

    function getCatedraticos() {
        ajaxHelper(catedraticoURI, 'GET').done(function (data) {
            self.catedraticos(data);
        });
    }

    getCatedraticos();

    //PUT
    self.nuevoCurso = {
        Catedratico: ko.observable(),
        Nombre: ko.observable(),
        Categoria: ko.observable(),
        Descripcion: ko.observable()
    }

    self.nuevoAlumno = {
        Curso: ko.observable(),
        Nombre: ko.observable(),
        Apellido: ko.observable(),
        DPI: ko.observable(),
        Edad: ko.observable()
    }

    self.agregarCurso = function (formElement) {
        var curso = {
            CatedraticoId: self.nuevoCurso.Catedratico().CatedraticoId,
            Nombre: self.nuevoCurso.Nombre(),
            Categoria: self.nuevoCurso.Categoria(),
            Descripcion: self.nuevoCurso.Descripcion()
        };
        ajaxHelper(listaCursosURI, 'POST', curso).done(function (item) {
            self.curso.push(item);
        });
    }

    self.agregarAlumno = function (formElement) {
        var alumno = {
            CursoId: self.nuevoAlumno.Curso().CursoId,
            Nombre: self.nuevoAlumno.Nombre(),
            Apellido: self.nuevoAlumno.Apellido(),
            DPI: self.nuevoAlumno.DPI(),
            Edad: self.nuevoAlumno.Edad(),
        };
        ajaxHelper(listaAlumnosURI, 'POST', alumno).done(function (item) {
            self.libro.push(item);
        });
    }
};

ko.applyBindings(new ViewModel());