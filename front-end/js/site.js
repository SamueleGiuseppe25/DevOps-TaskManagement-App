function init() {
    console.log('init');
    FetchStudents()
}

async function FetchStudents() { 
    const response = await fetch('https://localhost:7276/api/Student');
    console.log('FetchStudents');
}

