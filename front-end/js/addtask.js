      // Function to add a new student
      const apiUrl = "https://localhost:7276/api/Task";
      
async function addTask(event) {
    event.preventDefault(); // Prevent form refresh

    const title = document.getElementById("title").value.trim();
    const description = document.getElementById("description").value.trim();
    const dueDate = new Date(document.getElementById("dueDate").value).toISOString();
    const priority = document.getElementById("priority").value;
    const status = document.getElementById("status").value;

    if (!title || !dueDate) {
        alert("Title and Due Date are required!");
        return;
    }

    const newTask = { title, description, dueDate, priority, status };

    try {
        const response = await fetch(apiUrl, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(newTask)
        });

        if (!response.ok) {
            throw new Error("Failed to add task.");
        }

        document.getElementById("studentForm").reset(); // Clear form
        FetchTasks(); // Refresh task list
    } catch (error) {
        console.error("Error adding task:", error);
    }

}

async function completeTask(id) {
    try {
        const response = await fetch(`${apiUrl}/${id}/complete`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" }
        });

        if (!response.ok) {
            throw new Error("Failed to complete task.");
        }

        FetchTasks(); // Ricarica la tabella con i task aggiornati
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

        FetchTasks(); // Ricarica la tabella con i task aggiornati
    } catch (error) {
        console.error("Error deleting task:", error);
    }
}