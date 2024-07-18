fetch('https://localhost:7262/api/Libros/ObtenerTodosLosLibros')
.then(response => response.json())
.then(data => {
    const tableBody = document.getElementById('tableBody');
    data.forEach(book => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${book.titulo}</td>
            <td>${book.fechaPublicacion}</td>
            <td>${book.nombreAutor}</td>
            <td>${book.nombreGenero}</td>
        `;
        tableBody.appendChild(row);
    });
})
.catch(error => console.error(error));