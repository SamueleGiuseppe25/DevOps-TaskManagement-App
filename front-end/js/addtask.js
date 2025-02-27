const apiUrl = "http://localhost:5053/api/Task";  // Aggiorna con la porta giusta!

async function addTask(event) {
    event.preventDefault(); // Evita il refresh della pagina

    const title = document.getElementById("title").value.trim();
    const description = document.getElementById("description").value.trim();

    if (!title) {
        alert("Please enter a task title.");
        return;
    }

    const newTask = { title, description, isCompleted: false };

    try {
        const response = await fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newTask)
        });

        if (!response.ok) {
            throw new Error("Failed to add task.");
        }

        document.getElementById("taskForm").reset();
        loadTasks(); // Ricarica la tabella con i task aggiornati
    } catch (error) {
        console.error("Error adding task:", error);
    }
}

async function loadTasks() {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        const tasks = await response.json();
        const tableBody = document.querySelector("#taskTable tbody");

        tableBody.innerHTML = "";
        tasks.forEach(task => {
            tableBody.innerHTML += `<tr>
                <td>${task.id}</td>
                <td>${task.title}</td>
                <td>${task.description}</td>
                <td>${task.isCompleted ? "✔" : "❌"}</td>
                <td><button onclick="completeTask(${task.id})">✔ Completed</button></td>
                <td><button onclick="deleteTask(${task.id})">🗑 Delete</button></td>
            </tr>`;
        });

    } catch (error) {
        console.error("Error loading tasks:", error);
    }
}

async function completeTask(id) {
    try {
        // Recupera il task esistente dal backend
        const response = await fetch(`${apiUrl}/${id}`);
        if (!response.ok) {
            throw new Error("Failed to fetch task data.");
        }
        const task = await response.json(); // Ottiene i dettagli attuali del task

        // Aggiorna solo lo stato `isCompleted`
        task.isCompleted = true;

        // Invia il task aggiornato con tutti i dati richiesti
        const updateResponse = await fetch(`${apiUrl}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(task)
        });

        if (!updateResponse.ok) {
            throw new Error("Failed to complete task.");
        }

        loadTasks(); // Ricarica la tabella con i task aggiornati
    } catch (error) {
        console.error("Error completing task:", error);
    }
}


async function deleteTask(id) {
    try {
        const response = await fetch(`${apiUrl}/${id}`, {
            method: "DELETE"
        });

        if (!response.ok) {
            throw new Error("Failed to delete task.");
        }

        loadTasks(); // Ricarica la tabella con i task aggiornati
    } catch (error) {
        console.error("Error deleting task:", error);
    }
}

// Associa la funzione al form e carica i task all'avvio
document.getElementById("taskForm").addEventListener("submit", addTask);
window.onload = loadTasks;
