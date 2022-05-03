var ViewModel = function () {
    var self = this;
    self.cursos = ko.observableArray();
    //Permite el enlace de los datos. Cuando el contenido de este cambia, el observable notifica
    //a todos los controles enlazados.
    //observableArray -> es la version de matriz de observable
    self.error = ko.observable();

    var listaCursosURI = '/api/Curso/';

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

    function getListaCursos() {
        ajaxHelper(listaCursosURI, 'GET').done(function (data) {
            self.cursos(data);
        });
    }

    //Llama  a la funcion creada
    getListaCursos();

    self.detalle = ko.observable();
    self.getCursoDetalle = function (item) {
        ajaxHelper(listaCursosURI + item.Id, 'GET').done(function (data) {
            self.detalle(data);
        })
    }

    self.catedraticos = ko.observableArray();

    self.nuevoCurso = {
        Catedratico: ko.observable(),
        Nombre: ko.observable(),
        Categoria: ko.observable(),
        Descripcion: ko.observable()
    }

    var catedraticoURI = '/api/Catedratico/';

    function getCatedraticos() {
        ajaxHelper(catedraticoURI, 'GET').done(function (data) {
            self.catedraticos(data);
        });
    }
    self.agregarCurso = function (formElement) {
        var curso = {
            CatedraticoId: self.nuevoCurso.Catedratico().CatedraticoId,
            Nombre: self.nuevoCurso.Nombre(),
            Categoria: self.nuevoCurso.Categoria(),
            Descripcion: self.nuevoCurso.Descripcion()
        };
        ajaxHelper(listaCursosURI, 'POST', curso).done(function (item) {
            self.libro.push(item);
        });
    }

    getCatedraticos();
};

ko.applyBindings(new ViewModel());