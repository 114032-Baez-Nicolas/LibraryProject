fetch('https://localhost:7262/api/Libros/ObtenerTodosLosLibros')
            .then(response => response.json())
            .then(data => {
                const bookSelect = document.getElementById('bookSelect');
                data.forEach(book => {
                    const option = document.createElement('option');
                    option.value = book.isbn;
                    option.text = book.titulo;
                    bookSelect.appendChild(option);
                });
            });

        fetch('https://localhost:7262/api/Autores/ObtenerTodosLosAutores')
            .then(response => response.json())
            .then(data => {
                const authorSelect = document.getElementById('authorSelect');
                data.forEach(author => {
                    const option = document.createElement('option');
                    option.value = author.id;
                    option.text = author.nombre;
                    authorSelect.appendChild(option);
                });
            });

        fetch('https://localhost:7262/api/Generos/ObtenerTodosLosGeneros')
            .then(response => response.json())
            .then(data => {
                const genreSelect = document.getElementById('genreSelect');
                data.forEach(genre => {
                    const option = document.createElement('option');
                    option.value = genre.id;
                    option.text = genre.nombre;
                    genreSelect.appendChild(option);
                });
            });


        const form = document.getElementById('editBookForm');
        form.addEventListener('submit', (event) => {
            event.preventDefault();
            const isbn = document.getElementById('bookSelect').value;
            const titulo = document.getElementById('bookSelect').options[bookSelect.selectedIndex].text;
            const fechaPublicacion = document.getElementById('dateInput').value;
            const lAutorId = document.getElementById('authorSelect').value;
            const lGeneroId = document.getElementById('genreSelect').value;

            const data = {
                isbn,
                titulo,
                fechaPublicacion,
                lAutorId,
                lGeneroId
            };

            fetch('https://localhost:7262/api/Libros/UpdateLibro', {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
                .then(response => response.json())
                .then(data => {
                    alert('Libro actualizado');
                    window.location.href = 'GetLibros.html';
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        });