function cargarSelect(entity){
    fetch(`https://localhost:7287/api/${entity}`)
        .then(response => response.json())
        .then(entities => {
            console.log(entities)
            const body = document.getElementById(entity)
            body.innerHTML = `<option value="" selected>Seleccione un ${entity}...</option>`;
            entities.forEach(x => {
                body.innerHTML += `<option value="${x.id}" selected>${x.nombre}</option>`
            });
            body.selectedIndex = 0;
        })
}
function guardarLibro() {
    const isbn = document.getElementById("inputIsbn")
    const titulo = document.getElementById("inputTitulo")
    const autor = document.getElementById("autor")
    const genero = document.getElementById("genero")

    fetch("https://localhost:7287/api/libro", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            isbn: isbn.value,
            titulo: titulo.value,
            autor: {
                id: autor.value
            },
            genero: {
                id: genero.value
            }
        })
    })
        .then(response => {
            if (!response.ok) {
                console.log(response);
                throw new Error('Error en la solicitud');
        }
        return response.json();
    })
        .then(response => {
            console.log(response);
            alert('Libro guardado exitosamente');
        })
        .catch(error => {
            console.log(response);
            console.error('Error:', error);
            alert('Hubo un error al guardar el libro');
        });
}
function actualizarLibro() {
    const isbn = document.getElementById("inputIsbn").value;
    const titulo = document.getElementById("inputTitulo").value;
    const autor = document.getElementById("autor").value; 
    const genero = document.getElementById("genero").value; 

    fetch(`https://localhost:7287/api/libro/${isbn}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            isbn: isbn,
            titulo: titulo,
            autor: {
                id: autor
            },
            genero: {
                id: genero
            }
        })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Error en la solicitud');
            }
            return response.json();
        })
        .then(response => {
            console.log(response);
            alert('Libro actualizado exitosamente');
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Hubo un error al actualizar el libro');
        });
}
cargarSelect("autor");
cargarSelect("genero");
