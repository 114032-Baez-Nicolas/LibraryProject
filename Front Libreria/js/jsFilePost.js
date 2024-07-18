fetch("https://localhost:7262/api/Autores/ObtenerTodosLosAutores")
    .then(response => response.json())
    .then(autores => {

        let body = document.getElementById("autorId")

        autores.forEach(autor => {
            body.innerHTML += `
                 <option value="${autor.id}">${autor.nombre}</option>
                `;

        });
    });

    fetch("https://localhost:7262/api/Generos/ObtenerTodosLosGeneros")
    .then(response => response.json())
    .then(generos => {

        let body = document.getElementById("generoId")

        generos.forEach(genero => {
            body.innerHTML += `
                 <option value="${genero.id}">${genero.nombre}</option>
                `;

        });
    });


$(document).ready(function () {

    $('#btnGuardar').click(function () {
        if ($('#formPost').valid() == false) {
            Swal.fire({
                title: "Error..",
                text: "Debe completar los campos..",
                icon: "error"
            });
        }

    });

    $("#formPost").validate({
        rules: {
            titulo: {
                required: true
            },
            fechaPublicacion: {
                required: true
            },
            autorId: {
                required: true
            },
            generoId: {
                required: true
            }
        },
        messages: {
            titulo: {
                required: "El campo Título es obligatorio"
            },
            fechaPublicacion: {
                required: "El campo Fecha de Publicación es obligatorio"
            },
            autorId: {
                required: "El campo ID del Autor es obligatorio"
            },
            generoId: {
                required: "El campo ID del Género es obligatorio"
            }
        },
        submitHandler: function () {

            let titulo = document.getElementById("titulo");
            let fechaPublicacion = document.getElementById("fechaPublicacion");
            let autorId = document.getElementById("autorId");
            let generoId = document.getElementById("generoId");

            fetch("https://localhost:7262/api/Libros/CrearLibro", {
                method: 'POST',
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({

                    isbn: crypto.randomUUID(),
                    titulo: titulo.value,
                    fechaPublicacion: new Date(fechaPublicacion.value).toISOString(),
                    lAutorId: autorId.value,
                    lGeneroId: generoId.value,
                })
            })
                .then(response => response.json())
                .then(data => {

                    Swal.fire({
                        title: "Libro creado..",
                        text: "El libro se ha creado correctamente..",
                        icon: "success"
                    });
                })
                .catch(error => {
                    Swal.fire({
                        title: "Error..",
                        text: "Ha ocurrido un error..",
                        icon: "error"
                    });
                });
        }
    });
});