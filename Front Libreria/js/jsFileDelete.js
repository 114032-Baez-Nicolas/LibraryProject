fetch('https://localhost:7262/api/Libros/ObtenerTodosLosLibros')
.then(response => response.json())
.then(data => {
    const libroSelect = document.getElementById('libroSelect');
    data.forEach(libro => {
        const option = document.createElement('option');
        option.value = libro.isbn;
        option.text = libro.titulo;
        libroSelect.appendChild(option);
    });
});

document.getElementById('libroSelect').addEventListener('change', () => {
const selectedLibroId = document.getElementById('libroSelect').value;
fetch(`https://localhost:7262/api/Libros/GetLibroById/${selectedLibroId}`)
    .then(response => response.json())
    .then(data => {
        document.getElementById('autorInput').value = data.nombreAutor;
        document.getElementById('generoInput').value = data.nombreGenero;
    });
});

document.getElementById('deleteButton').addEventListener('click', () => {
const selectedLibroId = document.getElementById('libroSelect').value;
fetch(`https://localhost:7262/api/Libros/DeleteLibro/${selectedLibroId}`, {
    method: 'DELETE'
})
    .then(response => {
        if (response.ok) {
            alert('Libro eliminado correctamente..')
            window.location.href = 'GetLibros.html';
            
        } else {
            alert('Error al eliminar el libro..');
        }
    });
});