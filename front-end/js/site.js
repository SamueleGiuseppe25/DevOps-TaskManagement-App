function init() {
    console.log('init');
    FetchStudents()
}

async function FetchStudents() {
    console.log('FetchStudents')
    try {
        const response = await fetch('https://localhost:7276/api/Student');
       
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const tableBody = document.querySelector('#studentTable tbody');

        tableBody.innerHTML = '';

        const students = await response.json();

        students.forEach(student => { 

                const row = document.createElement('tr');
                row.innerHTML = `
                <td>${student.id}</td>
                <td>${student.name}</td>
                <td>${student.email}</td>
                <td>${student.age}</td>
                <td>${student.course}</td>`
                tableBody.appendChild(row);

        });


        console.log({students});

    } catch (error) {

        console.error(`HTTP error! status: ${response.status}`);

     }



}

