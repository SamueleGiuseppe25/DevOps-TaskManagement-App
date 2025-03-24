function init() {
    console.log('Task management initialized.');
  
    // Event listener for form submission
    document.getElementById("studentForm").addEventListener("submit", addTask);
    FetchTasks();
}

async function FetchTasks() {
    console.log('Fetching tasks...');
    try {
        const response = await fetch(apiUrl);
       
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const tableBody = document.querySelector('#taskTable tbody');
        tableBody.innerHTML = ''; // Clear table before appending

        const tasks = await response.json();

        tasks.forEach(task => { 
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${task.id}</td>
                <td>${task.title}</td>
                <td>${task.description}</td>
                <td>${new Date(task.dueDate).toLocaleString()}</td>
                <td class="priority-${task.priority.toLowerCase()}">${task.priority}</td>
                <td>${task.status}</td>
                <td>
                    <button class="complete-task" onclick="completeTask(${task.id})">✔ Complete</button>
                    <button class="delete-task" onclick="deleteTask(${task.id})">🗑 Delete</button>
                </td>
            `;
            tableBody.appendChild(row);
        });

        console.log({ tasks });

    } catch (error) {
        console.error(`Error fetching tasks: ${error}`);
    }
}


