function init() {
    console.log('Initializing Task Management App');

    // Event listener per il form di aggiunta task
    document.getElementById("taskForm").addEventListener("submit", addTask);

    // Carica i task all'avvio
    fetchTasks();
}

async function fetchTasks() {
    console.log('Fetching tasks...');
    try {
        const response = await fetch('https://localhost:7276/api/Task');

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const tableBody = document.querySelector('#taskTable tbody');
        tableBody.innerHTML = '';

        const tasks = await response.json();

        tasks.forEach(task => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${task.id}</td>
                <td>${task.title}</td>
                <td>${task.description}</td>
                <td>${task.isCompleted ? "✔" : "❌"}</td>`;
            tableBody.appendChild(row);
        });

        console.log({ tasks });

    } catch (error) {
        console.error(`Errore nel recupero dei task:`, error);
    }
}

async function addTask(event) {
    event.preventDefault();
    console.log("Aggiunta nuovo task...");

    const title = document.getElementById("title").value.trim();
    const description = document.getElementById("description").value.trim();

    if (!title) {
        alert("Inserisci un titolo per il task.");
        return;
    }

    const newTask = { title, description, isCompleted: false };

    try {
        const response = await fetch("https://localhost:7276/api/Task", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newTask)
        });

        if (!response.ok) {
            throw new Error(`Errore nell'aggiunta del task. Status: ${response.status}`);
        }

        document.getElementById("taskForm").reset();
        fetchTasks(); // Ricarica la lista dei task

    } catch (error) {
        console.error("Errore durante l'aggiunta del task:", error);
    }
}

// Associa `init()` all'onload della pagina
window.onload = init;
